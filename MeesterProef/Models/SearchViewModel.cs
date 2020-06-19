using System.ComponentModel.DataAnnotations;

namespace Meesterproef.Models
{
    public class SearchViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Partij Afkorting")]
        [StringLength(20)]
        public string Query { get; set; }
    }
}