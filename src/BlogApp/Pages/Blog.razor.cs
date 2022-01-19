using BlogApp.Models;
using BlogApp.Services;
using BlogApp.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BlogApp.Pages
{
    public partial class Blog : TransitionPageBase<Blog>
    {
        [Inject] IBlogPostProcessorService BlogPostProcessorService { get; set; }
        List<YamlMetadata> PostsMetadata { get; set; }
        bool DataIsEmpty { get; set; } = true;

        protected async override Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            PostsMetadata = await BlogPostProcessorService.ProcessPostsMetadataAsync();

            if (PostsMetadata != null && PostsMetadata.Count() != 0)
                DataIsEmpty = false;
        }
    }
}
