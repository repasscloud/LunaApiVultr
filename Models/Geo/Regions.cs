using System.Text.Json.Serialization;
using LunaApiVultr.Models.Shared;

namespace LunaApiVultr.Models.Geo;

public class RegionData
{
    [JsonPropertyName("regions")]
    public List<Region>? Regions { get; set; }

    [JsonPropertyName("meta")]
    public Meta? Meta { get; set; }
}