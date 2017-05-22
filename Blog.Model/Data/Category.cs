using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Model.Data
{
    public class Category:BaseClass
    {
        public string Title { get; set; }
        public virtual List<Entry> Entries { get; set; }

    }
}
