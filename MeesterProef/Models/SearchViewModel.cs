using System.ComponentModel.DataAnnotations;

namespace Meesterproef.Models
{
    public class SearchViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Username")]
        [StringLength(30)]
        public string Query { get; set; }
    }
}