﻿using MarkupCompiler.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace MarkupCompiler.Tools
{
    public class Seo
    {

        public static void ConstructRobots(string Domain, IEnumerable<YamlMetadata> BlogPostMetadata, string Output)
        {
            string Robots = string.Empty;

            Robots += "User-Agent: *\n" +
                        "Disallow : /?\n" +
                        "Disallow : /blog?\n" +
                        "Disallow : /blog/post?\n" +
                        "Disallow : /blog/post\n" +
                        "Disallow : /search?\n" +
                        "Disallow : /site?\n" +
                        "Disallow : /terms?\n" +
                        "Disallow : /blog/tags?\n";

            foreach (var Post in BlogPostMetadata)
            {
                if (Post.NoList)
                {
                    Robots += string.Format("Disallow : /blog/post/{0}\n", Post.Url);
                    Robots += string.Format("Disallow : /blog/post/{0}?\n", Post.Url);
                }
            }

            Robots += $"\nsitemap: {Domain}/sitemap.xml";

            File.WriteAllText(Output + "robots.txt", Robots);
        }

        public static void ConstructSitemap(string Domain, IEnumerable<YamlMetadata> BlogPostMetadata, string Output)
        {

            XmlDocument Sitemap = new XmlDocument();
            XmlDeclaration Dec = Sitemap.CreateXmlDeclaration("1.0", "UTF-8", null);
            Sitemap.AppendChild(Dec);
            XmlElement urlset = Sitemap.CreateElement(string.Empty, "urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");

            XmlElement url1 = Sitemap.CreateElement("url", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlElement loc1 = Sitemap.CreateElement("loc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            loc1.InnerText = string.Format("{0}", Domain);
            XmlElement mod1 = Sitemap.CreateElement("lastmod", "http://www.sitemaps.org/schemas/sitemap/0.9");
            mod1.InnerText = DateTime.Today.ToString("yyyy-MM-dd");
            XmlElement changefreq1 = Sitemap.CreateElement("changefreq", "http://www.sitemaps.org/schemas/sitemap/0.9");
            changefreq1.InnerText = "monthly";
            XmlElement priority1 = Sitemap.CreateElement("priority", "http://www.sitemaps.org/schemas/sitemap/0.9");
            priority1.InnerText = "1";
            url1.AppendChild(loc1);
            url1.AppendChild(mod1);
            url1.AppendChild(changefreq1);
            url1.AppendChild(priority1);

            urlset.AppendChild(url1);

            XmlElement url2 = Sitemap.CreateElement("url", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlElement loc2 = Sitemap.CreateElement("loc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            loc2.InnerText = string.Format("{0}/Blog", Domain);
            XmlElement mod2 = Sitemap.CreateElement("lastmod", "http://www.sitemaps.org/schemas/sitemap/0.9");
            mod2.InnerText = DateTime.Today.ToString("yyyy-MM-dd");
            XmlElement changefreq2 = Sitemap.CreateElement("changefreq", "http://www.sitemaps.org/schemas/sitemap/0.9");
            changefreq2.InnerText = "monthly";
            XmlElement priority2 = Sitemap.CreateElement("priority", "http://www.sitemaps.org/schemas/sitemap/0.9");
            priority2.InnerText = "0.8";
            url2.AppendChild(loc2);
            url2.AppendChild(mod2);
            url2.AppendChild(changefreq2);
            url2.AppendChild(priority2);

            urlset.AppendChild(url2);

            XmlElement url3 = Sitemap.CreateElement("url", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlElement loc3 = Sitemap.CreateElement("loc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            loc3.InnerText = string.Format("{0}/Blog/Tags", Domain);
            XmlElement mod3 = Sitemap.CreateElement("lastmod", "http://www.sitemaps.org/schemas/sitemap/0.9");
            mod3.InnerText = DateTime.Today.ToString("yyyy-MM-dd");
            XmlElement changefreq3 = Sitemap.CreateElement("changefreq", "http://www.sitemaps.org/schemas/sitemap/0.9");
            changefreq3.InnerText = "monthly";
            XmlElement priority3 = Sitemap.CreateElement("priority", "http://www.sitemaps.org/schemas/sitemap/0.9");
            priority3.InnerText = "0.7";
            url3.AppendChild(loc3);
            url3.AppendChild(mod3);
            url3.AppendChild(changefreq3);
            url3.AppendChild(priority3);

            urlset.AppendChild(url3);

            XmlElement url4 = Sitemap.CreateElement("url", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlElement loc4 = Sitemap.CreateElement("loc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            loc4.InnerText = string.Format("{0}/Site", Domain);
            XmlElement mod4 = Sitemap.CreateElement("lastmod", "http://www.sitemaps.org/schemas/sitemap/0.9");
            mod4.InnerText = DateTime.Today.ToString("yyyy-MM-dd");
            XmlElement changefreq4 = Sitemap.CreateElement("changefreq", "http://www.sitemaps.org/schemas/sitemap/0.9");
            changefreq4.InnerText = "monthly";
            XmlElement priority4 = Sitemap.CreateElement("priority", "http://www.sitemaps.org/schemas/sitemap/0.9");
            priority4.InnerText = "0.7";
            url4.AppendChild(loc4);
            url4.AppendChild(mod4);
            url4.AppendChild(changefreq4);
            url4.AppendChild(priority4);

            urlset.AppendChild(url4);

            XmlElement url5 = Sitemap.CreateElement("url", "http://www.sitemaps.org/schemas/sitemap/0.9");
            XmlElement loc5 = Sitemap.CreateElement("loc", "http://www.sitemaps.org/schemas/sitemap/0.9");
            loc5.InnerText = string.Format("{0}/Terms", Domain);
            XmlElement mod5 = Sitemap.CreateElement("lastmod", "http://www.sitemaps.org/schemas/sitemap/0.9");
            mod5.InnerText = DateTime.Today.ToString("yyyy-MM-dd");
            XmlElement changefreq5 = Sitemap.CreateElement("changefreq", "http://www.sitemaps.org/schemas/sitemap/0.9");
            changefreq5.InnerText = "monthly";
            XmlElement priority5 = Sitemap.CreateElement("priority", "http://www.sitemaps.org/schemas/sitemap/0.9");
            priority5.InnerText = "0.7";
            url5.AppendChild(loc5);
            url5.AppendChild(mod5);
            url5.AppendChild(changefreq5);
            url5.AppendChild(priority5);

            urlset.AppendChild(url5);

            foreach (var Post in BlogPostMetadata)
            {
                XmlElement url = Sitemap.CreateElement("url", "http://www.sitemaps.org/schemas/sitemap/0.9");
                XmlElement loc = Sitemap.CreateElement("loc", "http://www.sitemaps.org/schemas/sitemap/0.9");
                loc.InnerText = string.Format("{0}/Blog/Post/{1}", Domain, Post.Url);
                XmlElement mod = Sitemap.CreateElement("lastmod", "http://www.sitemaps.org/schemas/sitemap/0.9");
                mod.InnerText = Post.DateUpdated.ToString("yyyy-MM-dd");
                XmlElement changefreq = Sitemap.CreateElement("changefreq", "http://www.sitemaps.org/schemas/sitemap/0.9");
                changefreq.InnerText = "Weekly";
                XmlElement priority = Sitemap.CreateElement("priority", "http://www.sitemaps.org/schemas/sitemap/0.9");
                priority.InnerText = "0.9";

                url.AppendChild(loc);
                url.AppendChild(mod);
                url.AppendChild(changefreq);
                url.AppendChild(priority);

                urlset.AppendChild(url);
            }

            Sitemap.AppendChild(urlset);

            Sitemap.Save(Output + "sitemap.xml");
        }
    }
}
