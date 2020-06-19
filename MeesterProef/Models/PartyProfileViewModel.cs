using System.ComponentModel.DataAnnotations;

namespace Meesterproef.Models
{
    public class PartyProfileViewModel
    {
        [Required]
        [Display(Name = "Stemmen")]
        [RegularExpression(@"^[1-9]\d*$", ErrorMessage = "Only integer values are allowed.")]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public int Votes { get; set; }
    }
}