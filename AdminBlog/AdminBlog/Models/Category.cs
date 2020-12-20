using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminBlog.Models;

namespace AdminBlog.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public IList<Blog> Blogs { get; set; }
    }
}
