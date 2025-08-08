using Sinuosity.Common;
using Sinuosity.Forms.Custom_Controls;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sinuosity.Forms
{

    class EditorFormTransactionManager
    {
        public string ThisID { get; private set; }
        public string ThisPath { get; private set; }
        public string ParentID { get; private set; } //parent ID of the TREE node 
        //public string? ParentPath { get; private set; }
        private string ParentPath;
        public TextBox IDbox { get; private set; }
        private UserControl editorControl;
        private TreeView treeViewControl;
        private ListBox listBoxControl;
        private List<object> taggedControlList = new List<object>();
        private Dictionary<object, Action<object>> eventHandlers = new Dictionary<object, Action<object>>();
        private List<Keys> entryKeys = new List<Keys> { Keys.Enter, Keys.Tab };
        private int ListBoxLastSelectedIndex = -1;
        private TreeNode thisTreeNode;
        private string thisTreeNodePath;
        private string parentTreeNodePath;

        public EditorFormTransactionManager(string nodePath, UserControl editorForm, TreeView treeView, TextBox idBox, ListBox listBox = null)
        {
            editorControl = editorForm;
            treeViewControl = treeView;
            listBoxControl = listBox;
            IDbox = idBox;

            thisTreeNode = treeViewControl.SelectedNode;
            thisTreeNodePath = thisTreeNode.FullPath;

            parentTreeNodePath = thisTreeNode.Parent != null ? thisTreeNode.Parent.FullPath : "";
            ParentID = thisTreeNode.Parent != null ? thisTreeNode.Parent.Text : "";

            ThisPath = nodePath;
            ThisID = ProjectManager.Project.GetID(nodePath);
            string[] pathIDs = nodePath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            ParentPath = $"/{string.Join("/", pathIDs.Take(pathIDs.Length - 1))}";
        }
        public void ListBox_Leave()
        {
            ListBoxLastSelectedIndex = listBoxControl.SelectedIndex;
            //listBoxControl.ClearSelected();
        }
        public void TreeView_Back()
        {
            // Split the full path into individual node names
            string[] pathParts = parentTreeNodePath.Split(treeViewControl.PathSeparator.ToCharArray());
            // Start from the root nodes
            TreeNodeCollection nodes = treeViewControl.Nodes;
            TreeNode currentNode = null;
            // Traverse through each level of the path
            foreach (string part in pathParts)
            {
                currentNode = null;
                // Search current level for matching node
                foreach (TreeNode node in nodes)
                {
                    if (node.Text == part)
                    {
                        currentNode = node;
                        nodes = node.Nodes; // Move to next level
                        break;
                    }
                }
                // If no matching node is found, return null
                if (currentNode == null)
                {
                    throw new InvalidOperationException("Unable to find node in tree view");
                }
            }
            treeViewControl.SelectedNode = currentNode;
            currentNode.EnsureVisible(); // Scrolls to make the node visible
        }
        public void ListBox_GoToItem()
        {
            if (ListBoxLastSelectedIndex != -1)
            {
                listBoxControl.SelectedIndex = ListBoxLastSelectedIndex;
                string containerPath = GetFullPath(listBoxControl.Tag);
                string targetID = ((TaggedListBoxItem)listBoxControl.SelectedItem).Tag.ToString().Split('/').Last();

                // Split the full path into individual node names
                string[] pathParts = thisTreeNodePath.Split(treeViewControl.PathSeparator.ToCharArray());

                // Start from the root nodes
                TreeNodeCollection nodes = treeViewControl.Nodes;
                TreeNode currentNode = null;
                // Traverse through each level of the path
                foreach (string part in pathParts)
                {
                    currentNode = null;
                    // Search current level for matching node
                    foreach (TreeNode node in nodes)
                    {
                        if (node.Text == part)
                        {
                            currentNode = node;
                            nodes = node.Nodes; // Move to next level
                            break;
                        }
                    }
                    // If no matching node is found, return null
                    if (currentNode == null)
                    {
                        throw new InvalidOperationException("Unable to find node in tree view");
                    }
                }
                int targetIndex = -1;
                for (int i = 0; i < (currentNode.Nodes.Count); i++)
                {
                    if (currentNode.Nodes[i].Text == targetID)
                    {
                        targetIndex = i;
                        break;
                    }
                }
                treeViewControl.SelectedNode = currentNode.Nodes[targetIndex];
            }
        }
        public void ListBox_SplitItem()
        {
            if (ListBoxLastSelectedIndex != -1)
            {
                listBoxControl.SelectedIndex = ListBoxLastSelectedIndex;
                string ID_A = ((TaggedListBoxItem)listBoxControl.SelectedItem).Tag.ToString().Split('/').Last();
                string newID = Utilities.PromptForString($"Enter a name for the new item which will be split from {ThisID}-{ID_A}.");
                if (!(string.IsNullOrEmpty(newID)))
                {
                    string path_A = $"{GetFullPath(listBoxControl.Tag)}/{ID_A}";
                    string[] path_A_IDs = path_A.Split('/');
                    string ID_B = ProjectManager.Project.GetUniqueID(newID, string.Join("/", path_A_IDs.Take(path_A_IDs.Length - 1)));
                    string path_B = $"{string.Join("/", path_A_IDs.Take(path_A_IDs.Length - 1).ToArray())}/{ID_B}";
                    ProjectManager.Project.Copy(path_A, path_B);
                    int order_B = Convert.ToInt32(ProjectManager.Project.GetAttribute("order", path_B));
                    int order_A = Convert.ToInt32(ProjectManager.Project.GetAttribute("order", path_A));
                    ProjectManager.Project.ReOrder(order_B - order_A - 1, path_B);
                    ListBox_Repopulate();
                }
            }
        }
        public void ListBox_CopyItem()
        {
            if (ListBoxLastSelectedIndex != -1)
            {
                listBoxControl.SelectedIndex = ListBoxLastSelectedIndex;
                string ID_A = ((TaggedListBoxItem)listBoxControl.SelectedItem).Tag.ToString().Split('/').Last();
                string newID = Utilities.PromptForString($"Enter a name for the new item which will be copied from {ID_A}.");
                if (!(string.IsNullOrEmpty(newID)))
                {
                    string path_A = $"{GetFullPath(listBoxControl.Tag)}/{ID_A}";
                    string[] path_A_IDs = path_A.Split('/');
                    string ID_B = ProjectManager.Project.GetUniqueID(newID, string.Join("/", path_A_IDs.Take(path_A_IDs.Length - 1)));
                    string path_B = $"{string.Join("/", path_A_IDs.Take(path_A_IDs.Length - 1).ToArray())}/{ID_B}";
                    ProjectManager.Project.Copy(path_A, path_B);
                    ListBox_Repopulate();
                }
            }
        }
        public void ListBox_MoveItem(bool moveUp, bool fullMove = false)
        {
            listBoxControl.SelectedIndex = ListBoxLastSelectedIndex;

            if ((moveUp && listBoxControl.SelectedIndex > 0) || (!moveUp && listBoxControl.SelectedIndex < listBoxControl.Items.Count - 1)) 
            {
                if (fullMove) swapItems(moveUp);
                else swapName(moveUp);
                ListBox_Repopulate();
                ListBoxLastSelectedIndex += (moveUp ? -1 : 1);
            }
            listBoxControl.SelectedIndex = ListBoxLastSelectedIndex;
            listBoxControl.Focus();
        }
        private void swapItems(bool moveUp)
        {
            TaggedListBoxItem selectedItem = (TaggedListBoxItem)listBoxControl.SelectedItem;
            if (selectedItem != null)
            {
                string containerPath = GetFullPath(listBoxControl.Tag); 
                string nodeID = selectedItem.Tag.ToString().Split('/').Last();
                string nodePath = $"{containerPath}/{nodeID}";
                if (string.IsNullOrEmpty(ProjectManager.Project.GetID(nodePath))) throw new InvalidOperationException("Unable to retrieve valid node from ListBox tag");
                ProjectManager.Project.ReOrder(moveUp ? 1 : -1, nodePath);
            }
        }
        private void swapName(bool moveUp)
        {
            string containerPath = GetFullPath(listBoxControl.Tag);

            TaggedListBoxItem selectedItem = (TaggedListBoxItem)listBoxControl.SelectedItem;
            string ID_A = selectedItem.Tag.ToString().Split('/').Last();
            string path_A = $"{containerPath}/{ID_A}";
            string[] pathParts_A = path_A.Split('/');

            TaggedListBoxItem adjacentItem = ((TaggedListBoxItem)listBoxControl.Items[listBoxControl.SelectedIndex + (moveUp ? -1 : 1)]);
            string ID_B = adjacentItem.Tag.ToString().Split('/').Last();
            string path_B = $"{containerPath}/{ID_B}";

            string temp_ID_A = ProjectManager.Project.GetUniqueID($"{ID_A}_TEMP", $"{string.Join("/", pathParts_A.Take(pathParts_A.Length - 1))}");
            ProjectManager.Project.SetID(temp_ID_A, path_A);
            ProjectManager.Project.SetID(ID_A, path_B);
            ProjectManager.Project.SetID(ID_B, $"{string.Join("/", pathParts_A.Take(pathParts_A.Length - 1))}/{temp_ID_A}");
        }
        public void ListBox_Repopulate()
        {
            if (listBoxControl == null) return;
            string nodePath = GetFullPath(listBoxControl.Tag);
            List<string> childIDs = ProjectManager.Project.GetChildIDs(nodePath).ToList();
            //Dictionary<string, int?> orderDict = new Dictionary<string, int?>();
            listBoxControl.Items.Clear();
            foreach (string childID in childIDs)
            {
                string order = ProjectManager.Project.GetAttribute("order", $"{nodePath}/{childID}");
                string displayName = string.IsNullOrEmpty(order) ? childID : $"{order} - {childID}";
                TaggedListBoxItem lbi = new TaggedListBoxItem(displayName, $"/{childID}");
                listBoxControl.Items.Add(lbi);
            }
        }
        public void ListBox_AddItem(Type treeStructureType, string prompt)
        {
            string nodePath = GetFullPath(listBoxControl.Tag);
            string newID = Utilities.PromptForString(prompt);
            if (!(string.IsNullOrEmpty(newID)))
            {
                newID = ProjectManager.Project.GetUniqueID(newID, nodePath);
                // Create a new instance of the specified type
                var newInstance = Activator.CreateInstance(treeStructureType, newID);
                ProjectManager.Project.Sprout((TreeStructure)newInstance, nodePath);
            }
            ListBox_Repopulate();
        }
        public void ListBox_RemoveItem()
        {
            listBoxControl.SelectedIndex = ListBoxLastSelectedIndex;
            TaggedListBoxItem selectedItem = (TaggedListBoxItem)listBoxControl.SelectedItem;
            if (selectedItem != null)
            {
                string ID = selectedItem.Tag.ToString().Split('/').Last();
                DialogResult result = MessageBox.Show($"Are you sure you want to delete {ID}? This cannot be undone.", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    ProjectManager.Project.DeleteNode($"{GetFullPath(listBoxControl.Tag)}/{ID}");
                    ListBox_Repopulate();
                }
            }
            ListBoxLastSelectedIndex = listBoxControl.SelectedIndex;
        }
        public string GetFullPath(object tagPath)
        {
            string basePath = string.Join("/", ThisPath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries));
            string subPath = string.Join("/", ((string)tagPath).Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries));
            return $"{basePath}/{subPath}";
        }
        public string GetAncestorID(int levels)
        {
            string[] pathParts = ThisPath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            return pathParts[pathParts.Length - levels];
        }
        public void AddDataEntryControl(object control)
        {
            taggedControlList.Add(control);
        }
        public void RegisterEventHandler(object sender, Action<object> callback)
        {
            eventHandlers[sender] = callback;
        }
        public void RestoreData(object sender, EventArgs e)
        {
            if (sender == (object)IDbox)
            {
                IDbox.Text = ThisID;
                return;
            }

            // Cast sender to Control and check if it's in our list
            if (!(sender is Control control) || !taggedControlList.Contains(control)) return;

            // Handle different control types with a generic method
            if (RestoreControlType<TextBox>(control, c => c.Text = GetValueAsString(c.Tag ?? string.Empty))) return;
            if (RestoreControlType<ValueInput_Station>(control, c => c.Value = GetValueAsDecimal(c.Tag ?? string.Empty))) return;
            if (RestoreControlType<ValueInput_Static_Length>(control, c => c.Value = GetValueAsDecimal(c.Tag ?? string.Empty))) return;
            if (RestoreControlType<ValueInput_Static_Area>(control, c => c.Value = GetValueAsDecimal(c.Tag ?? string.Empty))) return;
            if (RestoreControlType<ValueInput_Static_Volume>(control, c => c.Value = GetValueAsDecimal(c.Tag ?? string.Empty))) return;
            if (RestoreControlType<ValueInput_Static_Angle>(control, c => c.Value = GetValueAsDecimal(c.Tag ?? string.Empty))) return;
            if (RestoreControlType<ValueInput_Static_Slope>(control, c => c.Value = GetValueAsDecimal(c.Tag ?? string.Empty))) return;
            if (RestoreControlType<ValueInput_Variable_Length>(control, c => { c.Value = GetValueAsDecimal(c.Tag ?? string.Empty); c.Unit = GetUnit<UnitLength>(c.Tag ?? string.Empty); })) return;
            if (RestoreControlType<ValueInput_Variable_Area>(control, c => { c.Value = GetValueAsDecimal(c.Tag ?? string.Empty); c.Unit = GetUnit<UnitArea>(c.Tag ?? string.Empty); })) return;
            if (RestoreControlType<ValueInput_Variable_Volume>(control, c => { c.Value = GetValueAsDecimal(c.Tag ?? string.Empty); c.Unit = GetUnit<UnitVolume>(c.Tag ?? string.Empty); })) return;
            if (RestoreControlType<ValueInput_Variable_Angle>(control, c => { c.Value = GetValueAsDecimal(c.Tag ?? string.Empty); c.Unit = GetUnit<UnitAngle>(c.Tag ?? string.Empty); })) return;
            if (RestoreControlType<ValueInput_Variable_Slope>(control, c => { c.Value = GetValueAsDecimal(c.Tag ?? string.Empty); c.Unit = GetUnit<UnitSlope>(c.Tag ?? string.Empty); })) return;
        }
        private bool RestoreControlType<T>(object control, Action<T> setValueAction) where T : Control
        {
            if (control is T typedControl && !string.IsNullOrEmpty(Convert.ToString(typedControl.Tag)))
            {
                setValueAction(typedControl);
                return true;
            }
            return false;
        }
        // Helper methods
        private string GetValueAsString(object tag)
        {
            object data = ProjectManager.Project.GetValue(GetFullPath(tag));
            return data?.ToString() ?? string.Empty;
        }

        private decimal? GetValueAsDecimal(object tag)
        {
            object data = ProjectManager.Project.GetValue(GetFullPath(tag));
            return data != null ? (decimal?)Convert.ToDecimal(data) : null;
        }
        private T GetUnit<T>(object tag) where T : class
        {
            string unit = ProjectManager.Project.GetAttribute("unit", GetFullPath(tag));
            return unit != null && Units.GetUnits<T>().TryGetValue(unit, out T value) ? value : null;
        }
        public bool EnterData(object sender, bool triggerEvents = true, KeyEventArgs e = null, ValueValidator validator = null)
        {
            bool result = false;
            if (e == null || entryKeys.Contains(e.KeyCode))
            {
                // Handle IDbox (TextBox for ID)
                if (sender == (object)IDbox)
                {
                    string oldID = ThisID;
                    string input = IDbox.Text;
                    if (input != oldID)
                    {
                        try
                        {
                            ProjectManager.Project.SetID(input, ThisPath);
                            ThisID = input;
                            ThisPath = $"{ParentPath}/{ThisID}";
                            result = true;
                        }
                        catch (InvalidOperationException ex)
                        {
                            MessageBox.Show($"Unable to set ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            IDbox.Text = oldID; // Restore original value
                        }
                    }
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                    editorControl.SelectNextControl((Control)IDbox, true, true, true, true);
                }
                // Handle tagged controls
                else if (taggedControlList.Contains(sender))
                {
                    if (sender is TextBox textBox)
                    {
                        result = EnterControlType<TextBox>(textBox, validator, c =>
                        {
                            ProjectManager.Project.SetValue(c.Text, GetFullPath(c.Tag));
                        });
                    }
                    else if (EnterControlType<ValueInput_Station, UnitLength>(sender, validator,
                        c => c.Value, c => c.Unit, (path, value, unit) =>
                        {
                            ProjectManager.Project.SetValue(value, path);
                            if (ProjectManager.Project.GetID(path) != null)
                                ProjectManager.Project.SetAttribute("unit", Convert.ToString(unit), path);
                        })) result = true;
                    else if (EnterControlType<ValueInput_Static_Length, UnitLength>(sender, validator,
                        c => c.Value, c => c.Unit, (path, value, unit) =>
                        {
                            ProjectManager.Project.SetValue(value, path);
                            if (ProjectManager.Project.GetID(path) != null)
                                ProjectManager.Project.SetAttribute("unit", Convert.ToString(unit), path);
                        })) result = true;
                    else if (EnterControlType<ValueInput_Static_Area, UnitArea>(sender, validator,
                        c => c.Value, c => c.Unit, (path, value, unit) =>
                        {
                            ProjectManager.Project.SetValue(value, path);
                            if (ProjectManager.Project.GetID(path) != null)
                                ProjectManager.Project.SetAttribute("unit", Convert.ToString(unit), path);
                        })) result = true;
                    else if (EnterControlType<ValueInput_Static_Volume, UnitVolume>(sender, validator,
                        c => c.Value, c => c.Unit, (path, value, unit) =>
                        {
                            ProjectManager.Project.SetValue(value, path);
                            if (ProjectManager.Project.GetID(path) != null)
                                ProjectManager.Project.SetAttribute("unit", Convert.ToString(unit), path);
                        })) result = true;
                    else if (EnterControlType<ValueInput_Static_Angle, UnitAngle>(sender, validator,
                        c => c.Value, c => c.Unit, (path, value, unit) =>
                        {
                            ProjectManager.Project.SetValue(value, path);
                            if (ProjectManager.Project.GetID(path) != null)
                                ProjectManager.Project.SetAttribute("unit", Convert.ToString(unit), path);
                        })) result = true;
                    else if (EnterControlType<ValueInput_Static_Slope, UnitSlope>(sender, validator,
                        c => c.Value, c => c.Unit, (path, value, unit) =>
                        {
                            ProjectManager.Project.SetValue(value, path);
                            if (ProjectManager.Project.GetID(path) != null)
                                ProjectManager.Project.SetAttribute("unit", Convert.ToString(unit), path);
                        })) result = true;
                    else if (EnterControlType<ValueInput_Variable_Length, UnitLength>(sender, validator,
                        c => c.Value, c => c.Unit, (path, value, unit) =>
                        {
                            ProjectManager.Project.SetValue(value, path);
                            if (ProjectManager.Project.GetID(path) != null)
                                ProjectManager.Project.SetAttribute("unit", Convert.ToString(unit), path);
                        })) result = true;
                    else if (EnterControlType<ValueInput_Variable_Area, UnitArea>(sender, validator,
                        c => c.Value, c => c.Unit, (path, value, unit) =>
                        {
                            ProjectManager.Project.SetValue(value, path);
                            if (ProjectManager.Project.GetID(path) != null)
                                ProjectManager.Project.SetAttribute("unit", Convert.ToString(unit), path);
                        })) result = true;
                    else if (EnterControlType<ValueInput_Variable_Volume, UnitVolume>(sender, validator,
                        c => c.Value, c => c.Unit, (path, value, unit) =>
                        {
                            ProjectManager.Project.SetValue(value, path);
                            if (ProjectManager.Project.GetID(path) != null)
                                ProjectManager.Project.SetAttribute("unit", Convert.ToString(unit), path);
                        })) result = true;
                    else if (EnterControlType<ValueInput_Variable_Angle, UnitAngle>(sender, validator,
                        c => c.Value, c => c.Unit, (path, value, unit) =>
                        {
                            ProjectManager.Project.SetValue(value, path);
                            if (ProjectManager.Project.GetID(path) != null)
                                ProjectManager.Project.SetAttribute("unit", Convert.ToString(unit), path);
                        })) result = true;
                    else if (EnterControlType<ValueInput_Variable_Slope, UnitSlope>(sender, validator,
                        c => c.Value, c => c.Unit, (path, value, unit) =>
                        {
                            ProjectManager.Project.SetValue(value, path);
                            if (ProjectManager.Project.GetID(path) != null)
                                ProjectManager.Project.SetAttribute("unit", Convert.ToString(unit), path);
                        })) result = true;
                }

                // Trigger event handler if successful
                if (result && eventHandlers.ContainsKey(sender) && triggerEvents)
                {
                    eventHandlers[sender](sender);
                }
            }

            // Post-processing
            if (result)
            {
                if (e != null)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                editorControl.SelectNextControl((Control)sender, true, true, true, true);
            }
            return result;
        }

        // Generic method to handle TextBox-like controls
        private bool EnterControlType<T>(T control, ValueValidator validator, Action<T> setValueAction)
            where T : TextBox
        {
            string nodePath = GetFullPath(control.Tag);
            string input = control.Text;
            object oldValue = ProjectManager.Project.GetValue(nodePath);
            string oldValueString = Convert.ToString(oldValue);

            if (input == oldValueString) return false; // No change, exit early

            try
            {
                if (validator == null)
                {
                    setValueAction(control);
                    return true;
                }
                else if (validator.Validate(input, out object parsedValue))
                {
                    ProjectManager.Project.SetValue(parsedValue, nodePath);
                    return true;
                }
                else
                {
                    MessageBox.Show(validator.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    control.Text = oldValueString; // Restore original value
                    return false;
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Invalid value: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                control.Text = oldValueString; // Restore original value
                return false;
            }
        }

        // Generic method to handle ValueInput_Variable_* controls with units
        private bool EnterControlType<TControl, TUnit>(object sender, ValueValidator validator,
            Func<TControl, decimal?> getValueFunc, Func<TControl, TUnit> getUnitFunc,
            Action<string, decimal?, TUnit> setValueAction)
            where TControl : Control
            where TUnit : class
        {
            if (!(sender is TControl control) || string.IsNullOrEmpty(Convert.ToString(control.Tag)))
                return false;

            string nodePath = GetFullPath(control.Tag);
            decimal? newValue = getValueFunc(control);
            TUnit newUnit = getUnitFunc(control);
            string newValueString = Convert.ToString(newValue);
            decimal oldValue = Convert.ToDecimal(ProjectManager.Project.GetValue(nodePath) ?? 0m);
            string oldValueString = Convert.ToString(oldValue);
            string oldUnitString = ProjectManager.Project.GetAttribute("unit", nodePath);
            TUnit oldUnit = oldUnitString != null && Units.GetUnits<TUnit>().TryGetValue(oldUnitString, out TUnit unit) ? unit : null;

            // Check if there's a change
            if (newValueString == oldValueString && newUnit?.ToString() == oldUnit?.ToString())
                return false;

            ValueValidator dv = validator ?? new DecimalValidator();
            if (dv.Validate(Convert.ToString(newValue), out object parsedValue))
            {
                try
                {
                    setValueAction(nodePath, newValue, newUnit);
                    return true;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show($"Invalid value: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RestoreData(control, new EventArgs()); ;
                    return false;
                }
            }
            else
            {
                MessageBox.Show(dv.ErrorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RestoreData(control, new EventArgs());
                return false;
            }
        }
        public void UpdateControls()
        {
            IDbox.Text = ThisID;
            foreach (Control c in taggedControlList)
            {
                RestoreData(c, new EventArgs());
            }
        }
    }
}
