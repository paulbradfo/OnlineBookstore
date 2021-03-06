using book.Models;
using book.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace book.Controllers
{
    public class HomeController : Controller
    {
        private IbookRepository repo;

        public HomeController (IbookRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string bookCat, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == bookCat || bookCat == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks =
                        (bookCat == null ? repo.Books.Count() : repo.Books.Where(x => x.Category == bookCat).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }
    }
}
