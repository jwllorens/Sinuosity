using System.Text.Json;
using System.Text.Json.Serialization;
using PipeHandler;

namespace GDALinterface
{
    public partial class GDALserver
    {
        public event EventHandler<VectorInfo_ResultReceived_EventArgs> VectorInfo_ResultReceived;
    }
    public class VectorInfo_ResultReceived_EventArgs : EventArgs
    {
        public VectorInfo_Result Message { get; }
        public VectorInfo_ResultReceived_EventArgs(string message)
        {
            Message = JsonSerializer.Deserialize<VectorInfo_Result>(message);
        }
    }
    public record VectorInfo_Result : CommandResult
    {
        [JsonConstructor]
        public VectorInfo_Result(string id, string command, string status, VectorInfo result, string message = null)
            : base(id, status, command, result, message)
        {
            Result = result;
        }

        [JsonPropertyName("result")]
        public new VectorInfo Result { get; init; }
    }

    //Helpers
    public record VectorInfo
    {
        [JsonPropertyName("layerCount")]
        public int LayerCount { get; init; }

        [JsonPropertyName("layers")]
        public LayerInfo[] Layers { get; init; }
    }

    public record LayerInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("projection")]
        public string Projection { get; init; }

        [JsonPropertyName("featureCount")]
        public int FeatureCount { get; init; }

        [JsonPropertyName("fields")]
        public FieldInfo[] Fields { get; init; }
    }

    public record FieldInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; init; }

        [JsonPropertyName("type")]
        public string Type { get; init; }
    }
}