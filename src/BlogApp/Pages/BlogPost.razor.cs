using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Pages
{
    public partial class BlogPost
    {
        [Parameter] public string Url { get; set; }
    }
}
