using System;
using System.ComponentModel.DataAnnotations;

namespace C2C.Models
{
    public class BaseEntity
    {
        public string Id { get; set; }
        [Display(Name = "Oluşturan")]
        public string CreatedBy { get; set; }
        [Display(Name = "Oluşturulma")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Güncelleyen")]
        public string UpdatedBy { get; set; }
        [Display(Name = "Güncelleme")]
        public DateTime UpdatedAt { get; set; }
        [Display(Name = "Silindi Mi?")]
        public bool IsDeleted { get; set; }
        [Display(Name = "Silen")]
        public string DeletedBy { get; set; }
        [Display(Name = "Silinme")]
        public DateTime DeletedAt { get; set; }
        [Display(Name = "IP Adresi")]
        [StringLength(50)]
        public string IpAddress { get; set; }
    }
}
