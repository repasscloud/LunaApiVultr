using LunaApiVultr.Models.OperatingSystem;
using LunaApiVultr.Models.Shared;
using System.Text.Json.Serialization;

namespace LunaApiVultr.Models
{
    public class VultrOs
    {
        [JsonPropertyName("os")]
        public List<O>? Os { get; set; }

        [JsonPropertyName("meta")]
        public Meta? Meta { get; set; }
    }
}
