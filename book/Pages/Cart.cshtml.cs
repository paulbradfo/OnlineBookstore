using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using book.Infrastructure;
using book.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace book.Pages
{
    public class CartModel : PageModel
    {
        private IbookRepository repo { get; set; }

        public CartModel(IbookRepository temp)
        {
            repo = temp;
        }

        public ShopCart cart { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";

            cart = HttpContext.Session.GetJson<ShopCart>("cart") ?? new ShopCart(); ;
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            cart = HttpContext.Session.GetJson<ShopCart>("cart") ?? new ShopCart();

            cart.AddItem(b, 1);

            HttpContext.Session.SetJson("cart", cart);

            return RedirectToPage( new { ReturnUrl = returnUrl });
        }
    }
}
