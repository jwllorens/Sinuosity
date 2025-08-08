using System.Text.Json;
using PipeHandler;

namespace GDALinterface
{
    public partial class GDALserver
    {
        private void _CommandResult_EventInvoker(Message_Received_EventArgs e)
        {
            {
                var commandResult = JsonSerializer.Deserialize<CommandResult>(e.Message);
                switch (commandResult.Command.ToLower())
                {
                    case "vectorinfo":
                        VectorInfo_ResultReceived?.Invoke(this, new VectorInfo_ResultReceived_EventArgs(e.Message));
                        break;
                    case "transformpoint":
                        TransformPoint_ResultReceived?.Invoke(this, new TransformPoint_ResultReceived_EventArgs(e.Message));
                        break;
                    case "getpolygonfidbypoint":
                        GetPolygonFIDByPoint_ResultReceived?.Invoke(this, new GetPolygonFIDByPoint_ResultReceived_EventArgs(e.Message));
                        break;
                    case "getattributesbyfid":
                        GetAttributesByFID_ResultReceived?.Invoke(this, new GetAttributesByFID_ResultReceived_EventArgs(e.Message));
                        break;
                    case "getgeometrybyfid":
                        GetGeometryByFID_ResultReceived?.Invoke(this, new GetGeometryByFID_ResultReceived_EventArgs(e.Message));
                        break;
                    default:
                        if (!(Log == null)) Log($"Received Command Result with unknown command: {commandResult.Command}. Discarding.\r\n");
                        break;
                }
            }
        }
    }
}