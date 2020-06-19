using System.ComponentModel.DataAnnotations;

namespace Meesterproef.Models
{
    public class PartyViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [StringLength(20)]
        public string Abbreviation { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(100)]
        public string Leader { get; set; }
    }
}