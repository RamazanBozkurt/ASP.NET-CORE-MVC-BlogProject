using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminBlog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminBlog.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogContext _context;

        public BlogController(BlogContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Categories = _context.Categories.Select(x =>
                new SelectListItem
                {
                    Text = x.CategoryId.ToString(),
                    Value = x.Name
                }
            ).ToList();
            return View();
        }
    }
}
