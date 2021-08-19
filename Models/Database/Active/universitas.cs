using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrigamiEdu.Models
{
    public class Universitas 
    {
        public Guid ID { get; set; }

        [Display(Name = "Nama Universitas")]
        [Required(ErrorMessage="Data tidak boleh kosong!")]
        public string universitas { get; set; }
        public Provinsi fkProvinsi { get; set; }
        public KategoriUniversitas fkKategoriUniversitas { get; set; }

        // ====================================================================================== //

        [NotMapped]
        public string mst_primary { get; set; }
        
        [NotMapped]
        
        public string mst_namaUniv { get; set; }
        
        [NotMapped]
        [Display(Name = "Data Provinsi")]
        [Required(ErrorMessage="Data tidak boleh kosong!")]
        public string mst_fkProvinsi { get; set; }

        [NotMapped]
        [Display(Name = "Data Kategori Universitas")]
        [Required(ErrorMessage="Data tidak boleh kosong!")]
        public string mst_fkKatUniv { get; set; }
    }
}