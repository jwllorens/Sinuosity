using MessagePack;
using Sinuosity.Common;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;



namespace Sinuosity
{
    
    public partial class Xmanager
    {
        private Xnode _rootNode = null;
        private string _attrFilter;
        private System.Windows.Forms.TreeView _treeView;
        private Xcache _cache = null;
        private readonly string _debugID = null;
        private readonly HashSet<string> _reservedAttributes = new HashSet<string> { "ID", "DataType", "order", "version", "timeStamp", "filePath"};
        public bool treeViewInitialized { get; private set; } = false;
        public bool rootInitialized { get; private set; } = false;
        public int CacheCapacity { get; private set; }

        //public Xnode RootNode => _rootNode; // Not needed, we don't want to expose the Xnode.

        [MessagePackObject(AllowPrivate = true)]
        internal partial class Xnode
        {
            [Key(0)] public string ID { get; set; }
            [Key(1)] public string Tag { get; private set; } = "SEED";
            [Key(2)] public Dictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();
            [Key(3)] public object _dataValue { get; set; }
            [Key(4)] public Type DataType { get; private set; }
            [Key(5)] public List<Xnode> _children { get; set; } = new List<Xnode>();
            [IgnoreMember] public Xnode Parent { get; set; }
            [IgnoreMember] public object DataValue => _dataValue;


            public Xnode() { } // Default constructor for MessagePack deserialization
            public Xnode(string id) // original constructor for creating nodes on the fly
            {
                if (string.IsNullOrWhiteSpace(id))
                    throw new ArgumentException("ID cannot be null, empty, or whitespace", nameof(id));
                if (ContainsIllegalXmlCharacters(id))
                    throw new ArgumentException("ID contains illegal XML characters (<, >, \", ', &, \\r, \\n)", nameof(id));
                ID = id;
            }
            public void RestoreAfterDeserialization() // Method to restore transient properties and fix parent references after deserialization
            {
                if (_dataValue != null && DataType != null && _dataValue is string stringValue && DataType != typeof(string))
                {
                    try
                    {
                        _dataValue = Convert.ChangeType(stringValue, DataType);
                    }
                    catch (Exception ex)
                    {
                        // Log or handle conversion failure (e.g., set to null or throw)
                        Console.WriteLine($"Failed to convert value '{stringValue}' to type {DataType.Name}: {ex.Message}");
                        _dataValue = null; // Fallback to null if conversion fails
                    }
                }
                foreach (var child in _children)
                {
                    child.Parent = this; // Re-establish parent link
                    child.RestoreAfterDeserialization(); // Recursively restore
                }
            }
            public void SetValue(object value)
            {
                if (Tag == "BRANCH" || Tag == "ROOT")
                    throw new InvalidOperationException($"Cannot set DataValue on a {Tag} node");
                _dataValue = value;
                DataType = value?.GetType(); // Ensure DataType is updated here
                Tag = "LEAF";
                //var childrenToDelete = _children.ToList();
                //foreach (var child in childrenToDelete)
                //{
                //    child.Delete();
                //}
            }
            public void AddChild(Xnode child)
            {
                if (child == null)
                    throw new ArgumentNullException(nameof(child));
                if (Tag == "LEAF")
                    throw new InvalidOperationException("Cannot add children to a value node");
                if (_children.Any(c => c.ID == child.ID))
                    throw new InvalidOperationException($"A child with ID '{child.ID}' already exists");
                if (child.Parent != null)
                    child.Parent.RemoveChild(child);

                child.Parent = this;
                _children.Add(child);

                if (Tag != "LEAF")
                    Tag = Parent == null ? "ROOT" : "BRANCH";

                child.RootToBranch(this);

                _dataValue = null;
                DataType = null; // Reset DataType when becoming a branch/root
            }
            public void RootToBranch(Xnode caller)
            {
                if (Parent != caller)
                    throw new InvalidOperationException("ConvertToBranch can only be called by the node's parent");
                if (Tag == "ROOT")
                {
                    Tag = "BRANCH";
                    _dataValue = null;
                    DataType = null;
                }
            }
            public void RemoveChild(Xnode child)
            {
                if (child == null)
                    throw new ArgumentNullException(nameof(child));
                if (_children.Remove(child))
                {
                    child.Parent = null;
                    if (_children.Count == 0 && Tag != "LEAF")
                        Tag = null;
                }
            }
            public Xnode GetChild(string id)
            {
                if (string.IsNullOrEmpty(id))
                    throw new ArgumentException("ID cannot be null or empty", nameof(id));
                return _children.FirstOrDefault(c => c.ID == id);
            }
            public string[] GetChildIDs()
            {
                return _children.Select(c => c.ID).ToArray();
            }
            public void Delete()
            {
                var childrenToDelete = _children.ToList();
                _children.Clear();
                foreach (var child in childrenToDelete)
                {
                    child.Delete();
                }
                if (Parent != null)
                    Parent.RemoveChild(this);
            }
            public Xnode GetRoot()
            {
                Xnode current = this;
                while (current.Parent != null)
                    current = current.Parent;
                return current;
            }
            public T GetValue<T>()
            {
                if (_dataValue == null)
                    return default(T);
                if (!typeof(T).IsAssignableFrom(DataType))
                    throw new InvalidCastException($"Cannot cast stored data of type {DataType?.Name ?? "null"} to {typeof(T).Name}");
                return (T)_dataValue;
            }
            public Xnode DeepCopy()
            {
                Xnode copy = new Xnode(ID);
                if (Tag == "LEAF")
                {
                    copy.SetValue(_dataValue);
                }
                else if (Tag == "ROOT" || Tag == "BRANCH")
                {
                    foreach (var child in _children)
                    {
                        Xnode childCopy = child.DeepCopy();
                        copy.AddChild(childCopy);
                    }
                }
                foreach (var kvp in Attributes)
                {
                    copy.SetAttribute(kvp.Key, kvp.Value);
                }
                return copy;
            }
            public void Rename(string newId)
            {
                if (string.IsNullOrWhiteSpace(newId))
                    throw new ArgumentException("New ID cannot be null, empty, or whitespace", nameof(newId));
                if (ContainsIllegalXmlCharacters(newId))
                    throw new ArgumentException("New ID contains illegal XML characters (<, >, \", ', &, \\r, \\n)", nameof(newId));

                ID = newId;
            }
            public void SetAttribute(string key, string value)
            {
                if (string.IsNullOrEmpty(key))
                    throw new ArgumentException("Key cannot be null or empty", nameof(key));
                if (key.Equals("ID", StringComparison.OrdinalIgnoreCase) || key.Equals("DataType", StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException("'ID' and 'DataType' are reserved attribute names and cannot be set");
                Attributes[key] = value;
            }
            public string GetAttribute(string key)
            {
                if (string.IsNullOrEmpty(key))
                    throw new ArgumentException("Key cannot be null or empty", nameof(key));
                return Attributes.TryGetValue(key, out string value) ? value : null;
            }
            public void RemoveAttribute(string key)
            {
                if (string.IsNullOrEmpty(key))
                    throw new ArgumentException("Key cannot be null or empty", nameof(key));
                Attributes.Remove(key);
            }
            public string[] ListAttributes()
            {
                return Attributes.Keys.ToArray();
            }
            public string StringOut(StringBuilder sb, int indentLevel = 0)
            {
                string indent = new string('\t', indentLevel);

                sb.Append(indent).Append("<").Append(Tag);
                sb.Append(" ID=\"").Append(ID).Append("\"");

                if (Attributes.Any())
                {
                    foreach (var kvp in Attributes)
                    {
                        sb.Append(" ").Append(kvp.Key).Append("=\"").Append(kvp.Value).Append("\"");
                    }
                }

                if (Tag == "LEAF")
                {
                    string dataTypeName = DataType != null ? DataType.Name : "null";
                    sb.Append(" DataType=\"").Append(dataTypeName).Append("\">");
                    if (DataType == typeof(string) && _dataValue != null)
                    {
                        string valueStr = (string)_dataValue;
                        sb.Append(EscapeXmlString(valueStr));
                    }
                    else
                    {
                        sb.Append(_dataValue?.ToString() ?? "null");
                    }
                    sb.Append("</LEAF>");
                }
                else if (Tag == "ROOT" || Tag == "BRANCH")
                {
                    sb.Append(">\r\n");

                    foreach (var child in _children)
                    {
                        child.StringOut(sb, indentLevel + 1);
                        sb.Append("\r\n");
                    }

                    sb.Append(indent).Append("</").Append(Tag).Append(">");
                }
                else
                {
                    sb.Append("/>");
                }
                return sb.ToString();
            }
            private static string EscapeXmlString(string value)
            {
                if (string.IsNullOrEmpty(value))
                    return value;

                return value.Replace("&", "&amp;")
                            .Replace("<", "&lt;")
                            .Replace(">", "&gt;")
                            .Replace("\"", "&quot;")
                            .Replace("'", "&apos;")
                            .Replace("\r", "&#xD;")
                            .Replace("\n", "&#xA;");
            }
            private static bool ContainsIllegalXmlCharacters(string value)
            {
                return value.Any(c => c == '<' || c == '>' || c == '"' || c == '\'' || c == '&' || c == '\r' || c == '\n');
            }
        }// core atomic data structure for the class
        private class Xcache
        {
            private decimal _hitCount = 0;
            private decimal _missCount = 0;
            private readonly int _capacity;
            private readonly Dictionary<string, Xnode> _nodeCache;
            private readonly Dictionary<string, int> _accessCounters;
            private readonly Xmanager _parentInstance;
            private readonly bool _debug = true;
            private readonly string _debugID = null;

            public Xcache(Xmanager parent, int capacity, string debugID = null)
            {
                if (parent == null)
                    throw new ArgumentException("Parent Xmanager instance is null", nameof(parent));
                if (capacity <= 0)
                    throw new ArgumentException("Cache capacity must be positive", nameof(capacity));
                _parentInstance = parent;
                _capacity = capacity;
                _nodeCache = new Dictionary<string, Xnode>(capacity);
                _accessCounters = new Dictionary<string, int>(capacity);
                if (debugID != null) _debugID = $"{debugID} Cache";
                if (_debugID != null) Utilities.Log(_debugID, $"INITIALIZED: Capacity: {_capacity}");
            }
            public bool TryGetNode(string path, out Xnode node)
            {
                if (_nodeCache.TryGetValue(path, out node))
                {
                    int newCount = _accessCounters.ContainsKey(path) ? _accessCounters[path] + 1 : 1;
                    _accessCounters[path] = newCount;
                    _hitCount++;
                    //if (_debug)
                    //    Utilities.Log(this, $"HIT: Access count {newCount} | Path: '{path}'");
                    return true;
                }
                _missCount++;
                return false;
            }
            public void AddOrUpdate(string path, Xnode node)
            {
                if (string.IsNullOrEmpty(path) || node == null)
                {
                    if (_debug)
                        Utilities.Log(_debugID, $"ERROR: Add or update skipped: invalid path '{path}' or null node");
                    return;
                }

                if (_nodeCache.ContainsKey(path))
                {
                    _nodeCache[path] = node;
                    int newCount = _accessCounters.ContainsKey(path) ? _accessCounters[path] + 1 : 1;
                    _accessCounters[path] = newCount;
                    if (_debug)
                        Utilities.Log(_debugID, $"UPDATED: Node ID: '{node.ID}' | Access count: {newCount} | Path: '{path}'");
                }
                else if (_nodeCache.Count < _capacity)
                {
                    _nodeCache[path] = node;
                    _accessCounters[path] = 1;
                    if (_debug)
                        Utilities.Log(_debugID, $"MISS: Added node ID: '{node.ID}' | Capacity usage: {_nodeCache.Count}/{_capacity} | Path: '{path}'");
                }
                else
                {
                    var lfuEntry = _accessCounters.OrderBy(kvp => kvp.Value).First();
                    string lfuPath = lfuEntry.Key;
                    int lfuCount = lfuEntry.Value;
                    _nodeCache.Remove(lfuPath);
                    _accessCounters.Remove(lfuPath);
                    if (_debug)
                        Utilities.Log(_debugID, $"EVICTED: Removed node ID: '{node.ID}' | Access count: {lfuCount} | Capacity usage: {_nodeCache.Count}/{_capacity} | Path: '{lfuPath}'");

                    _nodeCache[path] = node;
                    _accessCounters[path] = 1;
                    if (_debug)
                        Utilities.Log(_debugID, $"MISS: Added node ID: '{node.ID}' | Capacity usage: {_nodeCache.Count}/{_capacity} | Path: '{path}')");
                }
            }
            public void Invalidate(string nodePath)
            {
                string fullPath = _parentInstance.normalizePath(nodePath);
                if (string.IsNullOrEmpty(fullPath))
                {
                    if (_debug)
                        Utilities.Log(_debugID, "ERROR: Invalidation error, empty prefix");
                    return;
                }
                string normalizedPrefix = fullPath.EndsWith("/") ? fullPath : fullPath + "/";
                var pathsToRemove = _nodeCache.Keys
                    .Where(p => p == fullPath || p.StartsWith(normalizedPrefix))
                    .ToList();

                if (pathsToRemove.Count > 0)
                {
                    foreach (string path in pathsToRemove)
                    {
                        string id = _nodeCache[path].ID;
                        int count = _accessCounters[path];
                        _nodeCache.Remove(path);
                        _accessCounters.Remove(path);
                        if (_debug)
                            Utilities.Log(_debugID, $"INVALIDATED: Removed node ID: '{id}' | Access count: {count} | Path: '{path}'");
                    }
                    if (_debug)
                        Utilities.Log(_debugID, $"INVALIDATION COMPLETE: Removed {pathsToRemove.Count} entries. | Capacity usage: {_nodeCache.Count}/{_capacity}");
                }
                else
                {
                    if (_debug)
                        Utilities.Log(_debugID, $"ERROR: Invalidation error, no matches for prefix '{fullPath}'");
                }
            }
            public decimal GetHitPercentage()
            {
                if (!((_hitCount + _missCount) == 0))
                    return 100m * (_hitCount / (_hitCount + _missCount));
                else
                    return 0m;
            }
            public void Clear()
            {
                int oldSize = _nodeCache.Count;
                _nodeCache.Clear();
                _accessCounters.Clear();
                if (_debug)
                    Utilities.Log(_debugID, $"CLEARED: Removed entries: {oldSize}");
            }
        } // optional LFU caching for frequently accessed nodes
        private string normalizePath(string nodePath)
        {
            string[] pathParts = (nodePath.StartsWith("/") ? nodePath.TrimStart('/') : nodePath).TrimEnd('/').Split('/');
            string fullPath = string.Join("/", pathParts);
            if (pathParts[0] == _rootNode.ID)
            {
                return fullPath;
            }
            else
            {
                return _rootNode.ID + '/' + fullPath;
            }
        } // normalizes paths to include the root node ID and handle / characters
        private string getUniqueID(Xnode node, string ID)
        {
            List<string> usedIDs = node.GetChildIDs().ToList();
            bool exists = usedIDs.Contains(ID);
            string dupeString = "";
            int dupeNumber = 0;
            while (exists)
            {
                dupeNumber++;
                dupeString = " (" + dupeNumber.ToString() + ")";
                exists = usedIDs.Contains(ID + dupeString);
            }
            if (dupeNumber > 0) ID = ID + dupeString;
            return ID;
        }
        private Dictionary<string, int?> getOrders(Xnode node)
        {
            List<string> itemList = node.GetChildIDs().ToList();
            Dictionary<string, int?> orderDict = new Dictionary<string, int?>();
            foreach (string childID in node.GetChildIDs())
            {
                string order = node.GetChild(childID).GetAttribute("order");
                orderDict.Add(childID, Convert.ToInt32(order));
            }
            return orderDict;
        }
        private void reOrder(Xnode node, int jumps, string refPath)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Xnode parent = node.Parent ?? throw new InvalidOperationException("Root node cannot be re-ordered");
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            if (jumps == 0) return; // No movement needed

            Dictionary<string, int?> orders = getOrders(parent);

            if (!orders.TryGetValue(node.ID, out int? currentValue) || !currentValue.HasValue)
            {
                return; // Do nothing if key doesn't exist or value is null
            }

            // Determine direction and number of moves
            bool moveUp = jumps > 0;
            int movesRemaining = Math.Abs(jumps);
            Xnode currentNode = node;

            while (movesRemaining > 0)
            {
                var adjacentItem = moveUp
                    ? orders
                        .Where(pair => pair.Value.HasValue && pair.Value < currentValue)
                        .OrderByDescending(pair => pair.Value)
                        .FirstOrDefault()
                    : orders
                        .Where(pair => pair.Value.HasValue && pair.Value > currentValue)
                        .OrderBy(pair => pair.Value)
                        .FirstOrDefault();

                // If no adjacent item exists, stop the process
                if (adjacentItem.Key == null)
                {
                    break;
                }

                string currentValueString = Convert.ToString(currentValue);
                string newValueString = Convert.ToString(adjacentItem.Value);

                Xnode sibling = parent.GetChild(adjacentItem.Key);

                // Perform the swap
                currentNode.SetAttribute("order", newValueString);
                if (_debugID != null)
                    Utilities.Log(_debugID, $"REORDERED: Node ID: '{currentNode.ID}' | Attribute: 'order' | Value: {currentValueString} --> {newValueString} | Path: '{normalizePath(refPath)}'");

                sibling.SetAttribute("order", currentValueString);
                if (_debugID != null)
                {
                    List<string> siblingPathParts = refPath.Split('/').ToList();
                    siblingPathParts.RemoveAt(siblingPathParts.Count - 1);
                    siblingPathParts.Add(sibling.ID);
                    string siblingPath = string.Join("/", siblingPathParts);
                    Utilities.Log(_debugID, $"REORDERED: Node ID: '{sibling.ID}' | Attribute: 'order' | Value: {newValueString} --> {currentValueString} | Path: '{normalizePath(siblingPath)}'");
                }

                // Update for next iteration
                if (movesRemaining > 0)
                {
                    currentValue = adjacentItem.Value;
                    movesRemaining--;
                    orders = getOrders(parent);
                }
            }
        }
        private Xnode getNode(string nodePath, bool create = false)
        {
            // Allow empty path for root access
            string fullPath = normalizePath(nodePath);

            // Check cache first
            if (_cache != null)
                if (_cache.TryGetNode(fullPath, out Xnode cachedNode))
                    return cachedNode;

            string[] ids = fullPath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            Xnode current = _rootNode;

            // Navigate or create the path
            string currentPath = "/";
            for (int i = 1; i < ids.Length; i++)
            {
                if (i > 0)
                    currentPath += ids[i];
                Xnode next = current.GetChild(ids[i]);
                if (next == null)
                {
                    if (create)
                    {
                        try
                        {
                            next = new Xnode(ids[i]);
                            current.AddChild(next);
                            if (_debugID != null)
                            {
                                Utilities.Log(_debugID, $"CREATED: Node ID: '{ids[i]}' | Path: '{nodePath}'");
                            }
                        }
                        catch (InvalidOperationException)
                        {
                            return null; // Failed to add child to a "LEAF" node
                        }
                    }
                    else
                    {
                        return null; // Path doesn’t exist
                    }
                }
                current = next;
            }

            // Cache the result
            if (_cache != null)
                _cache.AddOrUpdate(fullPath, current);
            return current;
        } // workhorse method to handle accessing Xnode objects using string paths
        private static Xnode buildSubtree(TreeStructure seedling)
        {
            Xnode node = new Xnode(seedling.ID);

            // Set attributes
            foreach (var attr in seedling.Attributes)
            {
                node.SetAttribute(attr.Key, attr.Value);
            }

            // Set value or children
            if (seedling.Value != null)
            {
                node.SetValue(seedling.Value); // "LEAF" node
            }
            else if (seedling.Children.Count > 0)
            {
                foreach (var childSeedling in seedling.Children)
                {
                    Xnode childNode = buildSubtree(childSeedling);
                    node.AddChild(childNode);
                }
            }

            return node;
        }  // helper method for Sprout
        private static Xnode parseXmlNode(XmlNode xmlNode)
        {
            string id = xmlNode.Attributes?["ID"]?.Value;
            if (string.IsNullOrEmpty(id))
                throw new InvalidOperationException($"XML node '{xmlNode.Name}' is missing the 'ID' attribute");

            Xnode node = new Xnode(id);

            if (xmlNode.Attributes != null)
            {
                foreach (XmlAttribute attr in xmlNode.Attributes)
                {
                    if (attr.Name != "ID" && attr.Name != "DataType")
                    {
                        node.SetAttribute(attr.Name, attr.Value);
                    }
                }
            }

            if (xmlNode.Name == "LEAF" && xmlNode.HasChildNodes && xmlNode.FirstChild.NodeType == XmlNodeType.Text)
            {
                string valueStr = xmlNode.InnerText;
                string dataTypeStr = xmlNode.Attributes?["DataType"]?.Value;
                if (!string.IsNullOrEmpty(dataTypeStr))
                {
                    Type dataType = Type.GetType("System." + dataTypeStr);
                    if (dataType != null)
                    {
                        object value = Convert.ChangeType(valueStr, dataType);
                        node.SetValue(value);
                    }
                }
            }
            else
            {
                foreach (XmlNode childXmlNode in xmlNode.ChildNodes)
                {
                    if (childXmlNode.NodeType == XmlNodeType.Element)
                    {
                        Xnode childNode = parseXmlNode(childXmlNode);
                        node.AddChild(childNode);
                    }
                }
            }

            return node;
        } // helper method for Load when file format is XML
        private void buildCondensedTreeView(Xnode xnode, TreeNode parentTreeNode, string currentPath, Dictionary<string, bool> expandedState)
        {
            // Process children
            foreach (string childId in xnode.GetChildIDs())
            {
                Xnode childNode = xnode.GetChild(childId);
                if (childNode == null)
                    continue;

                string childPath = string.IsNullOrEmpty(currentPath) ? childId : $"{currentPath}/{childId}";

                // Check if this node has the filter attribute
                bool hasAttribute = childNode.GetAttribute(_attrFilter) != null;

                if (hasAttribute)
                {
                    // This node should be included in the TreeView
                    TreeNode childTreeNode = new TreeNode(childNode.ID);
                    childTreeNode.Tag = childPath;  // Store the full path as tag
                    parentTreeNode.Nodes.Add(childTreeNode);

                    // Process this node's children
                    buildCondensedTreeView(childNode, childTreeNode, childPath, expandedState);
                }
                else
                {
                    // This node should not be included, but its children might be
                    // Process children directly under the parent node
                    buildCondensedTreeView(childNode, parentTreeNode, childPath, expandedState);
                }
            }
        } // helper method for managing an attached TreeView to display a condensed version of the Xnode tree in a UI
        private static void storeExpandedState(TreeNode node, Dictionary<string, bool> expandedState, string nodePath)
        {
            if (node == null)
                return;

            expandedState[nodePath] = node.IsExpanded;

            foreach (TreeNode childNode in node.Nodes)
            {
                string childPath = Convert.ToString(childNode.Tag);
                storeExpandedState(childNode, expandedState, childPath);
            }
        } // helper method for storing tree state in an attached TreeView after updating tree structure
        private void restoreExpandedState(TreeNode node, Dictionary<string, bool> expandedState, string nodePath)
        {
            if (node == null)
                return;

            if (expandedState.TryGetValue(nodePath, out bool isExpanded) && isExpanded)
            {
                node.Expand();
            }

            foreach (TreeNode childNode in node.Nodes)
            {
                string childPath = Convert.ToString(childNode.Tag);
                restoreExpandedState(childNode, expandedState, childPath);
            }
        }// helper method for restoring tree state in an attached TreeView after updating tree structure
        public Xmanager(int cacheCapacity = 0, string debugID = null)
        {
            if (cacheCapacity > 0)
                _cache = new Xcache(this, cacheCapacity, debugID);
            CacheCapacity = cacheCapacity;
            _debugID = debugID;
            if (_debugID != null) Utilities.Log(_debugID, "INITIALIZED");
        } // Class initializer.  Does nothing but set up cache, if specified.
        public void ReinitializeCache(int cacheCapacity = 0) //public method for re-initializing cache to a different size or removing it entirely.  
        {
            if (_cache != null)
            {
                _cache.Clear();
                _cache = null;
            }
            if (cacheCapacity > 0)
                _cache = new Xcache(this, cacheCapacity, _debugID);
            CacheCapacity = cacheCapacity;
        }
        public void New(string rootID)
        {
            if (string.IsNullOrEmpty(rootID))
                throw new ArgumentException("Root ID cannot be null or empty", nameof(rootID));
            _rootNode = new Xnode(rootID);
            rootInitialized = true;
            if (_debugID != null) Utilities.Log(_debugID, $"NEW: New root node created with ID: '{rootID}'");
        }
        public bool LoadFile()
        {
            bool success = false;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                ofd.Filter = "Data files (*.dat;*.xml)|*.dat;*.xml";
                ofd.Title = "Select a Data File";
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;

                    try
                    {
                        if (filePath.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                        {
                            XmlDocument doc = new XmlDocument();
                            doc.Load(filePath);
                            XmlNode rootXmlNode = doc.DocumentElement;
                            if (rootXmlNode == null)
                                throw new InvalidOperationException("XML file has no root element");

                            _rootNode = parseXmlNode(rootXmlNode);
                        }
                        else if (filePath.EndsWith(".dat", StringComparison.OrdinalIgnoreCase))
                        {
                            var options = MessagePackSerializerOptions.Standard.WithResolver(MessagePack.Resolvers.ContractlessStandardResolver.Instance);
                            _rootNode = MessagePackSerializer.Deserialize<Xnode>(File.ReadAllBytes(filePath), options);
                            _rootNode.RestoreAfterDeserialization();
                        }
                        else
                        {
                            throw new InvalidOperationException("Xmanager load operation failed. Invalid file type.");
                        }
                        rootInitialized = true;
                        _rootNode.SetAttribute("filePath", filePath);
                        if (_cache != null)
                            _cache.Clear();
                        UpdateTreeView();
                        if (_debugID != null)
                            Utilities.Log(_debugID, $"LOADED: ID: {_rootNode.ID} | Version: {_rootNode.GetAttribute("version")} | TimeStamp: {_rootNode.GetAttribute("timeStamp")} | Path: '{_rootNode.GetAttribute("filePath")}'");
                        success = true; // Only set to true if all succeeds
                    }
                    catch (Exception ex) // Catches all exceptions, including InvalidOperationException, IOException, etc.
                    {
                        success = false; // Ensure success remains false on any error
                                         // Optional: Log the exception or show a message
                        MessageBox.Show($"Failed to load file: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            return success;
        }
        public bool SilentLoad(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return false;

            try
            {
                if (!filePath.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                    return false; // Only XML files are supported

                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                XmlNode rootXmlNode = doc.DocumentElement;
                if (rootXmlNode == null)
                    return false; // No root element

                _rootNode = parseXmlNode(rootXmlNode);
                rootInitialized = true;
                _rootNode.SetAttribute("filePath", filePath);
                if (_cache != null)
                    _cache.Clear();
                UpdateTreeView();
                if (_debugID != null)
                    Utilities.Log(_debugID, $"LOADED: ID: {_rootNode.ID} | Version: {_rootNode.GetAttribute("version")} | TimeStamp: {_rootNode.GetAttribute("timeStamp")} | Path: '{_rootNode.GetAttribute("filePath")}'");
                return true;
            }
            catch (Exception) // Catch all exceptions (e.g., XmlException, IOException)
            {
                return false; // Silently fail without logging or popups
            }
        }
        public bool SaveFile(bool saveAs = false)
        {
            if (_rootNode == null)
                throw new InvalidOperationException("No root node exists to save");

            string filePath;

            if (!saveAs)
            {
                // Use the existing file path from the root node's attribute
                filePath = _rootNode.GetAttribute("filePath");
                if (string.IsNullOrEmpty(filePath))
                    throw new InvalidOperationException("No file path attribute found for saving. Use Save As instead.");
            }
            else
            {
                // Open a SaveFileDialog for Save As
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                    saveFileDialog.Filter = "Data files (*.dat;*.xml)|*.dat;*.xml|All files (*.*)|*.*";
                    saveFileDialog.Title = "Save Data File";
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.DefaultExt = "dat";
                    saveFileDialog.AddExtension = true;

                    if (saveFileDialog.ShowDialog() != DialogResult.OK)
                        return false; // User canceled; return false to propagate cancellation

                    filePath = saveFileDialog.FileName;
                }
            }

            if (string.IsNullOrEmpty(filePath))
                throw new ArgumentException("File path cannot be null or empty", nameof(filePath));

            // Set the filePath, version, timeStamp attributes before saving
            ulong version = 0;
            if (ulong.TryParse(_rootNode.GetAttribute("version"), out ulong verResult))
                version = verResult + 1;
            _rootNode.SetAttribute("filePath", filePath);
            _rootNode.SetAttribute("version",version.ToString());
            _rootNode.SetAttribute("timeStamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

            // Perform the save based on the extension
            if (filePath.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    StringBuilder sb = new StringBuilder();
                    string xmlString = _rootNode.StringOut(sb);
                    sw.Write(xmlString);
                }
            }
            else if (filePath.EndsWith(".dat", StringComparison.OrdinalIgnoreCase))
            {
                var options = MessagePackSerializerOptions.Standard.WithResolver(MessagePack.Resolvers.ContractlessStandardResolver.Instance);
                File.WriteAllBytes(filePath, MessagePackSerializer.Serialize(_rootNode, options));
            }
            else
            {
                throw new InvalidOperationException("Xmanager save operation failed. Invalid file type.");
            }
            if (_debugID != null)
                Utilities.Log(_debugID, $"SAVED: ID: {_rootNode.ID} | Version: {verResult.ToString()} --> {_rootNode.GetAttribute("version")} | TimeStamp: '{_rootNode.GetAttribute("timeStamp")}' | Path: '{_rootNode.GetAttribute("filePath")}'");
            // Show success message at the end
            MessageBox.Show($"'{filePath}' saved with root ID '{_rootNode.ID}', version {_rootNode.GetAttribute("version")}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true; // Save succeeded
        }
        public bool SilentSave()
        {
            if (_rootNode == null)
                return false; // No root node to save

            // Use the existing file path from the root node's attribute
            string filePath = _rootNode.GetAttribute("filePath");
            if (string.IsNullOrEmpty(filePath))
                return false; // No file path available

            try
            {
                // Set version and timestamp attributes before saving
                ulong version = 0;
                if (ulong.TryParse(_rootNode.GetAttribute("version"), out ulong verResult))
                    version = verResult + 1;
                _rootNode.SetAttribute("filePath", filePath);
                _rootNode.SetAttribute("version", version.ToString());
                _rootNode.SetAttribute("timeStamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));


                // Always save as XML, regardless of original extension
                string xmlFilePath = Path.ChangeExtension(filePath, ".xml");
                using (StreamWriter sw = new StreamWriter(xmlFilePath))
                {
                    StringBuilder sb = new StringBuilder();
                    string xmlString = _rootNode.StringOut(sb);
                    sw.Write(xmlString);
                }
                if (_debugID != null)
                    Utilities.Log(_debugID, $"SAVED: ID: {_rootNode.ID} | Version: {verResult.ToString()} --> {_rootNode.GetAttribute("version")} | TimeStamp: '{_rootNode.GetAttribute("timeStamp")}' | Path: '{_rootNode.GetAttribute("filePath")}'");
                return true; // Save succeeded
            }
            catch (Exception) // Catch all exceptions (e.g., IOException, UnauthorizedAccessException)
            {
                return false; // Silently fail
            }
        }
        public bool SilentSaveAs(string filePath)
        {
            if (_rootNode == null)
                return false; // No root node to save

            if (string.IsNullOrEmpty(filePath))
                return false; // No file path available

            try
            {
                // Set version and timestamp attributes before saving
                ulong version = 0;
                if (ulong.TryParse(_rootNode.GetAttribute("version"), out ulong verResult))
                    version = verResult + 1;
                _rootNode.SetAttribute("filePath", filePath);
                _rootNode.SetAttribute("version", version.ToString());
                _rootNode.SetAttribute("timeStamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));


                // Always save as XML, regardless of original extension
                string xmlFilePath = Path.ChangeExtension(filePath, ".xml");
                using (StreamWriter sw = new StreamWriter(xmlFilePath))
                {
                    StringBuilder sb = new StringBuilder();
                    string xmlString = _rootNode.StringOut(sb);
                    sw.Write(xmlString);
                }
                if (_debugID != null)
                    Utilities.Log(_debugID, $"SAVED: ID: {_rootNode.ID} | Version: {verResult.ToString()} --> {_rootNode.GetAttribute("version")} | TimeStamp: '{_rootNode.GetAttribute("timeStamp")}' | Path: '{_rootNode.GetAttribute("filePath")}'");
                return true; // Save succeeded
            }
            catch (Exception) // Catch all exceptions (e.g., IOException, UnauthorizedAccessException)
            {
                return false; // Silently fail
            }
        }
        public void InitializeTreeView(System.Windows.Forms.TreeView treeView, string attributeFilter)
        {
            if (treeView == null)
                throw new ArgumentNullException(nameof(treeView));
            if (string.IsNullOrEmpty(attributeFilter))
                throw new ArgumentException("Attribute filter cannot be null or empty", nameof(attributeFilter));

            _treeView = treeView;
            _attrFilter = attributeFilter;

            // Clear existing nodes
            _treeView.Nodes.Clear();

            // Build the condensed tree structure
            UpdateTreeView();
            treeViewInitialized = true;
        }
        public void UpdateTreeView()
        {
            if (_treeView == null || string.IsNullOrEmpty(_attrFilter))
                return;

            // Store the expanded state of nodes
            Dictionary<string, bool> expandedState = new Dictionary<string, bool>();
            if (_treeView.Nodes.Count > 0)
            {
                storeExpandedState(_treeView.Nodes[0], expandedState, "");
            }

            // Clear existing nodes
            _treeView.BeginUpdate();
            _treeView.Nodes.Clear();

            // Create the root node
            TreeNode rootTreeNode = new TreeNode(_rootNode.ID);
            rootTreeNode.Tag = "";  // Root node has empty path
            _treeView.Nodes.Add(rootTreeNode);

            // Build the condensed tree structure
            buildCondensedTreeView(_rootNode, rootTreeNode, "", expandedState);

            _treeView.Sort();

            // Restore expanded state
            restoreExpandedState(rootTreeNode, expandedState, "");

            _treeView.EndUpdate();
        }
        public void DisposeTreeView()
        {
            _treeView.Nodes.Clear();
            _treeView = null;
            _attrFilter = null;
            treeViewInitialized = false;
        }
        public string GetID(string nodePath = null)
        {
            Xnode node = getNode(nodePath, create: false);
            if (node == null)
                return null;
            return node.ID;
        }
        public void SetID(string newID, string nodePath = null)
        {
            if (string.IsNullOrEmpty(newID))
                throw new ArgumentException("New name cannot be null or empty", nameof(newID));

            Xnode node = getNode(nodePath, create: false);
            if (node == null)
                throw new InvalidOperationException($"Node at '{nodePath ?? ""}' does not exist");

            if (node.Parent != null && node.Parent.GetChild(newID) != null)
                throw new InvalidOperationException($"ID '{newID}' already exists.");

            // Invalidate all paths under the old name
            if (_cache != null)
                _cache.Invalidate(nodePath);

            string oldID = node.ID;

            // Perform the rename
            try 
            { 
                node.Rename(newID);
                if (_debugID != null)
                    Utilities.Log(_debugID, $"RENAMED: ID: '{oldID}' --> '{newID}' | Path: '{nodePath}'");
            }
            catch (InvalidOperationException ex) 
            { 
                throw new InvalidOperationException($"Failed to rename node: {ex.Message}"); 
            }
            
            // Update TreeView if initialized
            UpdateTreeView();
        }
        public string[] GetChildIDs(string nodePath = null)
        {
            Xnode node = getNode(nodePath, create: false);
            if (node == null)
                return null;

            return node.GetChildIDs();
        }
        public void SetValue(object value, string nodePath)
        {
            if (value == null || string.IsNullOrEmpty(Convert.ToString(value)))
            {
                DeleteNode(nodePath, "LEAF");
            }
            else
            {
                Xnode target = getNode(nodePath, create: true);
                if (target == null)
                    throw new InvalidOperationException($"Failed to create or navigate to node at '{nodePath}' (possibly due to a value node conflict)");
                string oldTag = target.Tag;
                target.SetValue(value);
                if (_debugID != null)
                {
                    string fullPath = normalizePath(nodePath);
                    if (oldTag.ToUpper() == "SEED")
                        oldTag = "SEED --> ";
                    else
                        oldTag = "";
                    Utilities.Log(_debugID, $"VALUE SET: Node ID: '{target.ID}' | Value: '{Regex.Replace(Convert.ToString(value), @"\s+", " ")}' | Tag: {oldTag + target.Tag.ToUpper()} | Path: '{fullPath}'");
                }
                //UpdateTreeView();  // Update TreeView if initialized
            }
        }
        public object GetValue(string nodepath)
        {
            Xnode node = getNode(nodepath, create: false);
            if (node == null || node.Tag != "LEAF")
                return null;

            return node.DataValue;
        }
        public void SetAttribute(string key, string value, string nodePath = null)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key cannot be null or empty", nameof(key));
            if (_reservedAttributes.Contains(key))
                throw new ArgumentException($"'{key}' is a reserved attribute name and cannot be set");
            Xnode node = getNode(nodePath, create: false);
            if (node == null)
                throw new InvalidOperationException($"Node at '{nodePath}' does not exist; attributes cannot be set on non-existent nodes");
            string fullPath = normalizePath(nodePath);
            if (!string.IsNullOrEmpty(value)) // if attribute value is not null, set it
            {
                node.SetAttribute(key, value);
                if (_debugID != null)
                    Utilities.Log(_debugID, $"ATTRIBUTE SET: ID: '{node.ID}' | Attribute: '{key}' | Value: '{value}' | Path: '{fullPath}'");
            }
            else if (node.ListAttributes().Contains(key))
            {
                node.RemoveAttribute(key);
                if (_debugID != null)
                    Utilities.Log(_debugID, $"ATTRIBUTE DELETED: ID: '{node.ID}' | Attribute: '{key}' | Path: '{fullPath}'");
            }
            // Update TreeView if initialized and the attribute is the filter attribute
            if (key == _attrFilter && _treeView != null)
            {
                UpdateTreeView();
            }
        }
        public string GetAttribute(string key, string nodePath = null)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentException("Key cannot be null or empty", nameof(key));

            Xnode node = getNode(nodePath, create: false);

            return node?.GetAttribute(key);

        }
        public void SetData(Dictionary<string, object> data, string nodePath = null)
        {
            if (data == null)
                throw new ArgumentException("Data dictionary cannot be null", nameof(data));
            // Pre-check for existing "BRANCH" nodes that conflict with keys
            Xnode existingNode = getNode(nodePath, create: false);
            if (existingNode != null)
            {
                foreach (string key in data.Keys)
                {
                    Xnode child = existingNode.GetChild(key);
                    if (child != null && child.Tag == "BRANCH")
                    {
                        throw new InvalidOperationException($"Cannot set data for '{key}' at '{nodePath}' because it is an existing branch node");
                    }
                }
            }
            // Navigate or create the target node
            Xnode target = getNode(nodePath, create: true);
            if (target == null)
                throw new InvalidOperationException($"Failed to create or navigate to node at '{nodePath}' (possibly due to a value node conflict)");
            // Set or create child nodes with the data
            string fullPath = normalizePath(nodePath);
            foreach (var kvp in data)
            {
                Xnode child = target.GetChild(kvp.Key);
                if (kvp.Value != null)
                {
                    if (child == null)
                    {
                        child = new Xnode(kvp.Key);
                        target.AddChild(child);
                    }
                    string tag = child.Tag.ToUpper();
                    child.SetValue(kvp.Value);
                    if (_debugID != null)
                        Utilities.Log(_debugID, $"VALUE SET: ID: {child.ID} | Value: '{kvp.Value}' | Tag: {tag} | Path: '{fullPath}/{child.ID}'");
                }
                else 
                {
                    DeleteNode(nodePath, "LEAF");
                }
            }
            UpdateTreeView(); // Update TreeView if initialized
        }
        public Dictionary<string, object> GetData(string nodePath = null)
        {
            Xnode node = getNode(nodePath);
            if (node == null)
                return null;
            var data = new Dictionary<string, object>();
            foreach (Xnode child in node.GetChildIDs().Select(id => node.GetChild(id)))
            {
                if (child.Tag == "LEAF" && child.DataValue != null)
                {
                    data[child.ID] = child.DataValue;
                }
            }
            return data.Count > 0 ? data : null;
        }
        public void DeleteNode(string nodePath, string tagFilter = null)
        {
            Xnode target = getNode(nodePath);
            if (target == null)
                return; // Nothing to delete
            if (!string.IsNullOrEmpty(tagFilter))
                if (target.Tag != tagFilter)
                    return; // Tag filter mismatch, exit
            if (target == _rootNode) // Prevent root deletion
                throw new InvalidOperationException("Cannot delete the root node");

            string tag = target.Tag.ToUpper();
            string ID = target.ID;
            string fullPath = normalizePath(nodePath);
            if (tag == "LEAF" || tag == "BRANCH" || tag == "SEED") // Delete only "LEAF" or "BRANCH" or "SEED" nodes
            {
                Xnode parent = target.Parent;
                target.Delete();
                if (_debugID != null)
                    Utilities.Log(_debugID, $"DELETED: Node ID: '{ID}' | Tag: {tag} | Path: '{fullPath}'");
                if (parent != null)
                    RefactorOrders(parent);
                _cache?.Invalidate(nodePath);
                UpdateTreeView(); // Update TreeView if initialized
            }
            else
            {
                throw new InvalidOperationException($"Node at '{fullPath}' with Tag '{tag}' cannot be deleted (must be 'value', 'branch' or 'seed')");
            }
        }
        public void Sprout(TreeStructure ts, string nodePath = null)
        {
            if (ts == null)
                throw new ArgumentException("Tree structure cannot be null", nameof(ts));

            // Navigate to the attachment point
            Xnode parentNode = getNode(nodePath, create: true);
            if (parentNode == null)
                throw new InvalidOperationException($"Failed to create or navigate to node at '{nodePath}' (possibly due to a value node conflict)");

            if (parentNode.Tag == "LEAF")
                throw new InvalidOperationException($"Cannot sprout a subtree under a value node at '{nodePath}'");

            // Build and attach the subtree
            Xnode newNode = buildSubtree(ts);
            parentNode.AddChild(newNode);
            RefactorOrders(parentNode);

            // Update TreeView if initialized
            UpdateTreeView();
        }
        public void Copy(string sourcePath, string destinationPath)
        {
            if (sourcePath == destinationPath)
                throw new InvalidOperationException("Source and destination paths cannot be the same");
            Xnode sourceNode = getNode(sourcePath, create: false);
            if (sourceNode == null)
                throw new InvalidOperationException($"Source node at '{sourcePath}' does not exist");
            // Check if destination already exists
            if (getNode(destinationPath, create: false) != null)
                throw new InvalidOperationException($"Destination node at '{destinationPath}' already exists");
            // Navigate to the parent of the destination
            string[] destinationIds = destinationPath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            string parentPath = string.Join("/", destinationIds.Take(destinationIds.Length - 1));
            Xnode parentNode = getNode(parentPath, create: true);
            if (parentNode == null)
                throw new InvalidOperationException($"Failed to create or navigate to parent node at '{parentPath}' (possibly due to a value node conflict)");

            if (parentNode.Tag == "LEAF")
                throw new InvalidOperationException($"Cannot create destination node at '{destinationPath}' because parent at '{parentPath}' is a value node");

            // Deep copy the source node and rename it
            Xnode copiedNode = sourceNode.DeepCopy();
            string newID = destinationIds.Last();
            copiedNode.Rename(newID);

            if (copiedNode.ListAttributes().Contains("order"))
            {
                // Update the order attribute if it exists
                var orders = getOrders(parentNode);
                foreach (var order in orders)
                {
                    if (order.Value >= Convert.ToInt32(copiedNode.GetAttribute("order")))
                    {
                        copiedNode.SetAttribute("order", (order.Value + 1).ToString());
                    }
                }
            }

            // Add the copy to the destination parent
            parentNode.AddChild(copiedNode);

            if (_debugID != null) Utilities.Log(_debugID, $"COPIED: Node ID: '{sourceNode.ID}' --> '{newID}' | Path: '{sourcePath}' --> '{destinationPath}'");

            // Update TreeView if initialized
            UpdateTreeView();
        }
        public Dictionary<string, int?> GetOrders(string nodePath)
        {
            Xnode node = getNode(nodePath);
            Dictionary<string, int?> orderDict = getOrders(node);
            return orderDict;
        }
        public void ReOrder(int jumps, string nodepath)
        {
            if (String.IsNullOrEmpty(nodepath)) throw new ArgumentException("Node path cannot be null or empty", nameof(nodepath));
            if (jumps == 0) return;
            Xnode node = getNode(nodepath);
            if (node == null) throw new InvalidOperationException($"Node at '{nodepath}' does not exist");
            reOrder(node, jumps, nodepath);
        }
        public void ReportCacheSuccess()
        {
            if (_cache != null)
                MessageBox.Show("Cache success rate: " + Convert.ToString(Math.Round(_cache.GetHitPercentage(), 2)) + "%");
            else
                MessageBox.Show("No cache initialized for this Xmanager instance.");
        }
        public string GetUniqueID(string baseID, string nodePath)
        {
            Xnode node = getNode(nodePath, create: false);
            if (node == null) return baseID;
            return getUniqueID(node, baseID);
        }
        private void RefactorOrders(Xnode node)
        {
            Dictionary<string, int?> orders = new Dictionary<string, int?>();
            foreach(string childID in node.GetChildIDs())
            {
                string order = node.GetChild(childID).GetAttribute("order");
                orders.Add(childID, string.IsNullOrEmpty(order) ? (int?)null : Convert.ToInt32(order));
            }

            // Separate into three groups: regular numbers, -1 values, and nulls
            var regularPairs = orders
                .Where(pair => pair.Value.HasValue && pair.Value != -1)
                .OrderBy(pair => pair.Value.Value)
                .ToList();

            var minusOneKeys = orders
                .Where(pair => pair.Value == -1)
                .Select(pair => pair.Key)
                .ToList();

            // Reassign consecutive values starting from 1 for regular numbers
            for (int i = 0; i < regularPairs.Count; i++)
            {
                orders[regularPairs[i].Key] = i + 1;
            }

            // Assign consecutive values to -1 entries, continuing from the last regular number
            int currentValue = regularPairs.Count + 1;
            foreach (var key in minusOneKeys)
            {
                orders[key] = currentValue;
                currentValue++;
            }

            foreach (var kvp in orders)
            {
                string value = Convert.ToString(kvp.Value);
                if (!string.IsNullOrEmpty(value))
                    node.GetChild(kvp.Key).SetAttribute("order", value);
            }
        }
    }
    public class TreeStructure
    {
        public string ID { get; set; }
        public object Value { get; set; } // Null for branch nodes with children
        public Dictionary<string, string> Attributes { get; set; }
        public List<TreeStructure> Children { get; set; } = new List<TreeStructure>();
        public TreeStructure(string id, object value = null, Dictionary<string, string> attributes = null)
        {
            ID = id;
            Value = value;
            Attributes = attributes ?? new Dictionary<string, string>();
        }
    }
}




