using System.Text.Json.Serialization;

namespace LunaApiVultr.Models.Shared;

public class Region
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("city")]
    public string? City { get; set; }

    [JsonPropertyName("country")]
    public string? Country { get; set; }

    [JsonPropertyName("continent")]
    public string? Continent { get; set; }

    [JsonPropertyName("options")]
    public List<string>? Options { get; set; }
}
