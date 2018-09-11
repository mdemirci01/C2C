using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace C2C.Models
{
    public class Customer:BaseEntity
    {
        [Display(Name="Ad:")]
        [StringLength(200)]
        public string FirstName { get; set; }
        [Display(Name = "Soyad:")]
        [StringLength(200)]
        public string LastName { get; set; }
        [Display(Name = "Cinsiyet:")]
        public Gender Gender { get; set; }
        [Display(Name = "Doğum Tarihi:")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Email:")]
        [StringLength(200)]
        public string Email { get; set; }
        [Display(Name = "Teslimat Adresi:")]
        public string ShippingAddress { get; set; }
        [Display(Name = "Fatura Adresi:")]
        public string InvoiceAddress { get; set; }
    }
}
