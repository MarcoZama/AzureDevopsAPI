// See https://aka.ms/new-console-template for more information
using AzureDevopsRestApi.Library;
using AzureDevopsRestApi.Library.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Http.Headers;



try
{
    var personalaccesstoken = "";
    var organization = "";
    var project = "";
    var team = "";

    using (HttpClient client = new HttpClient())
    {
        var devops = new DevopsLibrary(client);

        client.DefaultRequestHeaders.Accept.Add(
            new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
            Convert.ToBase64String(
                System.Text.ASCIIEncoding.ASCII.GetBytes(
                    string.Format("{0}:{1}", "", personalaccesstoken))));

        var workitems = await devops.GetBacklogWorkItemsAsync(organization, project, team);

       
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}