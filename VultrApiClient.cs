using System.Net.Http.Headers;

namespace LunaApiVultr
{
    public class VultrApiClient : IDisposable
    {
        private readonly string apiKey;
        private readonly HttpClient client;

        public VultrApiClient(string apiKey, HttpClient httpClient)
        {
            this.apiKey = apiKey;
            this.client = httpClient;
            ConfigureHttpClient();
        }

        private void ConfigureHttpClient()
        {
            // set up the headers, including the API key
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        }

        public HttpClient GetHttpClient()
        {
            return client;
        }

        // Dispose method to release resources when done
        public void Dispose()
        {
            if (client != null)
            {
                client.Dispose();
            }
        }
    }
}
