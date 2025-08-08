using System.Text.Json;
using System.Text.Json.Serialization;
using PipeHandler;
using System;

namespace GDALIPC
{
    public partial class GDALinterface
    {
        public event EventHandler<TransformPoint_ResultReceived_EventArgs> TransformPoint_ResultReceived;
    }
    public class TransformPoint_ResultReceived_EventArgs : EventArgs
    {
        public CommandResult_TransformPoint Message { get; }
        public TransformPoint_ResultReceived_EventArgs(string message)
        {
            Message = JsonSerializer.Deserialize<CommandResult_TransformPoint>(message);
        }
    }
    public class CommandResult_TransformPoint : CommandResult
    {
        [JsonConstructor]
        public CommandResult_TransformPoint(Guid id, string command, string status, double[] result, string message = null)
            : base(id, status, command, result, message)
        {
            Result = result;
        }

        [JsonPropertyName("result")]
        public new double[] Result { get; private set; }
    }

}