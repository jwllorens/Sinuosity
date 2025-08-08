using OSGeo.OGR;
using System.Reflection;


namespace GDALIPC
{
    public partial class GDALhost
    {
        [CalculationMethod("[<string filePath>, <int layerIndex>, <int featureIndex>, <bool repairGeometry>]")]
        private async void GetGeometryByFID(string id, string filePath, int layerIndex, int fid, bool repairGeometry)
        {
            var commandName = nameof(GetGeometryByFID);
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
                Feature feature = layer.GetFeature(fid);
                if (feature == null)
                {
                    await SendCommandResult(id, commandName, "error", null, $"Feature {fid} not found in layer index {layerIndex}");
                }

                //Set up loop variables
                string geomString = "";
                Geometry geom = feature.GetGeometryRef();
                if (geom == null) return; // No geometry for this feature

                //Repair geometries if neccesary
                if (repairGeometry)
                {
                    int geomRepairResult = TryRepairGeometry(geom, out Geometry repairedGeom);
                    if (geomRepairResult == 1)
                    {
                        await SendCommandResponse(id, commandName, "success", $"Successfully repaired geometry for feature {fid} in layer {layerIndex} of {filePath}");
                        repairedGeom.ExportToWkt(out geomString);
                    }
                    else if (geomRepairResult == 2)
                    {
                        await SendCommandResponse(id, commandName, "error", $"Failed to repair geometry for feature at point {fid} in layer {layerIndex} of {filePath}");
                        geom.ExportToWkt(out geomString);
                    }
                    else
                    {
                        geom.ExportToWkt(out geomString);
                    }
                }
                await SendCommandResult(id, commandName, "success", geomString, $"Returned WKT geometry string for feature {fid} in layer {layerIndex} of {filePath}");
            }
            catch (Exception ex)
            {
                await SendCommandResult(id, commandName, "error", null, $"{commandName} error: {ex.Message}");
            }
        }
    }
}
