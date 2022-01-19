using BlogApp.Helpers.Blog;
using BlogApp.Helpers.Extensions;
using BlogApp.Models;
using System.Net.Http.Json;

namespace BlogApp.Services
{
    public class BlogPostProcessor : IBlogPostProcessorService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IStateContainer stateContainer;

        public BlogPostProcessor(IHttpClientFactory httpClientFactory, IStateContainer stateContainer)
        {
            this.httpClientFactory = httpClientFactory;
            this.stateContainer = stateContainer;

            HttpClient = this.httpClientFactory.CreateClient("Local");
        }

        private HttpClient HttpClient { get; }

        public async Task<BlogPostDocument> ProcessPostAsync(string Name)
        {
            var key = Name.ToLower().Replace(" ", "_");
            BlogPostDocument doc;

            if (stateContainer.TryGet<BlogPostDocument>(key, out BlogPostDocument Value) == false)
            {
                Value = new BlogPostDocument()
                {
                    Html = await HttpClient.GetStringAsync($"/data/blog/site/{Name}.html"),
                    Yaml = YamlTools
                           .DeserializeYaml(await HttpClient.GetStringAsync($"/data/blog/site/{Name}.yml"))
                };

                stateContainer.Set<BlogPostDocument>(key, Value);
            }

            doc = Value;

            return doc;
        }

        public async Task<YamlMetadata> ProcessPostMetadataAsync(string Name)
        {
            return YamlTools
                .DeserializeYaml(await HttpClient.GetStringAsync($"/data/blog/site/{Name}.yml"));
        }

        public async Task<List<YamlMetadata>> ProcessPostsMetadataAsync()
        {
            List<YamlMetadata> Data;

            if (stateContainer.TryGet<List<YamlMetadata>>("yaml", out List<YamlMetadata> Value) == false)
            {
                Value = await HttpClient
                      .GetFromJsonAsync<List<YamlMetadata>>($"/data/blog/metadata/metadata.json");

                stateContainer.Set<List<YamlMetadata>>("yaml", Value);
            }

            Data = Value;

            return Data;
        }

        public async Task<List<string>> ProcessTagsAsync()
        {
            List<string> Data;

            if (stateContainer.TryGet<List<string>>("tags", out List<string> Value) == false)
            {
                Value = (await ProcessPostsMetadataAsync()).ConstructTags();
            }

            Data = Value;

            return Data;
        }
    }
}
