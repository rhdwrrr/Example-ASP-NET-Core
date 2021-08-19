using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OrigamiEdu.Models
{
    public class KategoriUniversitas
    {
        public Guid ID { get; set; }

        [Required(ErrorMessage="Data tidak boleh kosong!")]
        public string katgUniv { get; set; }

        [NotMapped]
        public string mst_primary { get; set; }
    
        [NotMapped]
        
        public string mst_namaKatUniv { get; set; }

        [NotMapped]
        // [Required(ErrorMessage="Data tidak boleh kosong!")]
        public bool selected { get; set; }
    }
}