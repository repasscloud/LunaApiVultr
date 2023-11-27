using System.Text.Json.Serialization;

namespace LunaApiVultr.Models.Scripts;
public class StartupScript
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("date_created")]
    public string? DateCreated { get; set; }

    [JsonPropertyName("date_modified")]
    public string? DateModified { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("script")]
    public string? Script { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}