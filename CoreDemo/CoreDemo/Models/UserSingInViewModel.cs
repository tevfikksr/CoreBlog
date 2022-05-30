using System.ComponentModel.DataAnnotations;

namespace CoreDemo.Models
{
    public class UserSingInViewModel
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz")]
        public string username { get; set; }
        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        public string password { get; set; }
    }
}
