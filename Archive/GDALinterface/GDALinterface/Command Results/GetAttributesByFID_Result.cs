using System.Text.Json;
using System.Text.Json.Serialization;
using PipeHandler;

namespace GDALinterface
{
    public partial class GDALserver
    {
        public event EventHandler<GetAttributesByFID_ResultReceived_EventArgs> GetAttributesByFID_ResultReceived;
    }
    public class GetAttributesByFID_ResultReceived_EventArgs : EventArgs
    {
        public GetAttributesByFID_Result Message { get; }
        public GetAttributesByFID_ResultReceived_EventArgs(string message)
        {
            Message = JsonSerializer.Deserialize<GetAttributesByFID_Result>(message);
        }
    }
    public record GetAttributesByFID_Result : CommandResult
    {
        [JsonConstructor]
        public GetAttributesByFID_Result(string id, string command, string status, Dictionary<string, object> result, string message = null)
            : base(id, status, command, result, message)
        {
            Result = result;
        }

        [JsonPropertyName("result")]
        public Dictionary<string, object> Result { get; init; }
    }
}