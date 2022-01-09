using HMZ4th.Services;
using HMZ4th.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMZ4th.Pages
{
    public partial class About : ComponentBase, IAsyncDisposable
    {
        [Inject] IJSRuntime JSRuntime { get; set; }
        IJSObjectReference AboutModule;

        bool InitAnimationPlayed;

        protected async override Task OnInitializedAsync()
        {
            AboutModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/modules/aboutModule.js");
        }
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                if (InitAnimationPlayed == false)
                {
                    await AboutModule.InvokeVoidAsync("InitAnimation");
                    InitAnimationPlayed = true;
                }
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (AboutModule != null)
            {
                await AboutModule.InvokeVoidAsync("Dispose");
                await AboutModule.DisposeAsync();
            }
        }
    }
}
