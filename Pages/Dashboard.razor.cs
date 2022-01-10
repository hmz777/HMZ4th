using HMZ4th.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HMZ4th.Pages
{
    public partial class Dashboard : ComponentBase, IAsyncDisposable
    {
        [Inject] HttpClient HttpClient { get; set; }
        [Inject] IJSRuntime JSRuntime { get; set; }

        public DashboardGitHubWrapper DashboardGitHubWrapper { get; set; } = new DashboardGitHubWrapper();

        IJSObjectReference DashboardModule;

        bool InitAnimationPlayed;

        protected async override Task OnInitializedAsync()
        {
            var s = new Stopwatch();
            s.Start();

            HttpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            var T1 = HttpClient.GetFromJsonAsync<StatsModel>("https://api.github.com/users/hmz777");
            var T2 = HttpClient.GetFromJsonAsync<List<RepoModel>>("https://api.github.com/users/hmz777/repos");
            var T3 = HttpClient.GetFromJsonAsync<IssueSearchModel>("https://api.github.com/search/issues?q=author:hmz777");
            var T4 = HttpClient.GetFromJsonAsync<CommitSearchModel>("https://api.github.com/search/commits?q=author:hmz777");

            DashboardGitHubWrapper.StatsModel = await T1;
            DashboardGitHubWrapper.RepoModels = await T2;
            DashboardGitHubWrapper.IssueSearchModel = await T3;
            DashboardGitHubWrapper.CommitSearchModel = await T4;

            Console.WriteLine("Ex time -------> {0}", s.ElapsedMilliseconds);
            s.Stop();
            DashboardModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/modules/dashboardModule.js");
        }
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                if (InitAnimationPlayed == false)
                {
                    await DashboardModule.InvokeVoidAsync("InitAnimation");
                    InitAnimationPlayed = true;
                }
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (DashboardModule != null)
            {
                await DashboardModule.InvokeVoidAsync("Dispose");
                await DashboardModule.DisposeAsync();
            }
        }
    }
}
