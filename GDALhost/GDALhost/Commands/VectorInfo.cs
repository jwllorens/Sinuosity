using OSGeo.OGR;
using System.Reflection;

namespace GDALIPC
{
    public partial class GDALhost
    {
        [CalculationMethod("[<string filePath>]")]
        private async void VectorInfo(string id, string filePath)
        {
            var commandName = nameof(VectorInfo);
            await SendCommandResponse(id, commandName, "success", $"{commandName} starting..."); //Send CommandResponse immediately
            try
            {
                using var dataSource = Ogr.Open(filePath, 0);
                if (dataSource == null)
                {
                    await SendCommandResult(id, commandName, "error", "null", $"Failed to open file: {filePath}");
                }

                int layerCount = dataSource.GetLayerCount();
                var layers = new object[layerCount];
                for (int i = 0; i < layerCount; i++)
                {
                    var layer = dataSource.GetLayerByIndex(i);
                    var layerDefn = layer.GetLayerDefn();
                    var fieldCount = layerDefn.GetFieldCount();
                    var fields = new object[fieldCount];
                    for (int j = 0; j < fieldCount; j++)
                    {
                        var fieldDefn = layerDefn.GetFieldDefn(j);
                        fields[j] = new
                        {
                            name = fieldDefn.GetName(),
                            type = fieldDefn.GetFieldTypeName(fieldDefn.GetFieldType())
                        };
                    }

                    string projection = null;
                    using var spatialRef = layer.GetSpatialRef();
                    if (spatialRef != null)
                    {
                        spatialRef.ExportToWkt(out projection, null);
                    }

                    layers[i] = new
                    {
                        name = layer.GetName(),
                        projection,
                        featureCount = layer.GetFeatureCount(1),
                        fields
                    };
                }

                var info = new
                {
                    layerCount,
                    layers
                };
                await SendCommandResult(id, commandName, "success", info, $"Successfully retrieved vector info for {filePath}");
            }
            catch (Exception ex)
            {
                await SendCommandResult(id, commandName, "error", "null", $"{commandName} error: {ex.Message}");
            }
        }
    }
}