using System.Text.Json;
using System.Text.Json.Serialization;
using PipeHandler;
using System;
using System.Collections.Generic;   

namespace GDALIPC
{
    public partial class GDALinterface
    {
        public event EventHandler<GetAttributesByFID_ResultReceived_EventArgs> GetAttributesByFID_ResultReceived;
    }
    public class GetAttributesByFID_ResultReceived_EventArgs : EventArgs
    {
        public CommandResult_GetAttributesByFID Message { get; }
        public GetAttributesByFID_ResultReceived_EventArgs(string message)
        {
            Message = JsonSerializer.Deserialize<CommandResult_GetAttributesByFID>(message);
        }
    }
    public class CommandResult_GetAttributesByFID : CommandResult
    {
        [JsonConstructor]
        public CommandResult_GetAttributesByFID(Guid id, string command, string status, Dictionary<string, object> result, string message = null)
            : base(id, status, command, result, message)
        {
            Result = result;
        }

        [JsonPropertyName("result")]
        public Dictionary<string, object> Result { get; private set; }
    }
}