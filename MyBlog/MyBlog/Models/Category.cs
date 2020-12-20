using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Models;

namespace MyBlog.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        public IList<Blog> Blogs { get; set; }
    }
}
