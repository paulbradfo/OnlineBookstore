using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace book.Models
{
    public class ShopCart
    {
        public List<CartLineItem> Items { get; set; } = new List<CartLineItem>();

        public virtual void AddItem(Books bo, int qty) 
        {
            CartLineItem line = Items.Where(b => b.Book.BookId == bo.BookId).FirstOrDefault();

            if (line == null)
            {
                Items.Add(new CartLineItem
                {
                    Book = bo,
                    Quantity = qty
                });
            }

            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveItem(Books bo)
        {
            Items.RemoveAll(x => x.Book.BookId == bo.BookId);
        }

        public virtual void ClearCart()
        {
            Items.Clear();
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Book.Price * x.Quantity);

            return sum;
        }
    }

    public class CartLineItem
    {
        [Key]
        public int LineID { get; set; }

        public Books Book { get; set; }

        public int Quantity { get; set; }

    }
}
