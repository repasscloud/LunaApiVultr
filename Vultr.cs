using LunaApiVultr.Models;
using LunaApiVultr.Models.OperatingSystem;
using LunaApiVultr.Models.Scripts;
using LunaApiVultr.Models.Shared;
using System.Text;
using System.Text.Json;

namespace LunaApiVultr;

public class Vultr
{
    public static class VultrApiSettings
    {
        public static string ApiUrl { get; set; } = "https://api.vultr.com/v2";
    }

    public static async Task<List<Region>> GetRegionsAsync(VultrApiClient vultrApiClient)
    {
        try
        {
            HttpClient client = vultrApiClient.GetHttpClient();
            string apiUrl = $"{VultrApiSettings.ApiUrl}/regions";

            string response = await client.GetStringAsync(apiUrl);
            RegionData regionData = JsonSerializer.Deserialize<RegionData>(response)!;

        return regionData.Regions!.ToList();

        }
        catch (HttpRequestException ex)
        {
            // Log the exception details
            Console.WriteLine($"HTTP Request Exception: {ex.Message}");
            throw; // Rethrow the exception if needed
        }
        catch (Exception ex)
        {
            // Log or handle other exceptions
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw; // Rethrow the exception if needed
        }
    }

    public static async Task<PlansAvailable> GetAvailablePlansByRegionAsync(VultrApiClient vultrApiClient, string region, string type = "vc2")
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

        try
        {
            HttpClient client = vultrApiClient.GetHttpClient();
            string apiUrl = $"{VultrApiSettings.ApiUrl}/regions/{region}/availability?type={type}";
            string response = await client.GetStringAsync(apiUrl);
            PlansAvailable result = JsonSerializer.Deserialize<PlansAvailable>(response)!;

            return result!;
        }
        catch (HttpRequestException ex)
        {
            // Log the exception details
            Console.WriteLine($"HTTP Request Exception: {ex.Message}");
            throw; // Rethrow the exception if needed
        }
        catch (Exception ex)
        {
            // Log or handle other exceptions
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw; // Rethrow the exception if needed
        }
    }

    public static async Task<List<string>> GetCountriesAsync(VultrApiClient vultrApiClient)
    {
        try
        {
            var regions = await GetRegionsAsync(vultrApiClient);
            List<string> uniqueCountries = regions.Select(region => region.Country).Distinct().ToList()!;
            uniqueCountries = uniqueCountries.OrderBy(i => i).ToList();

            return uniqueCountries;
        }
        catch (HttpRequestException ex)
        {
            // Log the exception details
            Console.WriteLine($"HTTP Request Exception: {ex.Message}");
            throw; // Rethrow the exception if needed
        }
        catch (Exception ex)
        {
            // Log or handle other exceptions
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw; // Rethrow the exception if needed
        }
    }

    public static async Task<List<O>> GetAvilableOsAsync(VultrApiClient vultrApiClient)
    {
        try
        {
            HttpClient client = vultrApiClient.GetHttpClient();
            string apiUrl = $"{VultrApiSettings.ApiUrl}/os";

            string response = await client.GetStringAsync(apiUrl);
            VultrOs osData = JsonSerializer.Deserialize<VultrOs>(response)!;

            return osData.Os!.ToList();
        }
        catch (HttpRequestException ex)
        {
            // Log the exception details
            Console.WriteLine($"HTTP Request Exception: {ex.Message}");
            throw; // Rethrow the exception if needed
        }
        catch (Exception ex)
        {
            // Log or handle other exceptions
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw; // Rethrow the exception if needed
        }
    }

    
    public static async Task<List<StartupScript>> GetStartupScriptsAsync(VultrApiClient vultrApiClient)
    {
        try
        {
            HttpClient client = vultrApiClient.GetHttpClient();
            string apiUrl = $"{VultrApiSettings.ApiUrl}/startup-scripts";
            
            // Log the request details
            //Console.WriteLine($"Making GET request to: {apiUrl}");

            // Log each header individually
            foreach (var header in client.DefaultRequestHeaders)
            {
                //Console.WriteLine($"Header: {header.Key} = {string.Join(", ", header.Value)}");
            }

            string response = await client.GetStringAsync(apiUrl);
            InitializationScripts initScripts = JsonSerializer.Deserialize<InitializationScripts>(response)!;

            return initScripts.StartupScripts!.ToList();
        }
        catch (HttpRequestException ex)
        {
            // Log the exception details
            Console.WriteLine($"HTTP Request Exception: {ex.Message}");
            throw; // Rethrow the exception if needed
        }
        catch (Exception ex)
        {
            // Log or handle other exceptions
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw; // Rethrow the exception if needed
        }
    }


    public static async Task CreateNewInstanceAsync(VultrApiClient vultrApiClient)
    {
        try
        {
            HttpClient client = vultrApiClient.GetHttpClient();
            string apiUrl = $"{VultrApiSettings.ApiUrl}/instances";
            
            NewInstance newInstance = new NewInstance();
            string jsonBody = JsonSerializer.Serialize(newInstance);
            
            HttpResponseMessage response;
            using (var content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
            {
                response = await client.PostAsync(apiUrl, content);
            }

            // Check if the request was successful (status code 2xx)
            if (response.IsSuccessStatusCode)
            {
                // Process the successful response, if needed
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Successful Response:");
                Console.WriteLine(responseBody);
            }
            else
            {
                // Handle the case when the request was not successful
                Console.WriteLine($"Error: {response.StatusCode}");
            }
        }
        catch (HttpRequestException ex)
        {
            // Log the exception details
            Console.WriteLine($"HTTP Request Exception: {ex.Message}");
            throw; // Rethrow the exception if needed
        }
        catch (Exception ex)
        {
            // Log or handle other exceptions
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw; // Rethrow the exception if needed
        }
    }
}
