using book.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book.Components
{
    public class CatsViewComponent : ViewComponent 
    {
        private IbookRepository repo { get; set; }

        public CatsViewComponent(IbookRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCat = RouteData?.Values["bookCat"];

            var cats = repo.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(cats);
        }
    }
}
