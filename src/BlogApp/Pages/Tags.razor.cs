using BlogApp.Models;
using BlogApp.Services;
using BlogApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlogApp.Pages
{
    public partial class Tags : TransitionPageBase<Tags>
    {
        [Inject] IBlogPostProcessorService BlogPostProcessorService { get; set; }

        [Parameter] public string Tag { get; set; }

        List<YamlMetadata> Metadata;
        List<string> TagsData;

        bool DataIsValid => Metadata != null && TagsData != null;

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            Metadata = await BlogPostProcessorService.ProcessPostsMetadataAsync();
            TagsData = await BlogPostProcessorService.ProcessTagsAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (!string.IsNullOrWhiteSpace(Tag))
                await PageModule.InvokeVoidAsync("ScrollElementIntoView", Tag);
        }

    }
}
