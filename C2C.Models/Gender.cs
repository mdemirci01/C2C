using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace C2C.Models
{
    public enum Gender
    {
        [Display(Name ="Erkek")]
        Male=1,
        [Display(Name ="Kadın")]
        Female=2
    }
}
