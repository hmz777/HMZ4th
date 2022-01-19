using BlogApp.Models;
using BlogApp.Services;
using BlogApp.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            BlogPostDocument = await BlogPostProcessorService.ProcessPostAsync(Url);
        }
    }
}
