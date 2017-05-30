using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Model.Data
{
    public class Category : BaseClass
    {
        [Required]
        public string Title { get; set; }

        public ICollection<Entry> Entries { get; set; }
    }
}