using System;
using Microsoft.AspNetCore.Identity;

namespace OrigamiEdu.Models
{
    public class AppUser : IdentityUser
    {
        // public KabupatenKota fkKabupatenKota { get; set; }
        public bool isBanned { get; set; }
        public DateTime bannedUntil { get; set; }
        public DateTime joinDate { get; set; }
        public DateTime birthday { get; set; }
        public string gender { get; set; }
        public Sekolah fkSekolah { get; set; }
        public string jurusanSekolah { get; set; }
        public double tryOutTokens { get; set; }
        public bool isSetupInProgress { get; set; }
        public int setupType { get; set; }
    }
}