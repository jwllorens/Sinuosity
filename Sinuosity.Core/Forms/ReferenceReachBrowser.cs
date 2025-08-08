using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ScottPlot;
using SkiaSharp;

namespace Sinuosity.Forms
{
    using Sinuosity.Common;
    public partial class ReferenceReachBrowser : Form
    {
        private string lastPath = "";
        private DictionaryListManager listManager;
        private TextBox[] filterTextBoxes;
        private readonly string[] displayColumns = { "StreamName", "Ecoregion_LIV", "StreamType", "DrainageArea", "ChannelSlope" };
        private readonly string[] columnHeaders = { "Stream Name", "Ecoregion", "Stream Type", "Drainage Area (sq. mi.)", "Bankfull Slope (grade)" };
        private Dictionary<int, SortOrder> columnSortOrders = new Dictionary<int, SortOrder>();

        public ReferenceReachBrowser()
        {
            InitializeComponent();
            listManager = new DictionaryListManager();
            tb_FilePath.Text = Convert.ToString(ProjectManager.Configuration.GetValue("/Project/Reference Reach Database Path"));
            lastPath = tb_FilePath.Text;

            // Initialize filter textboxes from designer controls
            filterTextBoxes = new TextBox[] { tb_NameFilter, tb_EcoregionFilter, tb_StreamTypeFilter };
            for (int i = 0; i < filterTextBoxes.Length; i++)
            {
                filterTextBoxes[i].Tag = displayColumns[i];
                filterTextBoxes[i].TextChanged += FilterTextBox_TextChanged;
            }

            // Set AllowedUnits for custom controls
            vi_Filter_DrainageAreaMin.AllowedUnits = new List<string> { "mi²", "km²", "ac", "ft²", "m²" };
            vi_Filter_DrainageAreaMax.AllowedUnits = new List<string> { "mi²", "km²", "ac", "ft²", "m²" };
            vi_Filter_StreamSlopeMin.AllowedUnits = new List<string> { "grade", "Y/X", "degrees" };
            vi_Filter_StreamSlopeMax.AllowedUnits = new List<string> { "grade", "Y/X", "degrees" };

            // Initialize min/max filters to null
            vi_Filter_DrainageAreaMin.Value = null;
            vi_Filter_DrainageAreaMax.Value = null;
            vi_Filter_StreamSlopeMin.Value = null;
            vi_Filter_StreamSlopeMax.Value = null;

            // Attach events for custom controls
            vi_Filter_DrainageAreaMin.SelectedIndexChanged += ValueInput_Changed;
            vi_Filter_DrainageAreaMin.Leave += ValueInput_Changed;
            vi_Filter_DrainageAreaMax.SelectedIndexChanged += ValueInput_Changed;
            vi_Filter_DrainageAreaMax.Leave += ValueInput_Changed;
            vi_Filter_StreamSlopeMin.SelectedIndexChanged += ValueInput_Changed;
            vi_Filter_StreamSlopeMin.Leave += ValueInput_Changed;
            vi_Filter_StreamSlopeMax.SelectedIndexChanged += ValueInput_Changed;
            vi_Filter_StreamSlopeMax.Leave += ValueInput_Changed;

            InitializeListView();
            LoadCsvData();
        }

        private void InitializeListView()
        {
            listView.View = View.Details;
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.MultiSelect = false;
            listView.Columns.Clear();
            for (int i = 0; i < displayColumns.Length; i++)
            {
                listView.Columns.Add(columnHeaders[i], 150);
            }
            listView.SelectedIndexChanged += ListView_SelectedIndexChanged;
            listView.ColumnClick += ListView_ColumnClick;
        }

        private void LoadCsvData()
        {
            if (string.IsNullOrEmpty(tb_FilePath.Text) || !System.IO.File.Exists(tb_FilePath.Text))
            {
                listView.Items.Clear();
                formsPlot1.Plot.Clear();
                formsPlot1.Refresh();
                return;
            }

            try
            {
                listManager.LoadFromCsv(tb_FilePath.Text);
                RefreshListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading CSV file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshListView()
        {
            listView.Items.Clear();
            var dictionaries = listManager.All().ToList();
            Console.WriteLine($"Loaded {dictionaries.Count} records from listManager");
            FilterListView(dictionaries);
        }

        private void FilterListView(List<Dictionary<string, string>> dictionaries)
        {
            listView.Items.Clear();
            formsPlot1.Plot.Clear();

            var filteredDictionaries = dictionaries.Where(dict =>
            {
                // Text-based filters (StreamName, Ecoregion_LIV, StreamType)
                foreach (var textBox in filterTextBoxes)
                {
                    string column = (string)textBox.Tag;
                    string filterText = textBox.Text.Trim();

                    if (!string.IsNullOrEmpty(filterText))
                    {
                        if (column == "StreamType")
                        {
                            if (!dict.TryGetValue(column, out var value) || !MatchesStreamType(value, filterText))
                            {
                                return false;
                            }
                        }
                        else if (column == "Ecoregion_LIV")
                        {
                            if (!dict.TryGetValue(column, out var value) || !MatchesEcoregion(value, filterText))
                            {
                                return false;
                            }
                        }
                        else
                        {
                            if (!dict.TryGetValue(column, out var value) || !value.ToLower().Contains(filterText.ToLower()))
                            {
                                return false;
                            }
                        }
                    }
                }

                // Drainage Area filter (min/max, in mi²)
                if ((vi_Filter_DrainageAreaMin.Value.HasValue || vi_Filter_DrainageAreaMax.Value.HasValue) &&
                    dict.TryGetValue("DrainageArea", out var areaStr) &&
                    decimal.TryParse(areaStr, out var areaValue) &&
                    dict.TryGetValue("DrainageArea_Units", out var areaUnitStr))
                {
                    try
                    {
                        var areaUnit = Units.AreaUnits.Values.FirstOrDefault(u => u.ToString() == areaUnitStr);
                        if (areaUnit == null)
                        {
                            Console.WriteLine($"Invalid area unit: CSV={areaUnitStr}");
                            return true; // Skip filtering
                        }

                        var areaInMi2 = Units.ConvertArea(areaValue, areaUnit, Units.SquareMile);
                        const decimal tolerance = 0.0001m; // Handle floating-point precision

                        // Apply min filter if set
                        if (vi_Filter_DrainageAreaMin.Value.HasValue && vi_Filter_DrainageAreaMin.Unit != null)
                        {
                            var minUnit = Units.AreaUnits.Values.FirstOrDefault(u => u.ToString() == vi_Filter_DrainageAreaMin.Unit.ToString());
                            if (minUnit == null)
                            {
                                Console.WriteLine($"Invalid min area filter unit: {vi_Filter_DrainageAreaMin.Unit}");
                                return true; // Skip filtering
                            }
                            var minValue = Units.ConvertArea(vi_Filter_DrainageAreaMin.Value.Value, minUnit, Units.SquareMile);
                            if (areaInMi2 < minValue - tolerance) return false;
                        }

                        // Apply max filter if set
                        if (vi_Filter_DrainageAreaMax.Value.HasValue && vi_Filter_DrainageAreaMax.Unit != null)
                        {
                            var maxUnit = Units.AreaUnits.Values.FirstOrDefault(u => u.ToString() == vi_Filter_DrainageAreaMax.Unit.ToString());
                            if (maxUnit == null)
                            {
                                Console.WriteLine($"Invalid max area filter unit: {vi_Filter_DrainageAreaMax.Unit}");
                                return true; // Skip filtering
                            }
                            var maxValue = Units.ConvertArea(vi_Filter_DrainageAreaMax.Value.Value, maxUnit, Units.SquareMile);
                            if (areaInMi2 > maxValue + tolerance) return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Area filter error: {ex.Message}");
                        return true; // Skip filtering
                    }
                }

                // Channel Slope filter (min/max, in grade)
                if ((vi_Filter_StreamSlopeMin.Value.HasValue || vi_Filter_StreamSlopeMax.Value.HasValue) &&
                    dict.TryGetValue("ChannelSlope", out var slopeStr) &&
                    decimal.TryParse(slopeStr, out var slopeValue) &&
                    dict.TryGetValue("ChannelSlope_Units", out var slopeUnitStr))
                {
                    try
                    {
                        var slopeUnit = Units.SlopeUnits.Values.FirstOrDefault(u => u.ToString() == slopeUnitStr);
                        if (slopeUnit == null)
                        {
                            Console.WriteLine($"Invalid slope unit: CSV={slopeUnitStr}");
                            return true; // Skip filtering
                        }

                        var slopeInGrade = Units.ConvertSlope(slopeValue, slopeUnit, Units.SlopePercent);
                        const decimal tolerance = 0.0001m; // Handle floating-point precision

                        // Apply min filter if set
                        if (vi_Filter_StreamSlopeMin.Value.HasValue && vi_Filter_StreamSlopeMin.Unit != null)
                        {
                            var minUnit = Units.SlopeUnits.Values.FirstOrDefault(u => u.ToString() == vi_Filter_StreamSlopeMin.Unit.ToString());
                            if (minUnit == null)
                            {
                                Console.WriteLine($"Invalid min slope filter unit: {vi_Filter_StreamSlopeMin.Unit}");
                                return true; // Skip filtering
                            }
                            var minValue = Units.ConvertSlope(vi_Filter_StreamSlopeMin.Value.Value, minUnit, Units.SlopePercent);
                            if (slopeInGrade < minValue - tolerance) return false;
                        }

                        // Apply max filter if set
                        if (vi_Filter_StreamSlopeMax.Value.HasValue && vi_Filter_StreamSlopeMax.Unit != null)
                        {
                            var maxUnit = Units.SlopeUnits.Values.FirstOrDefault(u => u.ToString() == vi_Filter_StreamSlopeMax.Unit.ToString());
                            if (maxUnit == null)
                            {
                                Console.WriteLine($"Invalid max slope filter unit: {vi_Filter_StreamSlopeMax.Unit}");
                                return true; // Skip filtering
                            }
                            var maxValue = Units.ConvertSlope(vi_Filter_StreamSlopeMax.Value.Value, maxUnit, Units.SlopePercent);
                            if (slopeInGrade > maxValue + tolerance) return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Slope filter error: {ex.Message}");
                        return true; // Skip filtering
                    }
                }

                return true;
            }).ToList();

            Console.WriteLine($"Filtered to {filteredDictionaries.Count} records");

            // Populate ListView
            foreach (var dict in filteredDictionaries)
            {
                var item = new ListViewItem();
                item.Text = dict.TryGetValue(displayColumns[0], out var value0) ? value0 : "";
                for (int i = 1; i < displayColumns.Length; i++)
                {
                    string displayValue = "";
                    if (dict.TryGetValue(displayColumns[i], out var value))
                    {
                        if (displayColumns[i] == "DrainageArea" && dict.TryGetValue("DrainageArea_Units", out var areaUnitStr) &&
                            decimal.TryParse(value, out var areaValue))
                        {
                            try
                            {
                                var areaUnit = Units.AreaUnits.Values.FirstOrDefault(u => u.ToString() == areaUnitStr);
                                if (areaUnit != null)
                                {
                                    displayValue = Units.ConvertArea(areaValue, areaUnit, Units.SquareMile).ToString("F3");
                                }
                                else
                                {
                                    Console.WriteLine($"Invalid area unit for display: {areaUnitStr}");
                                    displayValue = value; // Fallback to raw value
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Area display error: {ex.Message}");
                                displayValue = value; // Fallback to raw value
                            }
                        }
                        else if (displayColumns[i] == "ChannelSlope" && dict.TryGetValue("ChannelSlope_Units", out var slopeUnitStr) &&
                            decimal.TryParse(value, out var slopeValue))
                        {
                            try
                            {
                                var slopeUnit = Units.SlopeUnits.Values.FirstOrDefault(u => u.ToString() == slopeUnitStr);
                                if (slopeUnit != null)
                                {
                                    displayValue = Units.ConvertSlope(slopeValue, slopeUnit, Units.SlopePercent).ToString("F2") + "%";
                                }
                                else
                                {
                                    Console.WriteLine($"Invalid slope unit for display: {slopeUnitStr}");
                                    displayValue = value; // Fallback to raw value
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Slope display error: {ex.Message}");
                                displayValue = value; // Fallback to raw value
                            }
                        }
                        else
                        {
                            displayValue = value;
                        }
                    }
                    item.SubItems.Add(displayValue);
                }
                item.Tag = dict;
                listView.Items.Add(item);
            }

            // Sort ListView based on current sort column (if any)
            if (columnSortOrders.Any())
            {
                var sortColumn = columnSortOrders.Keys.First();
                var sortOrder = columnSortOrders[sortColumn];
                listView.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortOrder);
                listView.Sort();
            }

            // Auto-size columns
            foreach (ColumnHeader column in listView.Columns)
            {
                column.Width = -2; // Auto-size to content
            }

            // Populate ScottPlot
            var xValues = new List<double>();
            var yValues = new List<double>();
            int skippedRecords = 0;

            foreach (var dict in filteredDictionaries)
            {
                try
                {
                    // Drainage Area (X-axis, mi²)
                    if (!dict.TryGetValue("DrainageArea", out var areaStr))
                    {
                        Console.WriteLine("Missing DrainageArea key in CSV");
                        skippedRecords++;
                        continue;
                    }
                    if (!decimal.TryParse(areaStr, out var areaValue))
                    {
                        Console.WriteLine($"Invalid DrainageArea value: {areaStr}");
                        skippedRecords++;
                        continue;
                    }
                    if (!dict.TryGetValue("DrainageArea_Units", out var areaUnitStr))
                    {
                        Console.WriteLine("Missing DrainageArea_Units key in CSV");
                        skippedRecords++;
                        continue;
                    }
                    // Normalize units
                    if (areaUnitStr == "square miles" || areaUnitStr == "mi2") areaUnitStr = "mi²";
                    if (areaUnitStr == "square kilometers" || areaUnitStr == "km2") areaUnitStr = "km²";

                    var areaUnit = Units.AreaUnits.Values.FirstOrDefault(u => u.ToString() == areaUnitStr);
                    if (areaUnit == null)
                    {
                        Console.WriteLine($"Invalid drainage area unit for plot: {areaUnitStr}");
                        skippedRecords++;
                        continue;
                    }
                    var areaInMi2 = Units.ConvertArea(areaValue, areaUnit, Units.SquareMile);

                    // Cross Sectional Area (Y-axis, ft²)
                    if (!dict.TryGetValue("CrossSectionArea", out var xsaStr))
                    {
                        Console.WriteLine("Missing CrossSectionArea key in CSV");
                        skippedRecords++;
                        continue;
                    }
                    if (!decimal.TryParse(xsaStr, out var xsaValue))
                    {
                        Console.WriteLine($"Invalid CrossSectionArea value: {xsaStr}");
                        skippedRecords++;
                        continue;
                    }
                    if (!dict.TryGetValue("CrossSectionArea_Units", out var xsaUnitStr))
                    {
                        Console.WriteLine("Missing CrossSectionArea_Units key in CSV");
                        skippedRecords++;
                        continue;
                    }
                    // Normalize units
                    if (xsaUnitStr == "square feet" || xsaUnitStr == "ft2") xsaUnitStr = "ft²";
                    if (xsaUnitStr == "square meters" || xsaUnitStr == "m²") xsaUnitStr = "m²";

                    var xsaUnit = Units.AreaUnits.Values.FirstOrDefault(u => u.ToString() == xsaUnitStr);
                    if (xsaUnit == null)
                    {
                        Console.WriteLine($"Invalid cross sectional area unit for plot: {xsaUnitStr}");
                        skippedRecords++;
                        continue;
                    }
                    var xsaInFt2 = Units.ConvertArea(xsaValue, xsaUnit, Units.SquareFoot);

                    xValues.Add((double)areaInMi2);
                    yValues.Add((double)xsaInFt2);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error plotting data for StreamName={(dict.ContainsKey("StreamName") ? dict["StreamName"] : "Unknown")}: {ex.Message}");
                    skippedRecords++;
                    continue;
                }
            }

            Console.WriteLine($"Plotting: {xValues.Count} points plotted, {skippedRecords} records skipped");

            if (xValues.Any())
            {
                // Scatter plot for data points
                var sp = formsPlot1.Plot.Add.Scatter(xValues.ToArray(), yValues.ToArray());
                sp.MarkerSize = 5;
                sp.LegendText = "Reference Reaches";
                sp.LineStyle = LineStyle.None;

                // Fit regional curve: A = a * D^b
                try
                {
                    var regression = RegressionUtilities.PowerLawRegression(xValues, yValues);
                    Console.WriteLine($"Regional Curve: A = {regression.Intercept:F3} * D^{regression.Coefficient:F3}, R² = {regression.RSquared:F3}");

                    // Plot the curve
                    var (curveX, curveY) = RegressionUtilities.GeneratePowerLawCurve(
                        regression.Intercept,
                        regression.Coefficient,
                        xValues.Min(),
                        xValues.Max(),
                        100
                    );

                    var curvePlot = formsPlot1.Plot.Add.Scatter(curveX, curveY);
                    curvePlot.Color = ScottPlot.Color.FromARGB(System.Drawing.Color.Red.ToArgb());
                    curvePlot.MarkerSize = 0; // No markers, just line
                    curvePlot.LegendText = "Regional Curve";

                    // Display the equation
                    string expression = $"A_(bkf) = {regression.Intercept:F1}DA^({regression.Coefficient:F3})   (R^(2) = {regression.RSquared:F3})";
                    mathExpressionPanel.Text = expression;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fitting regional curve: {ex.Message}");
                    mathExpressionPanel.Text = "";
                }

                // Configure plot labels with smaller font
                formsPlot1.Plot.XLabel("Drainage Area (sq. mi.)", 12);
                formsPlot1.Plot.YLabel("Bankfull Cross Sectional Area (sq. ft.)", 12);
                formsPlot1.Plot.Title("Cross Sectional Area vs. Drainage Area");
                formsPlot1.Plot.ShowLegend();
                formsPlot1.Plot.Axes.AutoScale();
            }
            else
            {
                Console.WriteLine("No valid data points to plot");
            }

            formsPlot1.Refresh();

            if (!filteredDictionaries.Any())
            {
                MessageBox.Show("No records match the current filters.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Define a custom IRenderAction to draw the image
        public class ImageRenderAction : ScottPlot.IRenderAction, IDisposable
        {
            private readonly SKBitmap skBitmap;
            private bool disposed = false;

            public ImageRenderAction(SKBitmap skBitmap)
            {
                this.skBitmap = skBitmap;
            }

            public void Render(ScottPlot.RenderPack renderPack)
            {
                if (disposed)
                    throw new ObjectDisposedException(nameof(ImageRenderAction));

                // Get the canvas to draw on
                var canvas = renderPack.Canvas;

                // Get the data area dimensions in pixels using DataRect
                var dataRect = renderPack.DataRect;
                float plotWidth = dataRect.Width;  // Width of the data area in pixels
                float plotHeight = dataRect.Height; // Height of the data area in pixels
                float dataLeft = dataRect.Left;    // Left edge of the data area in pixels
                float dataTop = dataRect.Top;      // Top edge of the data area in pixels

                // Estimate the image size in pixels
                float imageWidth = skBitmap.Width;
                float imageHeight = skBitmap.Height;

                // Calculate the top-right position relative to the data area (with some padding)
                float padding = 10; // Pixels of padding from the edges
                float xPos = dataLeft + plotWidth - imageWidth - padding; // Right edge of data area minus image width and padding
                float yPos = dataTop + padding; // Top edge of data area with padding

                // Draw the image on the canvas at the calculated position
                using (var paint = new SKPaint())
                {
                    canvas.DrawBitmap(skBitmap, xPos, yPos, paint);
                }
            }

            public void Dispose()
            {
                if (!disposed)
                {
                    skBitmap?.Dispose();
                    disposed = true;
                }
            }
        }

        private bool MatchesStreamType(string streamType, string filterText)
        {
            if (string.IsNullOrEmpty(streamType) || string.IsNullOrEmpty(filterText))
                return false;

            var filterTypes = filterText.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                        .Select(t => t.Trim().ToUpper())
                                        .Where(t => !string.IsNullOrEmpty(t))
                                        .ToList();

            if (!filterTypes.Any())
                return true; // No valid filter types, pass all

            streamType = streamType.ToUpper();
            foreach (var filterType in filterTypes)
            {
                if (filterType.Length == 1 && char.IsLetter(filterType[0]))
                {
                    // Broad classification (e.g., "C" matches "C", "Cb", "C3b")
                    if (streamType.StartsWith(filterType))
                        return true;
                }
                else if (filterType.Length == 2 && char.IsLetter(filterType[0]) && char.IsLetter(filterType[1]))
                {
                    // Letter + subtype (e.g., "Cb" matches "C3b", "C4b")
                    if (streamType.StartsWith(filterType[0].ToString()) && streamType.EndsWith(filterType[1].ToString()))
                        return true;
                }
                else if (filterType.Length >= 2 && char.IsLetter(filterType[0]) && char.IsDigit(filterType[1]))
                {
                    // Letter + number (e.g., "C3" matches "C3", "C3b")
                    if (streamType.StartsWith(filterType))
                        return true;
                }
                else if (filterType.Length >= 2 && filterType.All(c => char.IsLetter(c) || char.IsDigit(c)))
                {
                    // Exact match (e.g., "C3b" matches "C3b")
                    if (streamType == filterType)
                        return true;
                }
            }

            return false;
        }

        private bool MatchesEcoregion(string ecoregion, string filterText)
        {
            if (string.IsNullOrEmpty(ecoregion) || string.IsNullOrEmpty(filterText))
                return false;

            var filterEcoregions = filterText.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                            .Select(t => t.Trim().ToUpper())
                                            .Where(t => !string.IsNullOrEmpty(t))
                                            .ToList();

            if (!filterEcoregions.Any())
                return true; // No valid filter ecoregions, pass all

            ecoregion = ecoregion.ToUpper();
            foreach (var filterEcoregion in filterEcoregions)
            {
                // Level 3 ecoregion code (e.g., "47" matches "47", "47a")
                if (filterEcoregion.All(char.IsDigit))
                {
                    if (ecoregion.StartsWith(filterEcoregion))
                        return true;
                }
                // Level 4 ecoregion code (e.g., "47a" matches "47a")
                else if (filterEcoregion.Length >= 2 && filterEcoregion.Take(filterEcoregion.Length - 1).All(char.IsDigit) &&
                         char.IsLetter(filterEcoregion.Last()))
                {
                    if (ecoregion == filterEcoregion)
                        return true;
                }
            }

            return false;
        }

        private void FilterTextBox_TextChanged(object sender, EventArgs e)
        {
            RefreshListView();
        }

        private void ValueInput_Changed(object sender, EventArgs e)
        {
            Console.WriteLine($"ValueInput_Changed: AreaMin={vi_Filter_DrainageAreaMin.Value}, AreaMax={vi_Filter_DrainageAreaMax.Value}, SlopeMin={vi_Filter_StreamSlopeMin.Value}, SlopeMax={vi_Filter_StreamSlopeMax.Value}");
            RefreshListView();
        }

        private void ComboBox_Changed(object sender, EventArgs e)
        {
            RefreshListView();
        }

        private void btn_Path_ReferenceReach_Click(object sender, EventArgs e)
        {
            string lastPath = tb_FilePath.Text;
            if (string.IsNullOrEmpty(lastPath))
                lastPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            else
                lastPath = System.IO.Path.GetDirectoryName(lastPath);
            string fileName = Utilities.PromptForFile("Select reference reach CSV file.", "CSV Files (*.csv)|*.csv|All Files (*.*)|*.*", lastPath);
            if (!string.IsNullOrEmpty(fileName))
            {
                tb_FilePath.Text = fileName;
                tb_FilePath_Leave(sender, e);
                LoadCsvData();
            }
        }

        private void tb_FilePath_Leave(object sender, EventArgs e)
        {
            if (tb_FilePath.Text == lastPath) return;
            lastPath = tb_FilePath.Text;
            ProjectManager.Configuration?.SetValue(tb_FilePath.Text, "/Project/Reference Reach Database Path");
            bool? saveSuccess = ProjectManager.Configuration?.SilentSave();
            if (saveSuccess != null)
            {
                if (saveSuccess == true)
                {
                    MessageBox.Show("Configuration settings saved successfully.");
                }
                else
                {
                    MessageBox.Show("An error occurred saving configuration settings.");
                }
            }
            LoadCsvData();
        }

        private void btn_AddStream_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add Stream functionality will be implemented later.", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_EditStream_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a stream to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Edit Stream functionality will be implemented later.", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_CopyStream_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a stream to copy.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedItem = listView.SelectedItems[0];
            var selectedDict = (Dictionary<string, string>)selectedItem.Tag;
            var newDict = new Dictionary<string, string>(selectedDict)
            {
                ["StreamName"] = selectedDict["StreamName"] + " (Copy)"
            };
            listManager.Add(newDict);
            SaveAndRefresh();
        }

        private void btn_DeleteStream_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a stream to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedItem = listView.SelectedItems[0];
            var selectedDict = (Dictionary<string, string>)selectedItem.Tag;

            if (MessageBox.Show("Are you sure you want to delete this stream?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                listManager.Remove(selectedDict);
                SaveAndRefresh();
            }
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_CopyStream.Enabled = listView.SelectedItems.Count > 0;
            btn_DeleteStream.Enabled = listView.SelectedItems.Count > 0;
        }

        private void ListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Toggle sort order for the clicked column
            if (columnSortOrders.ContainsKey(e.Column))
            {
                columnSortOrders[e.Column] = columnSortOrders[e.Column] == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
            {
                columnSortOrders.Clear(); // Clear other column sorts
                columnSortOrders[e.Column] = SortOrder.Ascending;
            }

            listView.ListViewItemSorter = new ListViewItemComparer(e.Column, columnSortOrders[e.Column]);
            listView.Sort();
        }

        private void SaveAndRefresh()
        {
            try
            {
                if (!string.IsNullOrEmpty(tb_FilePath.Text))
                {
                    listManager.ExportToCsv(tb_FilePath.Text);
                }
                RefreshListView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving CSV file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ComboBox_MeasureItem(object sender, System.Windows.Forms.MeasureItemEventArgs e)
        {
            e.ItemHeight = ((ComboBox)sender).ItemHeight;
        }

        private void ComboBox_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            ComboBox combo = (ComboBox)sender;
            string text = combo.Items[e.Index].ToString();
            e.DrawBackground();
            using (Brush textBrush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(text, combo.Font, textBrush, e.Bounds.X, e.Bounds.Y);
            }
            e.DrawFocusRectangle();
        }

        private class ListViewItemComparer : System.Collections.IComparer
        {
            private readonly int column;
            private readonly SortOrder sortOrder;

            public ListViewItemComparer(int column, SortOrder sortOrder)
            {
                this.column = column;
                this.sortOrder = sortOrder;
            }

            public int Compare(object x, object y)
            {
                var itemX = (ListViewItem)x;
                var itemY = (ListViewItem)y;
                var dictX = (Dictionary<string, string>)itemX.Tag;
                var dictY = (Dictionary<string, string>)itemY.Tag;
                string valueX = itemX.SubItems[column].Text;
                string valueY = itemY.SubItems[column].Text;

                int result;

                // Numerical columns: DrainageArea, ChannelSlope
                if (column == 3 || column == 4)
                {
                    decimal numX = 0, numY = 0;
                    bool parseX = false, parseY = false;

                    if (column == 3 && dictX.TryGetValue("DrainageArea", out var areaX) &&
                        decimal.TryParse(areaX, out var areaValueX) &&
                        dictX.TryGetValue("DrainageArea_Units", out var areaUnitStrX))
                    {
                        var areaUnitX = Units.AreaUnits.Values.FirstOrDefault(u => u.ToString() == areaUnitStrX);
                        if (areaUnitX != null)
                        {
                            numX = Units.ConvertArea(areaValueX, areaUnitX, Units.SquareMile);
                            parseX = true;
                        }
                    }
                    else if (column == 4 && dictX.TryGetValue("ChannelSlope", out var slopeX) &&
                        decimal.TryParse(slopeX, out var slopeValueX) &&
                        dictX.TryGetValue("ChannelSlope_Units", out var slopeUnitStrX))
                    {
                        var slopeUnitX = Units.SlopeUnits.Values.FirstOrDefault(u => u.ToString() == slopeUnitStrX);
                        if (slopeUnitX != null)
                        {
                            numX = Units.ConvertSlope(slopeValueX, slopeUnitX, Units.SlopePercent);
                            parseX = true;
                        }
                    }

                    if (column == 3 && dictY.TryGetValue("DrainageArea", out var areaY) &&
                        decimal.TryParse(areaY, out var areaValueY) &&
                        dictY.TryGetValue("DrainageArea_Units", out var areaUnitStrY))
                    {
                        var areaUnitY = Units.AreaUnits.Values.FirstOrDefault(u => u.ToString() == areaUnitStrY);
                        if (areaUnitY != null)
                        {
                            numY = Units.ConvertArea(areaValueY, areaUnitY, Units.SquareMile);
                            parseY = true;
                        }
                    }
                    else if (column == 4 && dictY.TryGetValue("ChannelSlope", out var slopeY) &&
                        decimal.TryParse(slopeY, out var slopeValueY) &&
                        dictY.TryGetValue("ChannelSlope_Units", out var slopeUnitStrY))
                    {
                        var slopeUnitY = Units.SlopeUnits.Values.FirstOrDefault(u => u.ToString() == slopeUnitStrY);
                        if (slopeUnitY != null)
                        {
                            numY = Units.ConvertSlope(slopeValueY, slopeUnitY, Units.SlopePercent);
                            parseY = true;
                        }
                    }

                    if (parseX && parseY)
                    {
                        result = numX.CompareTo(numY);
                    }
                    else if (parseX)
                    {
                        result = 1; // X is valid, Y is not
                    }
                    else if (parseY)
                    {
                        result = -1; // Y is valid, X is not
                    }
                    else
                    {
                        result = string.Compare(valueX, valueY, StringComparison.OrdinalIgnoreCase);
                    }
                }
                else
                {
                    // Alphabetical columns: StreamName, Ecoregion_LIV, StreamType
                    result = string.Compare(valueX, valueY, StringComparison.OrdinalIgnoreCase);
                }

                return sortOrder == SortOrder.Ascending ? result : -result;
            }
        }

        private void ReferenceReachBrowser_Load(object sender, EventArgs e)
        {
        }
    }
}