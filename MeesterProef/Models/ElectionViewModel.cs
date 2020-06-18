using System;
using System.ComponentModel.DataAnnotations;

namespace Meesterproef.Models
{
    public class ElectionViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Verkiezing Naam")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Max Zetels")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only integer values are allowed.")]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int DistributableSeats { get; set; }

        [Required]
        [Display(Name = "Datum")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}