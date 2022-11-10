using AzureDevopsRestApi.Library.Interfaces;

namespace AzureDevopsRestApi.Library
{

    public class DevopsLibrary : IDevopsLibrary
    {
        private HttpClient _httpClient;

        public DevopsLibrary(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<string> GetItemsByQueryAsync(string organization,string project, string query)
        {
            var uri = $"https://dev.azure.com/{organization}/{project}/_apis/wit/queries/{query}?api-version=6.0";
            using (HttpResponseMessage response = _httpClient.GetAsync(
                             $"https://dev.azure.com/{organization}/{project}/_apis/wit/queries/{query}?api-version=6.0").Result)
            {
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
        }
     
        public async Task<string> GetProjectsAsync(string organization)
        {
            using (HttpResponseMessage response = _httpClient.GetAsync(
                             $"https://dev.azure.com/{organization}/_apis/projects?api-version=6.0").Result)
            {
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
        }

        public async Task<string> GetWorkItemByIdAsync(string organization, int workitemId)
        {
            using (HttpResponseMessage response = _httpClient.GetAsync(
                                         $"https://dev.azure.com/{organization}/_apis/wit/workitems/{workitemId}?api-version=6.0").Result)
            {
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
        }
        public async Task<string> GetWorkItemsByTypeAsync(string organization, string project, string type)
        {
            using (HttpResponseMessage response = _httpClient.GetAsync(
                                        $"https://dev.azure.com/{organization}/{project}/_apis/wit/workitems/{type}?api-version=6.0").Result)
            {
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
        }

        public async Task<string> GetWorkItemsAsync(string organization)
        {
            using (HttpResponseMessage response = _httpClient.GetAsync(
                                         $"https://dev.azure.com/{organization}/_apis/wit/workitems/").Result)
            {
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
        }

        public async Task<string> GetBacklogWorkItemsAsync(string organization, string project, string team)
        {
            using (HttpResponseMessage response = _httpClient.GetAsync(
                                        $"https://dev.azure.com/{organization}/{project}/{team}/_apis/work/backlogs/Microsoft.FeatureCategory/workItems").Result)
            {
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }

        }
    }
}