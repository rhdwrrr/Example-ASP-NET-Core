using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrigamiEdu.Models
{
    public class createRole
    {
        [NotMapped]
        [Required]
        [Display(Name = "Nama Role")]
        public string RoleName { get; set; }
    }
}