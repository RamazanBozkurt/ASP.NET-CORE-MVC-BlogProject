using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminBlog.Models;

namespace AdminBlog.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }    // altyazı
        public string Content { get; set; }     // içerik
        public string ImagePath { get; set; }     
        public bool IsPublish { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
