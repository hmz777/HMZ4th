﻿using Markdig;
using Markdig.Extensions.Yaml;
using Markdig.Renderers;
using Markdig.Syntax;
using MarkupCompiler.Models;
using MarkupCompiler.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MarkupCompiler.Services
{
    public class MarkupCompilerWorker : IMarkupCompilerService
    {
        private MarkdownPipeline MarkdownPipeline { get; set; }

        public MarkupCompilerWorker(MarkdownPipeline markdownPipeline)
        {
            this.MarkdownPipeline = markdownPipeline;
        }

        public IEnumerable<BlogPostDocument> CompileMarkdown(string Root)
        {
            var PostDirectory = Path.Combine(Root, "posts");

            //Grab Markdown files
            var Paths = Directory.GetFiles(PostDirectory, "*.md");
            if (Paths.Length == 0)
            {
                Console.WriteLine($"No posts found in {PostDirectory}!");

                Environment.Exit(0);
            }

            List<BlogPostDocument> Docs = new List<BlogPostDocument>();

            foreach (var Path in Paths)
            {
                using (StringWriter stringWriter = new())
                {
                    HtmlRenderer htmlRenderer = new(stringWriter);
                    MarkdownPipeline.Setup(htmlRenderer);


                    var markdown = File.ReadAllText(Path);

                    MarkdownDocument Document = Markdown.Parse(markdown, MarkdownPipeline);

                    //Get yaml metadata
                    var yamlBlock = Document.Descendants<YamlFrontMatterBlock>().FirstOrDefault();

                    if (yamlBlock == null)
                    {
                        throw new Exception($"File with path {Path} has no Yaml metadata!");
                    }

                    string yaml = markdown.Substring(yamlBlock.Span.Start, yamlBlock.Span.Length);

                    YamlMetadata yamlMetadata = YamlTools.DeserializeYaml(yaml);

                    htmlRenderer.Render(Document);
                    stringWriter.Flush();

                    Docs.Add(new BlogPostDocument { Yaml = yamlMetadata, Markdown = stringWriter.ToString() });
                }
            }

            return Docs;
        }
    }
}
