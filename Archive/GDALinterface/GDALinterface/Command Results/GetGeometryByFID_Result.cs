using System.Text.Json;
using System.Text.Json.Serialization;
using PipeHandler;

namespace GDALinterface
{
    public partial class GDALserver
    {
        public event EventHandler<GetGeometryByFID_ResultReceived_EventArgs> GetGeometryByFID_ResultReceived;
    }
    public class GetGeometryByFID_ResultReceived_EventArgs : EventArgs
    {
        public GetGeometryByFID_Result Message { get; }
        public GetGeometryByFID_ResultReceived_EventArgs(string message)
        {
            Message = JsonSerializer.Deserialize<GetGeometryByFID_Result>(message);
        }
    }
    public record GetGeometryByFID_Result : CommandResult
    {
        [JsonConstructor]
        public GetGeometryByFID_Result(string id, string command, string status, string result, string message = null)
            : base(id, status, command, result, message)
        {
            Result = result;
        }

        [JsonPropertyName("result")]
        public string Result { get; init; }
    }
}