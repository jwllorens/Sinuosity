using System.Text.Json;
using System.Text.Json.Serialization;
using PipeHandler;
using System;

namespace GDALIPC
{
    public partial class GDALinterface
    {
        public event EventHandler<NullCommand_ResultReceived_EventArgs> NullCommand_ResultReceived;
    }
    public class NullCommand_ResultReceived_EventArgs : EventArgs
    {
        public CommandResult_NullCommand Message { get; }
        public NullCommand_ResultReceived_EventArgs(string message)
        {
            Message = JsonSerializer.Deserialize<CommandResult_NullCommand>(message);
        }
    }
    public class CommandResult_NullCommand : CommandResult
    {
        [JsonConstructor]
        public CommandResult_NullCommand(Guid id, string command, string status, object result, string message = null)
            : base(id, status, command, result, message)
        {
            Result = result;
        }

        [JsonPropertyName("result")]
        public object Result { get; private set; }
    }
}