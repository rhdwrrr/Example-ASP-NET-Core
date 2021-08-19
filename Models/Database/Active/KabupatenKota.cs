using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OrigamiEdu.Models
{
    public class KabupatenKota
    {
        public Guid ID { get; set; }

        [Required]
        [Display(Name = "Nama Kabupaten/Kota")]
        [Column(TypeName = "Varchar(50)")]
        public string kabupatenKota { get; set; }
        public Provinsi fkProvinsi { get; set; }
                   
        // ========================================================== //
        [NotMapped]
        public string mst_primary { get; set; }

        [NotMapped]
        public string mst_namaKabKota { get; set; }

        [NotMapped]
        public string mst_namaProvinsi { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "Data Provinsi")]
        public string mst_primaryProvinsi { get; set; }
        
        [NotMapped]
        public bool selected { get; set; }

        [NotMapped]
        public List<Provinsi> provinsiList { get; set; }
    }
}