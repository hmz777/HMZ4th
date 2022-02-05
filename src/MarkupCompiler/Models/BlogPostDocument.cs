using System;

namespace MarkupCompiler.Models
{
    public class BlogPostDocument
    {
        public string Markdown { get; set; }
        public YamlMetadata Yaml { get; set; }
    }

    public class YamlMetadata
    {
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int ImageW { get; set; }
        public int ImageH { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
        public DateTime DateUpdated { get; set; }
        public string[] Tags { get; set; }
        public bool NoList { get; set; }
    }
}
