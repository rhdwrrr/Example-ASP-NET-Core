using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrigamiEdu.Models
{
    public class Provinsi
    {
        public Guid ID { get; set; }

        [Display(Name = "Nama Provinsi")]
        [Column(TypeName = "varchar(25)")]
        [Required]
        public string provinsi { get; set; }
        
        [NotMapped]
        public string mst_primary { get; set; }
        
        [NotMapped]
        public string mst_namaProvinsi { get; set; }
        
        [NotMapped]
        public bool selected { get; set; }
        
    }
}