using LunaApiVultr.Models.Geo;
using LunaApiVultr.Models.Instances;
using LunaApiVultr.Models.OperatingSystem;
using LunaApiVultr.Models.Plans;
using LunaApiVultr.Models.Scripts;
using LunaApiVultr.Models.Shared;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

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

    public static async Task DeleteInstanceAsync(VultrApiClient vultrApiClient, string instanceId)
    {
        try
        {
            HttpClient client = vultrApiClient.GetHttpClient();
            string apiUrl = $"{VultrApiSettings.ApiUrl}/instances/{instanceId}";

            HttpResponseMessage response;
            response = await client.DeleteAsync(apiUrl);

            if (!response.IsSuccessStatusCode)
            {
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

    public static async Task RebootInstanceAsync(VultrApiClient vultrApiClient, string instanceId)
    {
        try
        {
            HttpClient client = vultrApiClient.GetHttpClient();
            string apiUrl = $"{VultrApiSettings.ApiUrl}/instances/{instanceId}/reboot";

            HttpResponseMessage response;
            response = await client.PostAsync(requestUri: apiUrl, content: null);

            if (response.IsSuccessStatusCode)
            {
                // Process the successful response, if needed
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Reboot successful for InstanceId: {instanceId}");
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

    public static async Task CreateNewInstanceAsync(VultrApiClient vultrApiClient, List<string> serverTags, string? scriptId = null)
    {
        try
        {
            HttpClient client = vultrApiClient.GetHttpClient();
            string apiUrl = $"{VultrApiSettings.ApiUrl}/instances";
            
            NewInstance newInstance = new NewInstance()
            {
                Tags = serverTags,
                ScriptId = scriptId,
            };

            // Configure JsonSerializerOptions to exclude null values
            var jsonSerializerOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            };

            // Convert the NewInstance object to JSON with configured options
            string jsonBody = JsonSerializer.Serialize(newInstance, jsonSerializerOptions);

            // debug
            Console.WriteLine(jsonBody);

            HttpResponseMessage response;
            using (var content = new StringContent(jsonBody, Encoding.UTF8, "application/json"))
            {
                response = await client.PostAsync(apiUrl, content);
            }

            // check if the request was successful (status code 2xx)
            if (response.IsSuccessStatusCode)
            {
                // Process the successful response, if needed
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Successful Response:");

                NewInstanceResult result = JsonSerializer.Deserialize<NewInstanceResult>(responseBody)!;
                Instance newlyCreatedInstance = result.Instance!;
                //
                // save it to the DB Here
                //

                // debug
                Console.WriteLine(responseBody);
                // writes data like below
                //{"instance":{"id":"be34a66c-3ec0-4ce2-91a5-084462187647","os":"Alpine Linux x64","ram":512,"disk":0,"main_ip":"0.0.0.0","vcpu_count":1,"region":"ewr","plan":"vc2-1c-0.5gb","date_created":"2023-11-27T05:10:20+00:00","status":"pending","allowed_bandwidth":0,"netmask_v4":"","gateway_v4":"0.0.0.0","power_status":"running","server_status":"none","v6_network":"","v6_main_ip":"","v6_network_size":0,"label":"","internal_ip":"","kvm":"","hostname":"vultr.guest","tag":"bird","tags":["bird","cats"],"os_id":2076,"app_id":0,"image_id":"","firewall_group_id":"","features":[],"user_scheme":"root","default_password":"[3Tf#nkKa[4*6H,x"}}
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

    public static async Task<Instance> GetInstanceDetails(VultrApiClient vultrApiClient, string instanceId)
    {
        try
        {
            HttpClient client = vultrApiClient.GetHttpClient();
            string apiUrl = $"{VultrApiSettings.ApiUrl}/instances/{instanceId}";

            HttpResponseMessage response = await client.GetAsync(apiUrl);

            // ensure success status code
            response.EnsureSuccessStatusCode();

            // if we reach here, request is successful
            string responseBody = await response.Content.ReadAsStringAsync();

            // hijack and existing class for this purpose
            NewInstanceResult instanceResult = JsonSerializer.Deserialize<NewInstanceResult>(responseBody)!;

            // break it down a level
            Instance instanceDetails = instanceResult.Instance!;

            return instanceDetails;
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
