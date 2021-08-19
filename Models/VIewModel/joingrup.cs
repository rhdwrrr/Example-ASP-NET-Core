using System;
using System.ComponentModel.DataAnnotations;

namespace OrigamiEdu.Models
{
    public class joinGrupView
    {
        [Required]
        public string IDKelas { get; set; }
        
        public string namaKelas { get; set; }
        public string userGuide { get; set; }
        public DateTime createdDate { get; set; }
        public bool isArchived { get; set; }
        public bool isPrivate { get; set; }
        public string kreator { get; set; }
        public bool isAccesingByCode { get; set; }

        [Required]
        public bool isAgree { get; set; }
    }
}