using System.Text.Json;
using System.Text.Json.Serialization;
using PipeHandler;

namespace GDALinterface
{
    public partial class GDALserver
    {
        public event EventHandler<NullCommand_ResultReceived_EventArgs> NullCommand_ResultReceived;
    }
    public class NullCommand_ResultReceived_EventArgs : EventArgs
    {
        public NullCommand_Result Message { get; }
        public NullCommand_ResultReceived_EventArgs(string message)
        {
            Message = JsonSerializer.Deserialize<NullCommand_Result>(message);
        }
    }
    public record NullCommand_Result : CommandResult
    {
        [JsonConstructor]
        public NullCommand_Result(string id, string command, string status, object result, string message = null)
            : base(id, status, command, result, message)
        {
            Result = result;
        }

        [JsonPropertyName("result")]
        public object Result { get; init; }
    }
}