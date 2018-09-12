using System.ComponentModel.DataAnnotations;

namespace C2C.Models
{
    public enum OrderStatus
    {
        [Display(Name = "Gönderiliyor")]
        Dispatched = 1,
        [Display(Name = "Beklemede")]
        Delayed =2,
        [Display(Name = "Teslim Edildi")]
        Delivered = 3
    }
}