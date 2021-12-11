using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Enums
{
    public enum LanguageEnum
    {
        [Display(Name ="English Language")]
        English =12,
        [Display(Name = "Hindi Language")]
        Hindi =13,
        [Display(Name = "French Language")]
        French =14,
        [Display(Name = "Urdu Language")]
        Urdu =15,
        [Display(Name = "Dutch Language")]
        Dutch =16
    }
}
