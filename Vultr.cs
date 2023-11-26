using LunaApiVultr.Models;
using LunaApiVultr.Models.OperatingSystem;
using LunaApiVultr.Models.Shared;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace LunaApiVultr;

public class Vultr
{
    public static class VultrApiSettings
    {
        public static string ApiUrl { get; set; } = "https://api.vultr.com/v2";
    }

    public static async Task<List<Region>> GetRegionsAsync(string apiKey)
    {
        VultrApiClient vultrApiClient = new VultrApiClient(apiKey);
        HttpClient client = vultrApiClient.GetHttpClient();

        string response = await client.GetStringAsync($"{VultrApiSettings.ApiUrl}/regions");

        RegionData regionData = JsonSerializer.Deserialize<RegionData>(response)!;

        return regionData.Regions!.ToList();
    }

    public static async Task<PlansAvailable> GetAvailablePlansByRegionAsync(string apiKey, string region, string type = "vc2")
    {
        // List of valid types
        List<string> validTypes = new List<string>
        {
            "all", "vc2", "vdc", "vhf", "vhp", "voc", "voc-g", "voc-c", "voc-m", "voc-s", "vbm", "vcg"
        };

        // Check if the provided 'type' is valid
        if (!validTypes.Contains(type))
        {
            type = "vc2";
        }

        VultrApiClient vultrApiClient = new VultrApiClient(apiKey);
        HttpClient client = vultrApiClient.GetHttpClient();

        string response = await client.GetStringAsync($"{VultrApiSettings.ApiUrl}/regions/{region}/availability?type={type}");
        PlansAvailable result = JsonSerializer.Deserialize<PlansAvailable>(response)!;

        return result!;
    }

    public static async Task<List<string>> GetCountriesAsync(string apiKey)
    {
        var regions = await GetRegionsAsync(apiKey);

        List<string> uniqueCountries = regions.Select(region => region.Country).Distinct().ToList()!;
        uniqueCountries = uniqueCountries.OrderBy(i => i).ToList();

        return uniqueCountries;
    }

    public static async Task<List<O>> GetAvilableOsAsync(string apiKey)
    {
        VultrApiClient vultrApiClient = new VultrApiClient(apiKey);
        HttpClient client = vultrApiClient.GetHttpClient();

        string response = await client.GetStringAsync($"{VultrApiSettings.ApiUrl}/os");

        VultrOs osData = JsonSerializer.Deserialize<VultrOs>(response)!;

        return osData.Os!.ToList();
    }
}
