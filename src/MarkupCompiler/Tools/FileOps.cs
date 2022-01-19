using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MarkupCompiler.Tools
{
    public class FileOps
    {
        public static void CleanSite(string path)
        {
            var metadata = Path.Combine(path, "metadata");
            var site = Path.Combine(path, "site");

            if (Directory.Exists(metadata) == false
               || Directory.Exists(site) == false)
            {
                return;
            }

            //Cleans The targeted folder from files and folders
            foreach (var item in Directory.EnumerateDirectories(metadata))
            {
                Directory.Delete(item);
            }

            foreach (var item in Directory.EnumerateFiles(metadata))
            {
                File.Delete(item);
            }

            foreach (var item in Directory.EnumerateDirectories(site))
            {
                Directory.Delete(item);
            }

            foreach (var item in Directory.EnumerateFiles(site, "*.html"))
            {
                File.Delete(item);
            }

            foreach (var item in Directory.EnumerateFiles(site, "*.yml"))
            {
                File.Delete(item);
            }
        }
    }
}
