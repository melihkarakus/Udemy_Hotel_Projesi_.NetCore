using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class UpdateServiceDto
    {
        public int ServiceID { get; set; } //Database Entityleri
        [Required(ErrorMessage = "Lütfen icon linki giriniz")]
        public string ServiceIcon { get; set; }
        [Required(ErrorMessage = "Lütfen başlık giriniz.")]
        [StringLength(100,ErrorMessage = "Lütfen en fazla 100 karakter giriniz.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Lütfen açıklama giriniz.")]
        [StringLength(100, ErrorMessage = "Lütfen en fazla 100 karakter giriniz.")]
        public string Description { get; set; }
    }
}
