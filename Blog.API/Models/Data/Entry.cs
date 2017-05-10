using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Models.Data
{
    public class Entry:BaseClass
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
    }
}
