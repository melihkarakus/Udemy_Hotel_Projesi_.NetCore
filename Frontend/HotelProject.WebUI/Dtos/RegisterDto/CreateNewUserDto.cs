using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        public string Name { get; set; }
       
        [Required(ErrorMessage = "Soyad alanı boş geçilemez")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı alanı boş geçilemez")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Mail alanı boş geçilemez")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş geçilemez")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre tekrar alanı boş geçilemez")]
        [Compare("Password",ErrorMessage = "Şifreler uyuşmuyor")]   
        public string ConfirmPassword { get; set; }
    }
}
