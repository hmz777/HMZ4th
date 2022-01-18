using HMZ4th.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMZ4th.Shared
{
    public class TransitionPageBase<T> : ComponentBase, IAsyncDisposable where T : class
    {
        [Inject] IJSRuntime JSRuntime { get; set; }
        public IJSObjectReference PageModule { get; set; }

        bool InitAnimationPlayed;

        protected async override Task OnInitializedAsync()
        {
            PageModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import",
                $"./js/modules/{typeof(T).Name.ToLower()}Module.js");
        }
        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (!firstRender)
            {
                if (InitAnimationPlayed == false && PageModule != null)
                {
                    await PageModule.InvokeVoidAsync("InitAnimation");
                    InitAnimationPlayed = true;
                }
            }
        }

        public virtual async ValueTask DisposeAsync()
        {
            if (PageModule != null)
            {
                await PageModule.InvokeVoidAsync("Dispose");
                await PageModule.DisposeAsync();
            }

            GC.SuppressFinalize(this);
        }
    }
}