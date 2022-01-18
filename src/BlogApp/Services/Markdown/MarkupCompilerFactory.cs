using Markdig;

namespace HMZ4th.Services.Markup
{
    public class MarkupCompilerFactory
    {
        private static IMarkupCompilerService MarkupCompilerWorker { get; set; }

        public static IMarkupCompilerService GetOrCreate()
        {
            if (MarkupCompilerWorker != null)
                return MarkupCompilerWorker;

            var Pipeline = new MarkdownPipelineBuilder()
                .UseYamlFrontMatter()
                .UseEmojiAndSmiley()
                .UseSmartyPants()
                .UseAdvancedExtensions()
                .Build();

            MarkupCompilerWorker = new MarkupCompilerWorker(Pipeline);

            return MarkupCompilerWorker;
        }
    }
}
