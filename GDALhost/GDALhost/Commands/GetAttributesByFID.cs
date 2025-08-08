using OSGeo.OGR;
using System.Reflection;


namespace GDALIPC
{
    public partial class GDALhost
    {
        [CalculationMethod("[<string filePath>, <int layerIndex>, <int featureIndex>]")]
        private async void GetAttributesByFID(string id, string filePath, int layerIndex, int fid)
        {
            var commandName = nameof(GetAttributesByFID);
            await SendCommandResponse(id, commandName, "success", $"{commandName} starting..."); //Send CommandResponse immediately
            try
            {
                //Ensure that the datasource and layer is valid
                using DataSource dataSource = Ogr.Open(filePath, 0);
                if (dataSource == null)
                {
                    await SendCommandResult(id, commandName, "error", null, $"Failed to open file: {filePath}");
                }
                Layer layer = dataSource.GetLayerByIndex(layerIndex);
                if (layer == null)
                {
                    await SendCommandResult(id, commandName, "error", null, $"Layer index {layerIndex} not found in {filePath}");
                }
                Feature feature = layer.GetFeature(fid);
                if (feature == null)
                {
                    await SendCommandResult(id, commandName, "error", null, $"Feature {fid} not found in layer index {layerIndex}");
                }
                var fieldValues = new Dictionary<string, object>();
                for (int i = 0; i < feature.GetFieldCount(); i++)
                {
                    string fieldName = feature.GetFieldDefnRef(i).GetName();
                    FieldType fieldType = feature.GetFieldDefnRef(i).GetFieldType();
                    object fieldValue = _getFieldAsCSharpType(feature, i);
                    fieldValues.Add(fieldName, fieldValue);
                }
                await SendCommandResult(id, commandName, "success", fieldValues, $"Returned field values for feature {fid} in layer {layerIndex} of {filePath}");

            }
            catch (Exception ex)
            {
                await SendCommandResult(id, commandName, "error", null, $"{commandName} error: {ex.Message}");
            }
        }
    }
}
