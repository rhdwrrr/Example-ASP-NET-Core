using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using OrigamiEdu.Utilities;

namespace OrigamiEdu.Models
{
    [RequireHttps]
    public class signUpModel
    {
        [NotMapped]
        [Required]
        [EmailAddress]
        [Remote(action: "isEmailValid", controller: "Akun")]
        // [ValidEmailDomain(allowedDomain: new string[] {"gmail.com", "protonmail.com", "pm.me", "outlook.com", "hotmail.com"}, ErrorMessage = "Saat ini, alamat surel Anda belum didukung")]
        [Display(Name = "Alamat Surel")]
        public string email { get; set; }

        [NotMapped]
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Kata Sandi")]
        public string password { get; set; }

        [NotMapped]
        [Compare(otherProperty: "password", ErrorMessage = "Kata sandi tidak cocok, mohon periksa kembali")]
        [DataType(DataType.Password)]
        [Display(Name = "Konfirmasi Kata Sandi")]
        public string confirmPass { get; set; }

        [NotMapped]
        [Display(Name = "Nama Pengguna")]
        // [Remote(action: "isUsernameValid", controller: "Akun")]
        [RegularExpression(pattern: @"(?!.*\.\.)(?!.*\.$)[^\W][\w.]{0,20}", ErrorMessage = "Nama pengguna tidak valid")]
        public string username { get; set; }

        [NotMapped]
        [Display(Name = "Jenis Kelamin")]
        [Required]
        public string sex { get; set; }

        // [NotMapped]
        // [Display(Name = "Ingat saya")]
        // public bool rememberMe { get; set; }

        // [NotMapped]
        // public string ReturnUrl { get; set; }
    }
}