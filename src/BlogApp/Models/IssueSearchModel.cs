using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class IssueSearchModel
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        public List<IssueModel> items { get; set; }
    }
}
