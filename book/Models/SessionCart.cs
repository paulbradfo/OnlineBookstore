using book.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace book.Models
{
    public class SessionCart : ShopCart
    {
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SessionCart cart = session?.GetJson<SessionCart>("ShopCart") ?? new SessionCart();

            cart.Session = session;

            return cart;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddItem(Books bo, int qty)
        {
            base.AddItem(bo, qty);
            Session.SetJson("ShopCart", this);
        }

        public override void RemoveItem(Books bo)
        {
            base.RemoveItem(bo);
            Session.SetJson("ShopCart", this);
        }

        public override void ClearCart()
        {
            base.ClearCart();
            Session.Remove("ShopCart");
        }
    }
}
