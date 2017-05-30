using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Blog.Model.Data
{
    public class Entry:BaseClass
    {
        [Required]
        public string Title { get; set; }
        public string Summary { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
