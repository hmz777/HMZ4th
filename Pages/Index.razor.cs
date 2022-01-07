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
    public partial class Index : ComponentBase, IAsyncDisposable
    {
        [Inject] IJSRuntime JSRuntime { get; set; }
        [Inject] TransitionPageService TransitionPageService { get; set; }

        IJSObjectReference HomeModule;

        protected async override Task OnInitializedAsync()
        {
            HomeModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/modules/homeModule.js");
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                await HomeModule.InvokeVoidAsync("InitAnimation");
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (HomeModule != null)
            {
                await HomeModule.InvokeVoidAsync("Dispose");
                await HomeModule.DisposeAsync();
            }
        }
    }
}
