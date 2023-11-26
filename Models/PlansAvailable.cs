using System.Text.Json.Serialization;

namespace LunaApiVultr.Models
{
    public class PlansAvailable
    {
        [JsonPropertyName("available_plans")]
        public List<string>? AvailablePlans { get; set; }
    }
}
