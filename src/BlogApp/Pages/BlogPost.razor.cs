using BlogApp.Models;
using BlogApp.Services;
using BlogApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlogApp.Pages
{
    public partial class BlogPost : TransitionPageBase<BlogPost>
    {
        [Inject] public IBlogPostProcessorService BlogPostProcessorService { get; set; }
        [Parameter] public string Url { get; set; }

        BlogPostDocument BlogPostDocument { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (!string.IsNullOrWhiteSpace(Url))
            {
                BlogPostDocument = await BlogPostProcessorService.ProcessPostAsync(Url);
            }
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (!firstRender && PageModule != null)
                await PageModule.InvokeVoidAsync("HighlightCode");
        }
    }
}
