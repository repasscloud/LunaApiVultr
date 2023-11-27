using System.Text.Json.Serialization;

namespace LunaApiVultr.Models.Plans;

public class PlansAvailable
{
    [JsonPropertyName("available_plans")]
    public List<string>? AvailablePlans { get; set; }
}
