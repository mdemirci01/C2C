using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace C2C.Models
{
    public enum Availibility
    {
        [Display(Name = "Stokta Var")]
        InStock = 1,
        [Display(Name = "Stokta Yok")]
        NotAvailable = 2
    }
}
