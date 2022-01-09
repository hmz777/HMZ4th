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
    public partial class Work : ComponentBase, IAsyncDisposable
    {
        [Inject] IJSRuntime JSRuntime { get; set; }
        IJSObjectReference WorkModule;

        bool InitAnimationPlayed;

        protected async override Task OnInitializedAsync()
        {
            WorkModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/modules/workModule.js");
        }
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                if (InitAnimationPlayed == false)
                {
                    await WorkModule.InvokeVoidAsync("InitAnimation");
                    InitAnimationPlayed = true;
                }
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (WorkModule != null)
            {
                await WorkModule.InvokeVoidAsync("Dispose");
                await WorkModule.DisposeAsync();
            }
        }
    }
}
