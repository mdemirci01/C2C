using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace C2C.Models
{
   public class Cart:BaseEntity
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }
        public string Owner { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        [NotMapped]
        public decimal TotalPrice
        {
            get
            {
                return CartItems.Sum(c => c.TotalPrice);
            }
        }
    }
}
