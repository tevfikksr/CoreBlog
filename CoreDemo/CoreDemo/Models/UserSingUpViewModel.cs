﻿using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSingUpViewModel
    {
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Lütfen Ad Soyad Giriniz")]
        public string NameSurname { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "Lütfen Mail Adresi Giriniz")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı Giriniz")]
        [Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")]
        public string UserName { get; set; }

    }
}
