using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace C2C.Models
{
    public class Coupon:BaseEntity
    {
        [Display(Name = "Ad")]
        [StringLength(200)]
        public string Name { get; set; }
        [Display(Name = "Kupon Kodu")]
        [StringLength(200)]
        public string Code { get; set; }
        [Display(Name = "İndirim")]
        public decimal Discount { get; set; }
        [Display(Name = "Geçerlilik Tarihi")]
        public DateTime ExpireDate { get; set; }
        [Display(Name = "Aktif Mi?")]
        public bool IsActive { get; set; }
    }
}
