using BookStore.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Model
{
    public class BookModel
    {
        //[DataType(DataType.EmailAddress)]
        //[Display(Name="choose Email Address")]
        //[EmailAddress]
        //public string MyField { get; set; }
        public int Id { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Please enter the Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the Description")]
        public string Author { get; set; }
        [StringLength(500)]
        public string Description { get; set; }

        public string Category { get; set; }
        [Required(ErrorMessage ="Please choose the language")]
        public int LanguageId { get; set; }
        public string Language { get; set; }
        [Required(ErrorMessage = "Please enter the Total Page")]
        [Display(Name ="Total Pages of the book")]
        public int? TotalPages { get; set; }
    }
}
