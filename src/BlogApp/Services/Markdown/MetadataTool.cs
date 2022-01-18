using HMZ4th.Models;
using System.Text.Json;

namespace HMZ4th.Services.Tools
{
    public class MetadataTool
    {
        public static void ConstructMetadata(string path, IEnumerable<YamlMetadata> blogPostMetadata)
        {
            var JsonMetadata = JsonSerializer.Serialize(blogPostMetadata);

            File.WriteAllText(Path.Combine(path, "Metadata", "Metadata.json"), JsonMetadata);
        }
    }
}
