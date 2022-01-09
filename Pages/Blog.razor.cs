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
    public partial class Blog : ComponentBase, IAsyncDisposable
    {
        [Inject] IJSRuntime JSRuntime { get; set; }
        IJSObjectReference BlogModule;

        bool InitAnimationPlayed;

        protected async override Task OnInitializedAsync()
        {
            BlogModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./js/modules/blogModule.js");
        }
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                if (InitAnimationPlayed == false)
                {
                    await BlogModule.InvokeVoidAsync("InitAnimation");
                    InitAnimationPlayed = true;
                }
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (BlogModule != null)
            {
                await BlogModule.InvokeVoidAsync("Dispose");
                await BlogModule.DisposeAsync();
            }
        }
    }
}
