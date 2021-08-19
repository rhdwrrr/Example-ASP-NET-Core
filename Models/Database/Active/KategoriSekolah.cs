using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrigamiEdu.Models
{
    public class KategoriSekolah
    {
        public Guid ID { get; set; }

        [Display(Name = "Nama Kategori")]
        [Required(ErrorMessage="Data tidak boleh kosong!")]
        public string namaKategori { get; set; }

        // =========================================================================== //

        [NotMapped]
        public string mst_primary { get; set; }

        [NotMapped]
        public string mst_namaKtg { get; set; }

        [NotMapped]
        public bool selected { get; set; }

        // [NotMapped]
        // public string[] mst_jurusan { get; set; }

        // [NotMapped]
        // [Required(ErrorMessage="Data tidak boleh kosong!")]
        // public string mst_inputJur { get; set; }
    }
}