using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace OrigamiEdu.Models
{
    [RequireHttps]
    public class signInModel
    {
        [NotMapped]
        [Required]
        [Display(Name = "Nama Pengguna")]
        public string username { get; set; }

        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Kata Sandi")]
        public string password { get; set; }

        // [NotMapped]
        // [Compare("password", ErrorMessage = "Kata sandi tidak cocok, mohon periksa kembali")]
        // [DataType(DataType.Password)]
        // [Display(Name = "Konfirmasi Kata Sandi")]
        // public string confirmPass { get; set; }

        [NotMapped]
        [Display(Name = "Ingat saya")]
        public bool rememberMe { get; set; }

        // [NotMapped]
        // public string ReturnUrl { get; set; }
    }
}