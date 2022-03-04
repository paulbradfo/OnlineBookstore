using book.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private ShopCart cart;

        public CartSummaryViewComponent(ShopCart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
