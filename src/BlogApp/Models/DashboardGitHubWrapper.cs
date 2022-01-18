using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class DashboardGitHubWrapper
    {
        public List<RepoModel> RepoModels { get; set; }
        public StatsModel StatsModel { get; set; }
        public IssueSearchModel IssueSearchModel { get; set; }
        public CommitSearchModel CommitSearchModel { get; set; }
        public bool DataIsSet =>
            RepoModels != null
            && StatsModel != null
            && IssueSearchModel != null
            && CommitSearchModel != null;
    }
}
