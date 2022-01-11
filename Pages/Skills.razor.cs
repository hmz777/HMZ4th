using HMZ4th.Services;
using HMZ4th.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HMZ4th.Pages
{
    public partial class Skills : TransitionPageBase<Skills>
    {
        [Inject] IHttpClientFactory HttpClientFactory { get; set; }

        HttpClient LocalHttpClient { get; set; }
        CancellationTokenSource CancellationTokenSource = new CancellationTokenSource();

        Dictionary<string, string[]> SkillsData;

        string ActiveItem;
        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            try
            {
                LocalHttpClient = HttpClientFactory.CreateClient("Local");

                using var doc = await LocalHttpClient.GetFromJsonAsync<JsonDocument>("/data/skills.json", CancellationTokenSource.Token);
                SkillsData = doc?.RootElement.GetProperty("Skills").Deserialize<Dictionary<string, string[]>>();

                ActiveItem = SkillsData?.First().Key ?? "";
            }
            catch { }
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (!firstRender)
            {
                await StaggerSkills(ActiveItem);
            }
        }

        async Task SetActive(string Item)
        {
            ActiveItem = Item;
            StateHasChanged();
            await StaggerSkills(ActiveItem);
        }

        async Task StaggerSkills(string bodyId)
        {
            await PageModule.InvokeVoidAsync("Stagger", bodyId.Replace(" ", ""));
        }

        public async override ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
            CancellationTokenSource?.Cancel();
            CancellationTokenSource?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

