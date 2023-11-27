using System.Text.Json.Serialization;
using LunaApiVultr.Models.Shared;

namespace LunaApiVultr.Models.Scripts;

public class InitializationScripts
{
    [JsonPropertyName("startup_scripts")]
    public List<StartupScript>? StartupScripts { get; set; }

    [JsonPropertyName("meta")]
    public Meta? Meta { get; set; }
}