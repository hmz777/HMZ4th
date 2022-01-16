using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMZ4th.Models
{
    public class WorkProjectModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public object[] topics { get; set; }
        public int stargazers_count { get; set; }
        public int watchers_count { get; set; }
        public int forks_count { get; set; }
        public bool IsStaticProject { get; set; }
    }
}
