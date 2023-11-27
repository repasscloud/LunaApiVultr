using System.Text.Json.Serialization;

namespace LunaApiVultr.Models.Instances;

public class NewInstanceResult
{
    [JsonPropertyName("instance")]
    public Instance? Instance { get; set; }
}