using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureDevopsRestApi.Library.Interfaces
{
    public interface IDevopsLibrary
    {
        Task<string> GetProjectsAsync(string organization);
        Task<string> GetWorkItemByIdAsync(string organization, int workitemId);
        Task<string> GetWorkItemsAsync(string organization);
        Task<string> GetWorkItemsByTypeAsync(string organization, string project, string team, string type);
    }
}
