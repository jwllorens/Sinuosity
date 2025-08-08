using System.Text.Json;
using System.Text.Json.Serialization;
using PipeHandler;
using System;

namespace GDALIPC
{
    public partial class GDALinterface
    {
        public event EventHandler<GetGeometryByFID_ResultReceived_EventArgs> GetGeometryByFID_ResultReceived;
    }
    public class GetGeometryByFID_ResultReceived_EventArgs : EventArgs
    {
        public CommandResult_GetGeometryByFID Message { get; }
        public GetGeometryByFID_ResultReceived_EventArgs(string message)
        {
            Message = JsonSerializer.Deserialize<CommandResult_GetGeometryByFID>(message);
        }
    }
    public class CommandResult_GetGeometryByFID : CommandResult
    {
        [JsonConstructor]
        public CommandResult_GetGeometryByFID(Guid id, string command, string status, string result, string message = null)
            : base(id, status, command, result, message)
        {
            Result = result;
        }

        [JsonPropertyName("result")]
        public string Result { get; private set; }
    }
}