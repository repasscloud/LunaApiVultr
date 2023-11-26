using static LunaApiVultr.Vultr;

namespace LunaApiVultr
{
    public class VultrApiClient
    {
        private readonly string apiKey;
        private readonly HttpClient client;

        public VultrApiClient(string apiKey)
        {
            this.apiKey = apiKey;
            this.client = CreateHttpClient();
        }

        private HttpClient CreateHttpClient()
        {
            HttpClient httpClient = new HttpClient();

            // set up the headers, including the API key
            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            return httpClient;
        }

        public HttpClient GetHttpClient()
        {
            return client;
        }
    }
}
