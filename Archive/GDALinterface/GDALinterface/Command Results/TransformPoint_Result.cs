using System.Text.Json;
using System.Text.Json.Serialization;
using PipeHandler;

namespace GDALinterface
{
    public partial class GDALserver
    {
        public event EventHandler<TransformPoint_ResultReceived_EventArgs> TransformPoint_ResultReceived;
    }
    public class TransformPoint_ResultReceived_EventArgs : EventArgs
    {
        public TransformPoint_Result Message { get; }
        public TransformPoint_ResultReceived_EventArgs(string message)
        {
            Message = JsonSerializer.Deserialize<TransformPoint_Result>(message);
        }
    }
    public record TransformPoint_Result : CommandResult
    {
        [JsonConstructor]
        public TransformPoint_Result(string id, string command, string status, double[] result, string message = null)
            : base(id, status, command, result, message)
        {
            Result = result;
        }

        [JsonPropertyName("result")]
        public new double[] Result { get; init; }
    }

}