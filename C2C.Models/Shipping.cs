using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace C2C.Models
{
    public class Shipping:BaseEntity
    {
        [Display(Name = "Ad")]
        [StringLength(200)]
        public string Name { get; set; }
    }
}
