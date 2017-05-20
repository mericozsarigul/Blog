using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Model.Data
{
    public abstract class BaseClass
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
