using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace C2C.Models
{
    public class Product:BaseEntity
    {
        [Display(Name = "Ad")]
        [StringLength(200)]
        public string Name { get; set; }
        [Display(Name = "Bağlantı")]
        [StringLength(200)]
        public string Slug { get; set; }
        [Display(Name = "Kısa Açıklama")]
        public string ShortDescription { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Ek Bilgi")]
        public string AdditionalInformation { get; set; }
        [Display(Name = "Eski Fiyat")]
        public decimal OldPrice { get; set; }
        [Display(Name = "Liste Fiyatı")]
        public decimal Price { get; set; }
        [Display(Name = "Yayında Mı?")]
        public bool IsPublished { get; set; }
        public virtual ICollection<ProductPhoto> ProductPhotos { get; set; }
        [Display(Name = "Kategori")]
        public string CategoryId { get; set; }
        [Display(Name = "Kategori")]
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [Display(Name = "Bulunurluk")]
        public Availibility Availibility { get; set; }
        [Display(Name = "Para Birimi")]
        public Currency Currency { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }

    }
}
