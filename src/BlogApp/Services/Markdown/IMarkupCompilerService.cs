using HMZ4th.Models;

namespace HMZ4th.Services.Markup
{
    public interface IMarkupCompilerService
    {
        IEnumerable<BlogPostDocument> CompileMarkdown(string Root);
    }
}
