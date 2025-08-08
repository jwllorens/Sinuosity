using System.Text.Json;
using System.Text.Json.Serialization;
using PipeHandler;
using System;

namespace GDALIPC
{
    public partial class GDALinterface
    {
        public event EventHandler<VectorInfo_ResultReceived_EventArgs> VectorInfo_ResultReceived;
    }
    public class VectorInfo_ResultReceived_EventArgs : EventArgs
    {
        public CommandResult_VectorInfo Message { get; }
        public VectorInfo_ResultReceived_EventArgs(string message)
        {
            Message = JsonSerializer.Deserialize<CommandResult_VectorInfo>(message);
        }
    }
    public class CommandResult_VectorInfo : CommandResult
    {
        [JsonConstructor]
        public CommandResult_VectorInfo(Guid id, string command, string status, VectorInfo result, string message = null)
            : base(id, status, command, result, message)
        {
            Result = result;
        }

        [JsonPropertyName("result")]
        public new VectorInfo Result { get; private set; }
    }

    //Helpers
    public class VectorInfo
    {
        [JsonPropertyName("layerCount")]
        public int LayerCount { get; private set; }

        [JsonPropertyName("layers")]
        public LayerInfo[] Layers { get; private set; }
    }

    public class LayerInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; private set; }

        [JsonPropertyName("projection")]
        public string Projection { get; private set; }

        [JsonPropertyName("featureCount")]
        public int FeatureCount { get; private set; }

        [JsonPropertyName("fields")]
        public FieldInfo[] Fields { get; private set; }
    }

    public class FieldInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; private set; }

        [JsonPropertyName("type")]
        public string Type { get; private set; }
    }
}