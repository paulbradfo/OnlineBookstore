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

        public ShopCart cart { get; set; }

        public string ReturnUrl { get; set; }

        public CartModel(IbookRepository temp, ShopCart c)
        {
            repo = temp;
            cart = c;
        }   

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Books b = repo.Books.FirstOrDefault(x => x.BookId == bookId);

            cart.AddItem(b, 1);

            return RedirectToPage( new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            cart.RemoveItem(cart.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
