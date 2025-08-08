using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using System.Text;


public class DictionaryListManager
{
    private List<Dictionary<string, string>> _dictionaries;
    private HashSet<string> _allKeys;

    public DictionaryListManager()
    {
        _dictionaries = new List<Dictionary<string, string>>();
        _allKeys = new HashSet<string>();
    }

    // Add a dictionary to the list and update the key set
    public void Add(Dictionary<string, string> dictionary)
    {
        if (dictionary == null)
            throw new ArgumentNullException(nameof(dictionary));

        _dictionaries.Add(new Dictionary<string, string>(dictionary));
        _allKeys.UnionWith(dictionary.Keys);
    }

    // Remove a dictionary by reference
    public bool Remove(Dictionary<string, string> dictionary)
    {
        bool removed = _dictionaries.Remove(dictionary);
        if (removed)
        {
            UpdateAllKeys();
        }
        return removed;
    }

    // Remove dictionaries matching a condition on a key-value pair
    public int RemoveWhere(string key, Func<string, bool> predicate)
    {
        int initialCount = _dictionaries.Count;
        _dictionaries.RemoveAll(dict => dict.ContainsKey(key) && predicate(dict[key]));
        if (_dictionaries.Count < initialCount)
        {
            UpdateAllKeys();
        }
        return initialCount - _dictionaries.Count;
    }

    // Filter dictionaries by a key-value condition
    public IEnumerable<Dictionary<string, string>> Filter(string key, Func<string, bool> predicate)
    {
        return _dictionaries
            .Where(dict => dict.ContainsKey(key) && predicate(dict[key]))
            .Select(dict => new Dictionary<string, string>(dict));
    }

    // Sort dictionaries by a key (ascending or descending)
    public IEnumerable<Dictionary<string, string>> Sort(string key, bool descending = false)
    {
        if (!_allKeys.Contains(key))
            return _dictionaries.Select(dict => new Dictionary<string, string>(dict));

        return descending
            ? _dictionaries
                .OrderByDescending(dict => dict.TryGetValue(key, out var value) ? value : null, StringComparer.Ordinal)
                .Select(dict => new Dictionary<string, string>(dict))
            : _dictionaries
                .OrderBy(dict => dict.TryGetValue(key, out var value) ? value : null, StringComparer.Ordinal)
                .Select(dict => new Dictionary<string, string>(dict));
    }

    // Slice the list (e.g., for pagination)
    public IEnumerable<Dictionary<string, string>> Slice(int start, int count)
    {
        return _dictionaries
            .Skip(start)
            .Take(count)
            .Select(dict => new Dictionary<string, string>(dict));
    }

    // Get all dictionaries
    public IEnumerable<Dictionary<string, string>> All()
    {
        return _dictionaries.Select(dict => new Dictionary<string, string>(dict));
    }

    // Get all keys used across dictionaries
    public IReadOnlyCollection<string> GetAllKeys()
    {
        return _allKeys.ToList().AsReadOnly();
    }

    // Export to CSV file
    public void ExportToCsv(string filePath)
    {
        var csvLines = new List<string>();
        var keys = _allKeys.OrderBy(k => k).ToList();

        var header = string.Join(",", keys.Select(k => $"\"{k.Replace("\"", "\"\"")}\""));
        csvLines.Add(header);

        foreach (var dict in _dictionaries)
        {
            var rowValues = keys.Select(key =>
            {
                if (dict.TryGetValue(key, out var value) && value != null)
                {
                    return $"\"{value.Replace("\"", "\"\"")}\"";
                }
                return "";
            });
            csvLines.Add(string.Join(",", rowValues));
        }

        File.WriteAllLines(filePath, csvLines, Encoding.UTF8);
    }

    // Load from CSV file
    public void LoadFromCsv(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("CSV file not found.", filePath);

        var lines = File.ReadAllLines(filePath, Encoding.UTF8);
        if (lines.Length == 0)
            return;

        var headers = ParseCsvLine(lines[0]).Select(h => h.Trim()).ToList();
        if (!headers.Any())
            throw new InvalidOperationException("CSV file has no headers.");

        _dictionaries.Clear();
        _allKeys.Clear();
        _allKeys.UnionWith(headers);

        for (int i = 1; i < lines.Length; i++)
        {
            var values = ParseCsvLine(lines[i]).Select(v => v.Trim()).ToList();
            var dictionary = new Dictionary<string, string>();

            for (int j = 0; j < headers.Count && j < values.Count; j++)
            {
                var value = values[j];
                if (!string.IsNullOrEmpty(value))
                {
                    dictionary[headers[j]] = value;
                }
            }

            _dictionaries.Add(dictionary);
        }
    }

    // Helper method to parse a CSV line
    private IEnumerable<string> ParseCsvLine(string line)
    {
        var results = new List<string>();
        bool inQuotes = false;
        var currentField = new StringBuilder();

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (inQuotes)
            {
                if (c == '"' && i + 1 < line.Length && line[i + 1] == '"')
                {
                    currentField.Append('"');
                    i++;
                }
                else if (c == '"')
                {
                    inQuotes = false;
                }
                else
                {
                    currentField.Append(c);
                }
            }
            else
            {
                if (c == '"')
                {
                    inQuotes = true;
                }
                else if (c == ',')
                {
                    results.Add(currentField.ToString());
                    currentField.Clear();
                }
                else
                {
                    currentField.Append(c);
                }
            }
        }

        results.Add(currentField.ToString());
        return results;
    }

    // Helper method to recompute all keys
    private void UpdateAllKeys()
    {
        _allKeys.Clear();
        foreach (var dict in _dictionaries)
        {
            _allKeys.UnionWith(dict.Keys);
        }
    }
}