using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyBlog.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MyBlog.Models;

namespace MyBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlogContext _context;

        public HomeController(ILogger<HomeController> logger, BlogContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Post(string Id)
        {
            var blog = _context.Blogs.Find(Id);
            blog.Author = _context.Authors.Find(blog.AuthorId);
            blog.ImagePath = "/images/" + blog.ImagePath;
            return View(blog);
        }

        public IActionResult Index()
        {
            var list = _context.Blogs.Take(4).Where(b => b.IsPublish).OrderByDescending(x => x.CreateTime).ToList();
            foreach (var blog in list)
            {
                blog.Author = _context.Authors.Find(blog.AuthorId);
            }
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
