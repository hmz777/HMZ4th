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
    public partial class Skills : ComponentBase, IAsyncDisposable
    {
        [Inject] IHttpClientFactory HttpClientFactory { get; set; }
        [Inject] IJSRuntime JSRuntime { get; set; }

        HttpClient LocalHttpClient { get; set; }

        Dictionary<string, string[]> SkillsData;

        IJSObjectReference SkillsModule;

        string ActiveItem;
        bool InitAnimationPlayed;
        protected async override Task OnInitializedAsync()
        {
            SkillsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/modules/skillsModule.js");

            LocalHttpClient = HttpClientFactory.CreateClient("Local");

            using var doc = await LocalHttpClient.GetFromJsonAsync<JsonDocument>("/data/skills.json");
            SkillsData = doc?.RootElement.GetProperty("Skills").Deserialize<Dictionary<string, string[]>>();

            ActiveItem = SkillsData?.First().Key ?? "";
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                if (InitAnimationPlayed == false)
                {
                    await SkillsModule.InvokeVoidAsync("InitAnimation");
                    InitAnimationPlayed = true;
                }
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
            await SkillsModule.InvokeVoidAsync("Stagger", bodyId.Replace(" ", ""));
        }

        public async ValueTask DisposeAsync()
        {
            if (SkillsModule != null)
            {
                await SkillsModule.InvokeVoidAsync("Dispose");
                await SkillsModule.DisposeAsync();
            }
        }
    }
}

