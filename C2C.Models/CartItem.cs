using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace C2C.Models
{
   public class CartItem
    {
        [Display(Name="Ürün")]
        public string ProductId { get; set; }
        [ForeignKey("ProductId")]
        [Display(Name = "Ürün")]
        public string Product { get; set; }
        [Display(Name = " Ürün Miktarı")]
        public int Quantity { get; set; }
        [Display(Name = "Kart")]
        public string CartId { get; set; }
        [ForeignKey("CartId")]
        [Display(Name = "Kart")]
        public Cart Cart { get; set; }
    }
}
