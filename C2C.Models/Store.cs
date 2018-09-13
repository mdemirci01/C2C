using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace C2C.Models
{
    public class Store : BaseEntity
    {
        [Display(Name = "Ad")]
        [StringLength(200)]
        public string Name { get; set; }
        [Display(Name = "Bağlantı")]
        [StringLength(200)]
        public string Slug { get; set; }
        [Display(Name = "Logo")]
        [StringLength(200)]
        public string Logo { get; set; }
        [Display(Name = "Açıklama")]
        [StringLength(200)]
        public string Description { get; set; }
        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }
        [Display(Name = "Değerlendirme")]
        public int Rating { get; set; }
        [Display(Name = "Adres")]
        [StringLength(200)]
        public string Address { get; set; }
        [Display(Name = "Telefon")]
        [StringLength(200)]
        public string Phone { get; set; }
        [Display(Name = "E-mail")]
        [StringLength(200)]
        public string Email { get; set; }
        [Display(Name = "Mağaza Sahibi")]
        [StringLength(200)]
        public string Owner { get; set; }
        [Display(Name = "İletişim Adı")]
        [StringLength(200)]
        public string ContactName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
