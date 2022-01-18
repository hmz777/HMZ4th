using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMZ4th.Models
{
    public class CommitSearchModel
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        public List<CommitModel> items { get; set; }
    }
}
