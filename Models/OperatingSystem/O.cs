using System.Text.Json.Serialization;

namespace LunaApiVultr.Models.OperatingSystem
{
    public class O
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("arch")]
        public string? Arch { get; set; }

        [JsonPropertyName("family")]
        public string? Family { get; set; }
    }
}
