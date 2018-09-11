using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace C2C.Models
{
    public class ProductPhoto:BaseEntity
    {
        [Display(Name = "Ad")]
        [StringLength(200)]
        public string Name { get; set; }
        [Display(Name = "Açıklama")]
        [StringLength(200)]
        public string Description { get; set; }
        [Display(Name = "Pozisyon")]
        public int Position { get; set; }
        [Display(Name = "Ürün")]
        public string ProductId { get; set; }
        [Display(Name = "Ürün")]
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
