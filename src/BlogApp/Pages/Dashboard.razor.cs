using BlogApp.Helpers.Cache;
using BlogApp.Models;
using BlogApp.Services;
using BlogApp.Shared;
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

namespace BlogApp.Pages
{
    public partial class Dashboard : TransitionPageBase<Dashboard>
    {
        [Inject] IStateContainer StateContainer { get; set; }
        [Inject] IHttpClientFactory HttpClientFactory { get; set; }
        HttpClient HttpClient { get; set; }
        CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

        public DashboardGitHubWrapper DashboardGitHubWrapper { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            HttpClient = HttpClientFactory.CreateClient("External");

            try
            {
                if (StateContainer.TryGet<DashboardGitHubWrapper>(CacheKeys.DashboardKey,
                    out DashboardGitHubWrapper Value) == false)
                {
                    HttpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                    var T1 = HttpClient.GetFromJsonAsync<StatsModel>("https://api.github.com/users/hmz777",
                        CancellationTokenSource.Token);
                    var T2 = HttpClient.GetFromJsonAsync<List<RepoModel>>("https://api.github.com/users/hmz777/repos",
                        CancellationTokenSource.Token);
                    var T3 = HttpClient.GetFromJsonAsync<IssueSearchModel>("https://api.github.com/search/issues?q=author:hmz777",
                        CancellationTokenSource.Token);
                    var T4 = HttpClient.GetFromJsonAsync<CommitSearchModel>("https://api.github.com/search/commits?q=author:hmz777",
                        CancellationTokenSource.Token);

                    DashboardGitHubWrapper = new();
                    DashboardGitHubWrapper.StatsModel = await T1;
                    DashboardGitHubWrapper.RepoModels = await T2;
                    DashboardGitHubWrapper.IssueSearchModel = await T3;
                    DashboardGitHubWrapper.CommitSearchModel = await T4;

                    StateContainer.Set<DashboardGitHubWrapper>(CacheKeys.DashboardKey, DashboardGitHubWrapper);
                }
                else
                {
                    DashboardGitHubWrapper = Value;
                }
            }
            catch { }
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            CancellationTokenSource?.Cancel();
            CancellationTokenSource?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
