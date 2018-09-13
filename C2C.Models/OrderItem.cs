using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace C2C.Models
{
    public class OrderItem:BaseEntity
    {
        [Display(Name = "Sipariş")]
        public string OrderId { get; set; }
        [Display(Name = "Sipariş")]
        [ForeignKey("OrderId")]
        public string ProductId { get; set; }
        [Display(Name = "Ürün")]
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }
        [Display(Name = "Fiyatı")]
        public decimal Price { get; set; }
        [Display(Name = "Miktarı")]
        public int Quantity { get; set; }
        [Display(Name = "Ara Tutar")]
        public decimal SubTotal { get; set; }
        [Display(Name = "Kargo Tutarı")]
        public decimal ShippingTotal { get; set; }
        [Display(Name = "Vergi")]
        public int Tax { get; set; }
        [Display(Name = "Nakliye")]
        public string ShippingId { get; set; }
        [Display(Name = "Nakliye")]
        [ForeignKey("ShippingId")]
        public Shipping Shipping { get; set; }


    }
}