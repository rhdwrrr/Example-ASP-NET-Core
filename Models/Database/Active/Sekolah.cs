using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OrigamiEdu.Models
{
    public class Sekolah{
        public Guid ID { get; set; }

        [Display(Name = "Nama Sekolah")]
        [Required(ErrorMessage="Data tidak boleh kosong!")]
        public string sekolah { get; set; }
        public KabupatenKota fkKabupatenKota { get; set; }
        public KategoriSekolah fkKategoriSekolah { get; set; }
        
        //===========================================================//
        [NotMapped]
        public string mst_primary { get; set; }
        
        [NotMapped]
        public string mst_namaSekolah { get; set; }

        [NotMapped]
        public string mst_KatgName { get; set; }
        
        [NotMapped]
        [Display(Name = "Data Kabupaten")]
        [Required(ErrorMessage="Data tidak boleh kosong!")]
        public string mst_fkKab { get; set; }


        [NotMapped]
        public string mst_loc { get; set; }

        [NotMapped]
        [Display(Name = "Data Kategori Sekolah")]
        [Required(ErrorMessage="Data tidak boleh kosong!")]
        public string mst_primaryKtg { get; set; }
        
        [NotMapped]
        [Display(Name = "Data Provinsi")]
        [Required(ErrorMessage="Data tidak boleh kosong!")]
        public string mst_primaryProvinsi { get; set; }

        [NotMapped]
        public List<Provinsi> listProvinsi { get; set; }

        [NotMapped]
        public List<KabupatenKota> listKabKota { get; set; }
        
        
    }
}