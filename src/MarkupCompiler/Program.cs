﻿using Markdig;
using MarkupCompiler.Models;
using MarkupCompiler.Services;
using MarkupCompiler.Tools;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MarkupCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string Root = null;

#if DEBUG
                Root = Path.GetFullPath(Path.Combine(Directory
                    .GetParent(Assembly.GetExecutingAssembly().Location).FullName, @"..\..\..\..\", @"BlogApp\wwwroot\data\blog"));
#else
                Root = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"BlogApp\wwwroot\Blog"));
#endif
                //Here we used the GetCurrentDirectory because the working directory is set via Azure Pipelines.

                string Domain = "https://www.hamzialsheikh.tk";

                Console.WriteLine("Cleaning up...");
                FileOps.CleanSite(Root);

                Console.WriteLine("Building the Markdig pipeline and compiling posts if they exist...");
                var PostDocuments = MarkupCompilerFactory.GetOrCreate().CompileMarkdown(Root);

                string MainSiteDataPath = Path.Combine(Root, "site");

                Console.WriteLine("Creating the necessary directories if they're not already created...");
                Directory.CreateDirectory(Path.Combine(Root, "metadata"));
                Directory.CreateDirectory(Path.Combine(Root, "site"));
                Directory.CreateDirectory(Path.Combine(Root, "..", "..", "img", "blog", "posts"));

                Console.WriteLine("Writing the compiled data to files in a form of .html and .yml...");
                foreach (var Document in PostDocuments)
                {
                    using (StreamWriter markdownStreamWriter = File.CreateText(Path.Combine(MainSiteDataPath, Document.Yaml.Url) + ".html"))
                    {
                        markdownStreamWriter.Write(Document.Markdown);
                    }

                    using (StreamWriter yamlStreamWriter1 = File.CreateText(Path.Combine(MainSiteDataPath, Document.Yaml.Url) + ".yml"))
                    {
                        yamlStreamWriter1.Write(YamlTools.SerializeYaml(Document.Yaml));
                    }
                }

                var YamlMetadata = PostDocuments.Select(p => p.Yaml).ToList();

                Console.WriteLine("Constructing blog metadata...");
                MetadataTool.ConstructMetadata(Root, YamlMetadata);

                var wwwroot = Path.Combine(Root, "../../");

                Console.WriteLine("Building \"Robots.txt\"...");
                Seo.ConstructRobots(Domain, YamlMetadata, wwwroot);

                Console.WriteLine("Building \"Sitemap.xml\"...");
                Seo.ConstructSitemap(Domain, YamlMetadata, wwwroot);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
