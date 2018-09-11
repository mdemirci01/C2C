using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace C2C.Models
{
   public  class Cart
    {
        [Display(Name = "Total")]
        public decimal Total { get; }
        public ICollection<CartItem> CartItems { get; set; }
    }
}
