using AzureDevopsRestApi.Library.Interfaces;
using AzureDevopsRestApi.Library.Models;
using System.Text.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace AzureDevopsRestApi.Library
{

    public class DevopsLibrary : IDevopsLibrary
    {
        private HttpClient _httpClient;

        public DevopsLibrary(HttpClient client)
        {
            _httpClient = client;
        }

        /// <summary>
        /// Get items by a Wiql Query 
        /// </summary>
        /// <param name="organization"></param>
        /// <param name="project"></param>
        /// <param name="team"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<string> GetItemsByQueryAsync(string organization, string project, string team, string query)
        {
            var queryWiql = new WiqlQuery
            {
                Query = $"{query}"
            };
            StringContent jsonContent = new(JsonSerializer.Serialize(queryWiql), Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = _httpClient.PostAsync(
                                        $"https://dev.azure.com/{organization}/{project}/{team}/_apis/wit/wiql?api-version=6.0", jsonContent).Result)
            {
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
        }


        /// <summary>
        /// Get all projects
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get work item by an ID
        /// </summary>
        /// <param name="organization"></param>
        /// <param name="workitemId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get work items list by type
        /// </summary>
        /// <param name="organization"></param>
        /// <param name="project"></param>
        /// <param name="team"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task<string> GetWorkItemsByTypeAsync(string organization, string project, string team, string type)
        {
            var query = new WiqlQuery
            {
                Query = $"Select [System.Id], [System.Title], [System.State] From WorkItems Where [System.WorkItemType] = '{type}'"
            };
            StringContent jsonContent = new(JsonSerializer.Serialize(query), Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = _httpClient.PostAsync(
                                        $"https://dev.azure.com/{organization}/{project}/{team}/_apis/wit/wiql?api-version=6.0", jsonContent).Result)
            {
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
        }

        /// <summary>
        /// Get Work items
        /// </summary>
        /// <param name="organization"></param>
        /// <returns></returns>
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

       
    }
}