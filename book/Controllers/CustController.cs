using book.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book.Controllers
{
    public class CustController : Controller
    {
        private ICustRepository repo { get; set; }

        private ShopCart shopcart { get; set; }

        public CustController(ICustRepository temp, ShopCart c)
        {
            repo = temp;
            shopcart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new CustInfo());
        }

        [HttpPost]
        public IActionResult Checkout(CustInfo custinfo)
        {
            if (shopcart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your Cart is Empty");
            }

            if (ModelState.IsValid)
            {
                custinfo.Lines = shopcart.Items.ToArray();
                repo.SaveCust(custinfo);
                shopcart.ClearCart();

                return RedirectToPage("/Confirmation");
            }

            else
            {
                return View();
            }
        }
    }
}
