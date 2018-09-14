using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace C2C.Models
{
    public class Order:BaseEntity
    {        
        [Display(Name = "Kart")]
        public string CartId { get; set; }
        [Display(Name = "Kart")]
        [ForeignKey("CartId")]
        public Cart Cart { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        [Display(Name = "Sipariş Tarihi")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Sipariş Durumu")]
        public OrderStatus OrderStatus { get; set; }
        [Display(Name = "Kupon")]
        public string CouponId { get; set; }
        [Display(Name = "Kupon")]
        [ForeignKey("CouponId")]
        public Coupon Coupon { get; set; }
        [Display(Name = "Sipariş Ara Tutarı")]
        public decimal OrderSubtotal { get; set; }
        [Display(Name = "İndirim Tutarı")]
        public decimal DiscountTotal { get; set; }
        [Display(Name = "Kargo Tutarı")]
        public decimal ShippingTotal { get; set; }
        [Display(Name = "Vergi Tutarı")]
        public decimal TaxTotal { get; set; }
        [Display(Name = "Sipariş Toplam Tutarı")]
        public decimal OrderTotal { get; set; }
        public string PaymentMethod { get; set; }
        [Display(Name = "Müşteri")]
        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        [Display(Name = "Müşteri")]
        public Customer Customer { get; set; }

    }
}
