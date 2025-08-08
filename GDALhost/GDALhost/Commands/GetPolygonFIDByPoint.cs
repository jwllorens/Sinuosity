using OSGeo.OGR;
using System.Reflection;


namespace GDALIPC
{
    public partial class GDALhost
    {
        [CalculationMethod("[<double pointX>, <double pointY>, <string filePath>, <int layerIndex>]")]
        private async void GetPolygonFIDByPoint(string id, double pointX, double pointY, string filePath, int layerIndex)
        {
            var commandName = nameof(GetPolygonFIDByPoint);
            await SendCommandResponse(id, commandName, "success", $"{commandName} starting..."); //Send CommandResponse immediately
            try
            {
                //Ensure that the datasource and layer is valid
                using DataSource dataSource = Ogr.Open(filePath, 0);
                if (dataSource == null)
                {
                    await SendCommandResult(id, commandName, "error", "null", $"Failed to open file: {filePath}");
                }
                Layer layer = dataSource.GetLayerByIndex(layerIndex);
                if (layer == null)
                {
                    await SendCommandResult(id, commandName, "error", "null", $"Layer index {layerIndex} not found in {filePath}");
                }

                //Set up loop variables
                long totalFeatures = layer.GetFeatureCount(1);
                int currentFeature = 0;
                bool featureFound = false;
                long result = 0;

                //Create the point geometry
                Geometry pointGeom = new Geometry(wkbGeometryType.wkbPoint);
                pointGeom.AddPoint_2D(pointX, pointY);

                layer.ResetReading();
                while (!featureFound)
                {
                    Feature feature = layer.GetNextFeature();
                    if (feature == null) break; // No more features
                    currentFeature++;
                    await SendCommandProgress(id, commandName, currentFeature, (int)totalFeatures, $"Searching for polygon at point [{pointX}, {pointY}] in layer {layerIndex} of {filePath}...");
                    Geometry geom = feature.GetGeometryRef();
                    if (geom == null) continue; // No geometry for this feature
                    if (geom.GetGeometryType() != wkbGeometryType.wkbPolygon) continue; // Not a polygon geometry

                    // Check if the point is within the polygon geometry
                    if (geom.Contains(pointGeom)) featureFound = true;

                    result = feature.GetFID();
                }
                if (!featureFound)
                {
                    await SendCommandResult(id, commandName, "error", null, $"No polygon found at point [{pointX}, {pointY}] in layer {layerIndex} of {filePath}");
                    return;
                }
                else
                {
                    await SendCommandResult(id, commandName, "success", result, $"Polygon {result} found at point [{pointX}, {pointY}] in layer {layerIndex} of {filePath}");
                }
            }
            catch (Exception ex)
            {
                await SendCommandResult(id, commandName, "error", "null", $"{commandName} error: {ex.Message}");
            }
        }
    }
}
