using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BooksAndAuthors.Models;

namespace BooksAndAuthors.Controllers
{
    public class HomeController : Controller
    {
        private Context _context;
        public HomeController(Context context) {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            IndexView ViewToHTML = new IndexView(){
                // lists of authors
                Authors = _context.Authors.ToList()
            };
            return View(ViewToHTML);
        }

        [HttpPost("authors")]
        public IActionResult AddAuthor(IndexView FormData)
        {
            Author AuthorFromFormData = FormData.Author;
            if(ModelState.IsValid)
            {
                // save the author
                _context.Add(AuthorFromFormData);
                _context.SaveChanges();
                return RedirectToAction("Index");
            } else {
                // return the indexview, and get the authors
                FormData.Authors = _context.Authors.ToList();
                return View("Index", FormData);
            }
        }
        [HttpGet("authors/{authorId}")]
        public IActionResult Show(int authorId)
        {
            Author Author = _context.Authors.SingleOrDefault(author => author.AuthorId == authorId);
            return Json(Author);
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
