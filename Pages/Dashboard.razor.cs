using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMZ4th.Pages
{
    public partial class Dashboard : ComponentBase, IAsyncDisposable
    {
        [Inject] IJSRuntime JSRuntime { get; set; }
        IJSObjectReference DashboardModule;

        bool InitAnimationPlayed;

        protected async override Task OnInitializedAsync()
        {
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
