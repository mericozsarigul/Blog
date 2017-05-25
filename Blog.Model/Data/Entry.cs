using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.Data
{
    public class Entry:BaseClass
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content { get; set; }
        public Category Category { get; set; }
    }
}
