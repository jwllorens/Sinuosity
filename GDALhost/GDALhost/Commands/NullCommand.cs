using OSGeo.GDAL;
using OSGeo.OGR;
using OSGeo.OSR;
using System.Reflection;


namespace GDALIPC
{
    public partial class GDALhost
    {
        [CalculationMethod("[]")]  //add parameters here for command signature, e.g. "[<string filePath>, <int layerIndex>, <bool returnGeometry>]"
        private async void NullCommand(string id)  //Add parameters as needed
        {
            var commandName = nameof(NullCommand); //adjust as neccesary
            await SendCommandResponse(id, commandName, "success", $"{commandName} starting..."); //Send CommandResponse immediately
            try
            {
                object result = null;
                //Perform command logic here
                await SendCommandResult(id, commandName, "success", result, $"Null result returned.");
            }
            catch (Exception ex)
            {
                await SendCommandResult(id, commandName, "error", null, $"{commandName} error: {ex.Message}");
            }
        }
    }
}
