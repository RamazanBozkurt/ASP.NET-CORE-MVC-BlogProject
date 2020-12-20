using AdminBlog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace AdminBlog.Controllers
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

        public async Task<IActionResult> AddCategory(Category category)
        {
            if(category.CategoryId == 0)    // kategori id si 0 ise yani yoksa ekle
            {
                await _context.AddAsync(category);
            } 
            else
            {
                _context.Update(category);  // aksi takdirde güncelle
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("Category");
        }

        public async Task<IActionResult> AddAuthor(Author author)
        {
            if (author.AuthorId == 0)
            {
                await _context.AddAsync(author);
            }
            else
            {
                _context.Update(author);
            }
            await _context.SaveChangesAsync();

            return RedirectToAction("Author");
        }

        public async Task<IActionResult> DeleteCategory(int? Id)
        {
            Category category = await _context.Categories.FindAsync(Id);
            _context.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Category");
        }

        public async Task<IActionResult> DeleteAuthor(int? Id)
        {
            Author author = await _context.Authors.FindAsync(Id);
            _context.Remove(author);
            await _context.SaveChangesAsync();
            return RedirectToAction("Author");
        }

        public IActionResult Category()
        {
            List<Category> category = _context.Categories.ToList();
            return View(category);
        }

        public IActionResult Author()
        {
            List<Author> author = _context.Authors.ToList();
            return View(author);
        }

        public async Task<IActionResult> CategoryDetails(int Id)
        {
            var category = await _context.Categories.FindAsync(Id);
            return Json(category);
        }

        public async Task<IActionResult> AuthorDetails(int Id)
        {
            var author = await _context.Categories.FindAsync(Id);
            return Json(author);
        }

        public IActionResult Login(string Email, string Password)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Email == Email && x.Password == Password);

            if (author == null)
            {
                return RedirectToAction("Index");
            }
            HttpContext.Session.SetInt32("id", author.AuthorId);

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            return View();
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
