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
    public partial class Search : TransitionPageBase<Search>
    {
        [Inject] IBlogPostProcessorService BlogPostProcessorService { get; set; }

        [Parameter] public string SearchTerm { get; set; }

        List<YamlMetadata> SearchResults = new();
        string _searchTerm = string.Empty;
        bool _hasResults = false;

        protected override void OnParametersSet()
        {
            _searchTerm = SearchTerm;
        }

        async Task ProcessSearch(ChangeEventArgs e)
        {
            _searchTerm = e.Value?.ToString()!;

            if (string.IsNullOrWhiteSpace(_searchTerm))
                SearchResults.Clear();
            else
                SearchResults = (await BlogPostProcessorService
                .ProcessPostsMetadataAsync())
                .Where(y => y.Title.Contains(_searchTerm, StringComparison.InvariantCultureIgnoreCase))
                .ToList();

            _hasResults = SearchResults.Count > 0;

            StateHasChanged();
        }
    }
}
