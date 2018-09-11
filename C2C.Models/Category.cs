using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace C2C.Models
{
    public class Category:BaseEntity
    {
        [Display(Name = "Ad")]
        [StringLength(200)]
        public string Name { get; set; }
        [Display(Name = "Bağlantı")]
        [StringLength(200)]
        public string Slug { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Resim")]
        [StringLength(200)]
        public string Photo { get; set; }
        [Display(Name = "Üst Kategori")]
        public string ParentCategoryId { get; set; }
        [Display(Name = "Üst Kategori")]
        [ForeignKey("ParentCategoryId")]
        public Category ParentCategory { get; set; }
        public virtual ICollection<Category> ChildCategories { get; set; }
    }
}
