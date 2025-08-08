using System.Text.Json;
using System.Text.Json.Serialization;
using PipeHandler;
using System;

namespace GDALIPC
{
    public partial class GDALinterface
    {
        public event EventHandler<GetPolygonFIDByPoint_ResultReceived_EventArgs> GetPolygonFIDByPoint_ResultReceived;
    }
    public class GetPolygonFIDByPoint_ResultReceived_EventArgs : EventArgs
    {
        public GetPolygonFIDByPoint_Result Message { get; }
        public GetPolygonFIDByPoint_ResultReceived_EventArgs(string message)
        {
            Message = JsonSerializer.Deserialize<GetPolygonFIDByPoint_Result>(message);
        }
    }
    public class GetPolygonFIDByPoint_Result : CommandResult
    {
        [JsonConstructor]
        public GetPolygonFIDByPoint_Result(Guid id, string command, string status, long result, string message = null)
            : base(id, status, command, result, message)
        {
            Result = result;
        }

        [JsonPropertyName("result")]
        public long Result { get; private set; }
    }
}