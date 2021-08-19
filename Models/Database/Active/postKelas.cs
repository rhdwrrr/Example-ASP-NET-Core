using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrigamiEdu.Models
{
    public class postKelas
    {
        public string ID { get; set; }
        public string postContent { get; set; }
        public string[] photoPath { get; set; } = new string[5];
        public bool isLocked { get; set; }
        public DateTime time { get; set; }
        public AppUser actor { get; set; }

        [NotMapped]
        public string _user { get; set; }

    }
}