using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace book.Models
{
    public class CustInfo
    {
        [Key]
        [BindNever]
        public int CustId { get; set; }

        [BindNever]
        public ICollection<CartLineItem> Lines { get; set; }

        [Required(ErrorMessage = "Please Enter a Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter the First Address Line")]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "Please Enter the City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter the State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please Enter the Zipcode")]
        public string Zipcode { get; set; }

        [Required(ErrorMessage = "Please Enter the Country")]
        public string Country { get; set; }

        [BindNever]
        public bool OrderPlaced { get; set; }

        //[Required(ErrorMessage = "Please Select How you would like your Product to be Shipped")]
        //public string Shipping { get; set; }

        //this will be either free shipping (5-7), preferred shipping (3-5), premium shipping (1-2)
    }
}
