using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using GDALIPC;

namespace Sinuosity.Forms
{
    using Sinuosity;
    using SinuosityCore.Properties;

    public partial class ProjectPropertiesGeoCalcs : Form
    {
        private bool isUpdate = false;
        private CancellationTokenSource cts;
        private Dictionary<string, object> _tempResults; // Store results temporarily
        private readonly Dictionary<string, object> _results;
        private GDALinterface GDAL; 
        private Dictionary<string, (int featureCount, string projectionWkt)> _shapefileMetadata;

        private Dictionary<string, VectorInfo> _vectorInfo;

        public ProjectPropertiesGeoCalcs(decimal lat, decimal lon, out Dictionary<string, object> _results)
        {
            InitializeComponent();
            cts = new CancellationTokenSource();
            decimal latitude = lat;
            decimal longitude = lon;
            _results = new Dictionary<string, object>();
            _shapefileMetadata = new Dictionary<string, (int, string)>(StringComparer.OrdinalIgnoreCase);
            tb_Lat.Text = Convert.ToString(latitude);
            tb_Lon.Text = Convert.ToString(longitude);


            _vectorInfo = new Dictionary<string, VectorInfo>();
        }

        private void GDALhostReadyToProcess(object sender, EventArgs e)
        {
            Log("GDAL host is connected and ready to start calculations.");
            lbl_PBStatus.Text = "Ready to start calculations.";
        }
        private void GDALhost_VectorInfo_ResultReceived(object sender, VectorInfo_ResultReceived_EventArgs e)
        {

        }
        private void GDALhost_TransformPoint_ResultReceived(object sender, TransformPoint_ResultReceived_EventArgs e)
        {

        }
        private void GDALhost_GetPolygonFIDByPoint_ResultReceived(object sender, GetPolygonFIDByPoint_ResultReceived_EventArgs e)
        {

        }
        private void GDALhost_GetAttributesByFID_ResultReceived(object sender, GetAttributesByFID_ResultReceived_EventArgs e)
        {

        }

        private void btn_StartCalculations_Click(object sender, EventArgs e)
        {
            btn_StartCalculations.Visible = false;
            try
            {
                var configPairs = new (object filePath, object fieldName, string tag)[]
                {
                    (ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Path_State), ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Field_State), "State"),
                    (ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Path_County), ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Field_County), "County"),
                    (ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Path_L4Ecoregion), ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Field_L4Ecoregion), "L4 Ecoregion Name"),
                    (ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Path_L3Ecoregion), ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Field_L3Ecoregion), "L3 Ecoregion Name"),
                    (ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Path_EcoregionCode), ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Field_EcoregionCode), "Ecoregion Code"),
                    (ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Path_HUCWatershedName), ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Field_HUCWatershedName), "HUC Watershed Name"),
                    (ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Path_HUCWatershedCode), ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Field_HUCWatershedCode), "HUC Watershed Code")
                };
                var results = new Dictionary<string, object>();
                // Group by filePath
                var filePathToFields = new Dictionary<string, List<(string fieldName, string tag)>>(StringComparer.OrdinalIgnoreCase);
                foreach (var (filePathObj, fieldNameObj, tag) in configPairs)
                {
                    string filePath = (string)filePathObj;
                    string fieldName = (string)fieldNameObj;

                    if (string.IsNullOrEmpty(fieldName) || string.IsNullOrEmpty(filePath))
                    {
                        UpdateUI($"Skipped {tag}: Field name or file path empty.\r\n");
                        results[tag] = null;
                        continue;
                    }

                    if (!filePathToFields.ContainsKey(filePath))
                        filePathToFields[filePath] = new List<(string, string)>();
                    filePathToFields[filePath].Add((fieldName, tag));
                }

                


                GDAL = new GDALinterface("GDALPipe", "hostPATH");
                GDAL.HostReadyToProcess += GDALhostReadyToProcess;
                GDAL.VectorInfo_ResultReceived += GDALhost_VectorInfo_ResultReceived;
                GDAL.TransformPoint_ResultReceived += GDALhost_TransformPoint_ResultReceived;
                GDAL.GetPolygonFIDByPoint_ResultReceived += GDALhost_GetPolygonFIDByPoint_ResultReceived;
                GDAL.GetAttributesByFID_ResultReceived += GDALhost_GetAttributesByFID_ResultReceived;

                Log("Starting GDAL interface...");
                GDAL.Start();



                if (!this.IsDisposed && !this.Disposing)
                {
                    foreach (KeyValuePair<string, object> kvp in _tempResults)
                    {
                        string tag = kvp.Key;
                        object value = kvp.Value;

                        if (value is Exception ex)
                        {
                            tb_OutputInfo.AppendText($"Error processing {tag}.\r\n");
                        }
                        else if (value == null)
                        {
                            tb_OutputInfo.AppendText($"No value found for {tag}.\r\n");
                        }
                        else
                        {
                            tb_OutputInfo.AppendText($"Calculated: {tag} = {value}\r\n");
                        }
                    }
                    if (_tempResults.Count > 0)
                        isUpdate = true;
                    lbl_PBStatus.Text = "Calculations complete.";
                    tb_OutputInfo.AppendText("\r\nCalculations complete. Please accept or reject the results.");

                    // Show Accept and Reject buttons
                    btn_Accept.Visible = true;
                    btn_Reject.Visible = true;
                }
            }
            catch (Exception ex)
            {
                tb_OutputInfo.AppendText($"Error during calculations: {ex.Message}\r\n");
                lbl_PBStatus.Text = "Error occurred.";
                btn_Reject.Visible = true;
            }
        }

        private void btn_Accept_Click(object sender, EventArgs e)
        {
            if (_tempResults != null && isUpdate)
            {
                foreach (KeyValuePair<string, object> kvp in _tempResults)
                {
                    string tag = kvp.Key;
                    object value = kvp.Value;
                    if (!(value is Exception) && value != null)
                    {
                        _tempResults.Add(tag, value);
                    }
                }
            }
            this.DialogResult = isUpdate ? DialogResult.OK : DialogResult.Cancel;
            this.Close();
        }

        private void btn_Reject_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private Dictionary<string, object> CalcGeoProperties(decimal latitude, decimal longitude, CancellationToken token, ToolStripProgressBar progressBar, ToolStripLabel statusLabel)
        {
            var configPairs = new (object filePath, object fieldName, string tag)[]
            {
                (ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Path_State), ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Field_State), "State"),
                (ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Path_County), ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Field_County), "County"),
                (ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Path_L4Ecoregion), ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Field_L4Ecoregion), "L4 Ecoregion Name"),
                (ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Path_L3Ecoregion), ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Field_L3Ecoregion), "L3 Ecoregion Name"),
                (ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Path_EcoregionCode), ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Field_EcoregionCode), "Ecoregion Code"),
                (ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Path_HUCWatershedName), ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Field_HUCWatershedName), "HUC Watershed Name"),
                (ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Path_HUCWatershedCode), ProjectManager.Configuration.GetValue(Resources.Config_ShapeFile_Field_HUCWatershedCode), "HUC Watershed Code")
            };

            var results = new Dictionary<string, object>();
            var filePathToFields = new Dictionary<string, List<(string fieldName, string tag)>>(StringComparer.OrdinalIgnoreCase);

            // Group by filePath
            foreach (var (filePathObj, fieldNameObj, tag) in configPairs)
            {
                string filePath = (string)filePathObj;
                string fieldName = (string)fieldNameObj;

                if (string.IsNullOrEmpty(fieldName) || string.IsNullOrEmpty(filePath))
                {
                    UpdateUI($"Skipped {tag}: Field name or file path empty.\r\n");
                    results[tag] = null;
                    continue;
                }

                if (!filePathToFields.ContainsKey(filePath))
                    filePathToFields[filePath] = new List<(string, string)>();
                filePathToFields[filePath].Add((fieldName, tag));
            }

            // Cache OGRInfo results
            int totalFeaturesAcrossAllFiles = 0;
            foreach (var filePath in filePathToFields.Keys)
            {
                try
                {
                    string ogrInfoResult = _gdalClient.OgrInfoAsync(filePath).GetAwaiter().GetResult();
                    Log($"OGR Info for {filePath}:\r\n{ogrInfoResult}", tb_OutputInfo);

                    // Parse feature count
                    var featureMatch = System.Text.RegularExpressions.Regex.Match(ogrInfoResult, @"Feature Count: (\d+)");
                    int featureCount = featureMatch.Success ? int.Parse(featureMatch.Groups[1].Value) : 0;

                    // Parse projection
                    var projMatch = System.Text.RegularExpressions.Regex.Match(ogrInfoResult, @"Layer Spatial Reference: (.+?)(?=\nField Count:|\nExtent:|$)");
                    string projectionWkt = projMatch.Success ? projMatch.Groups[1].Value : "GEOGCS[\"WGS 84\",DATUM[\"WGS_1984\",SPHEROID[\"WGS 84\",6378137,298.257223563]],PRIMEM[\"Greenwich\",0],UNIT[\"degree\",0.0174532925199433]]";

                    _shapefileMetadata[filePath] = (featureCount, projectionWkt);
                    totalFeaturesAcrossAllFiles += featureCount;
                }
                catch (Exception ex)
                {
                    Log($"Error counting features in {filePath}: {ex.Message}\r\n", tb_OutputInfo);
                    _shapefileMetadata[filePath] = (0, "GEOGCS[\"WGS 84\",DATUM[\"WGS_1984\",SPHEROID[\"WGS 84\",6378137,298.257223563]],PRIMEM[\"Greenwich\",0],UNIT[\"degree\",0.0174532925199433]]");
                }
            }

            int currentShapefile = 0;
            int cumulativeFeaturesProcessed = 0;

            Log($"Attempting to collect geographic properties from {filePathToFields.Count} shape files.\r\n", tb_OutputInfo);

            foreach (var filePath in filePathToFields.Keys)
            {
                if (token.IsCancellationRequested)
                    break;

                currentShapefile++;
                UpdateLabel(statusLabel, $"Processing shapefile {currentShapefile} of {filePathToFields.Count}");

                var fieldEntries = filePathToFields[filePath];
                var fieldNames = fieldEntries.ConvertAll(entry => entry.fieldName).ToArray();
                var (featureCount, projectionWkt) = _shapefileMetadata[filePath];

                try
                {
                    var attributes = GetShapefileAttributes(
                        (double)latitude, (double)longitude, 4326, filePath, fieldNames,
                        totalFeaturesAcrossAllFiles, ref cumulativeFeaturesProcessed,
                        featureCount, projectionWkt, tb_OutputInfo, token, pb_CalcProgress);
                    if (token.IsCancellationRequested)
                        break;

                    if (attributes != null)
                    {
                        foreach (var (fieldName, tag) in fieldEntries)
                        {
                            if (attributes.TryGetValue(fieldName, out var value))
                            {
                                if (value is Exception ex)
                                    results[tag] = ex;
                                else
                                    results[tag] = value;
                            }
                            else
                            {
                                results[tag] = null;
                            }
                        }
                    }
                    else
                    {
                        foreach (var (fieldName, tag) in fieldEntries)
                        {
                            results[tag] = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (!token.IsCancellationRequested)
                    {
                        foreach (var (fieldName, tag) in fieldEntries)
                        {
                            results[tag] = ex;
                        }
                    }
                }
            }

            UpdateProgress(totalFeaturesAcrossAllFiles, totalFeaturesAcrossAllFiles); // Ensure progress bar is full
            return results;
        }

        private Dictionary<string, object> GetShapefileAttributes(double latitude, double longitude, int inputEpsgCode, string shapefilePath, string[] fieldNames, int totalFeaturesAcrossAllFiles, ref int cumulativeFeaturesProcessed, int shapefileFeatureCount, string projectionWkt, TextBox logTextBox = null, CancellationToken token = default, ToolStripProgressBar progressBar = null)
        {
            void LogLocal(string message)
            {
                Log(message, logTextBox);
            }

            LogLocal($"Attempting to load features from shapefile at {shapefilePath}.");
            token.ThrowIfCancellationRequested();

            // Use cached projection
            if (string.IsNullOrEmpty(projectionWkt))
            {
                LogLocal($"Warning: No projection found for {shapefilePath}. Assuming WGS84.");
                projectionWkt = "GEOGCS[\"WGS 84\",DATUM[\"WGS_1984\",SPHEROID[\"WGS 84\",6378137,298.257223563]],PRIMEM[\"Greenwich\",0],UNIT[\"degree\",0.0174532925199433]]";
            }

            // Transform point
            var (x, y) = GDAL.TransformPointAsync(latitude, longitude, projectionWkt).GetAwaiter().GetResult();
            LogLocal($"Transformed point: ({x}, {y})");

            // Perform point-in-polygon check with progress updates
            var fieldValues = _gdalClient.PointInPolygonAsync(shapefilePath, x, y, fieldNames).GetAwaiter().GetResult();

            if (fieldValues != null)
            {
                LogLocal($"Found feature after checking {cumulativeFeaturesProcessed} features.");
                cumulativeFeaturesProcessed += shapefileFeatureCount;
                UpdateProgress(cumulativeFeaturesProcessed, totalFeaturesAcrossAllFiles);
                var result = new Dictionary<string, object>();
                foreach (var kvp in fieldValues)
                {
                    result[kvp.Key] = (object)kvp.Value;
                    LogLocal($"{kvp.Key} = {kvp.Value}");
                }
                return result;
            }
            else
            {
                LogLocal($"No feature found after checking {cumulativeFeaturesProcessed} features.\r\n");
                cumulativeFeaturesProcessed += shapefileFeatureCount;
                UpdateProgress(cumulativeFeaturesProcessed, totalFeaturesAcrossAllFiles);
                return null;
            }
        }

        private static void Log(string message, TextBox logTextBox = null)
        {
            if (logTextBox != null && !logTextBox.IsDisposed && !logTextBox.Disposing)
            {
                if (logTextBox.InvokeRequired)
                {
                    logTextBox.Invoke(new Action(() => logTextBox.AppendText($"{message}\r\n")));
                }
                else
                {
                    logTextBox.AppendText($"{message}\r\n");
                    logTextBox.SelectionStart = logTextBox.Text.Length;
                    logTextBox.ScrollToCaret();
                }
            }
            else
            {
                Console.WriteLine(message);
            }
        }

        private void UpdateProgress(int value, int maximum)
        {
            if (pb_CalcProgress != null && !pb_CalcProgress.IsDisposed && !pb_CalcProgress.GetCurrentParent().Disposing)
            {
                if (pb_CalcProgress.GetCurrentParent().InvokeRequired)
                {
                    pb_CalcProgress.GetCurrentParent().Invoke(new Action(() =>
                    {
                        pb_CalcProgress.Maximum = maximum;
                        pb_CalcProgress.Value = Math.Min(value, maximum);
                    }));
                }
                else
                {
                    pb_CalcProgress.Maximum = maximum;
                    pb_CalcProgress.Value = Math.Min(value, maximum);
                }
            }
        }

        private void UpdateUI(string message)
        {
            if (!this.IsDisposed && !this.Disposing)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    tb_OutputInfo.AppendText(message);
                });
            }
        }

        private void UpdateLabel(ToolStripLabel label, string text)
        {
            if (!this.IsDisposed && !this.Disposing)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    label.Text = text;
                });
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            cts?.Cancel();
            if (isUpdate)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Cancel;
            _gdalClient?.Dispose();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            cts?.Dispose();
            cts = null;
            _gdalClient?.Dispose();
        }

        private void Button_Paint(object sender, PaintEventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            if (button != null && button.Visible)
            {
                // Draw a single-pixel black border around the button
                using (Pen borderPen = new Pen(Color.Black, 1))
                {
                    Rectangle borderRect = new Rectangle(0, 0, button.Width - 2, button.Height - 2);
                    e.Graphics.DrawRectangle(borderPen, borderRect);
                }
            }
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            using (GeopropertyConfiguration form = new GeopropertyConfiguration())
            {
                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    // Example: Update a label or run some logic
                }
            }
        }
    }
}