using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrigamiEdu.Models
{
    public class editRole
    {
        [NotMapped]
        [Display(Name = "Key Role")]
        public string idRole { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "Nama Role")]
        public string RoleName { get; set; }

        [NotMapped]
        [Display(Name = "Daftar User")]
        public List<string> users { get; set; } = new List<string>();
    }
}