using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace C2C.Models
{
    public class Review:BaseEntity
    {
        [Display(Name = "Ad")]
        [StringLength(200)]
        public string Name { get; set; }
        [Display(Name = "E-posta")]
        [StringLength(200)]
        public string Email { get; set; }
        [Display(Name = "Geribildirim")]
        public string Body { get; set; }
        [Display(Name = "Oylama")]
        public int Rating { get; set; }
        [Display(Name = "Onaylandı Mı?")]
        public bool IsApproved { get; set; }
        [Display(Name = "Onaylayan")]
        public string ApprovedBy { get; set; }
        [Display(Name = "Onaylama")]
        public DateTime ApprovedAt { get; set; }
        [Display(Name = "Ürün")]
        public string ProductId { get; set; }
        [Display(Name = "Ürün")]
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
