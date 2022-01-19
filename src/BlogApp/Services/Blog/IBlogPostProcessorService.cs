using BlogApp.Models;

namespace BlogApp.Services
{
    public interface IBlogPostProcessorService
    {
        Task<BlogPostDocument> ProcessPostAsync(string Name);
        Task<YamlMetadata> ProcessPostMetadataAsync(string Name);
        Task<List<YamlMetadata>> ProcessPostsMetadataAsync();
        Task<List<string>> ProcessTagsAsync();
    }
}
