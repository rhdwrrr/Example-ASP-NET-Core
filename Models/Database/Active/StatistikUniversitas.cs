using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrigamiEdu.Models
{
    public class statistikUniversitas
    {
        public Guid ID { get; set; }
        public Universitas fkUniv { get; set; }

        public int year { get; set; }

        public double peminat { get; set; }
        public double kuota { get; set; }

        // ========================================================== //

        [NotMapped]
        [Display(Name = "Key")]
        public string mst_primary { get; set; }
        [NotMapped]
        [Display(Name = "Data Universitas")]
        public string mst_primaryUniversitas { get; set; }
        [NotMapped]
        [Display(Name = "Tahun")]
        public int mst_year { get; set; }
        [NotMapped]
        [Display(Name ="Jumlah Peminat")]
        public double mst_peminat { get; set; }
        [NotMapped]
        [Display(Name = "Jumlah Kuota")]
        public double mst_kuota { get; set; }
        [NotMapped]
        [Display(Name = "Nama Universitas")]
        public string mst_namaUniversitas { get; set; }
    }
}