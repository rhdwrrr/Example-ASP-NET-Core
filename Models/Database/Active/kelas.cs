using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrigamiEdu.Models
{
    public class kelas
    {
        public string ID { get; set; }

        [Column(TypeName = "varchar(60)")]
        [Required]
        [Display(Name = "Nama Kelas")]
        public string nama { get; set; }
        public AppUser fkCreator{ get; set; }

        [Required]
        [Display(Name = "Peraturan Kelas")]
        public string userGuide { get; set; }
        public DateTime createdDate { get; set; }
        public bool isArchived { get; set; }

        [Display(Name = "Kelas bersifat rahasia")]
        public bool isPrivate { get; set; }
        public bool isAllowedToPost { get; set; }

        [NotMapped]
        public string kreator { get; set; }
        
        [NotMapped]
        public Int64 countAnggota { get; set; }

        [NotMapped]
        public bool isAccesingByCode { get; set; }

    }
}