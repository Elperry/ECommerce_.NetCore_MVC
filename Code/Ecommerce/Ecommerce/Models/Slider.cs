using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Slider
    {
        public int SliderId { get; set; }

        [Display(Name ="image")]
        public string SliderImgUrl { get; set; }
    }
}
