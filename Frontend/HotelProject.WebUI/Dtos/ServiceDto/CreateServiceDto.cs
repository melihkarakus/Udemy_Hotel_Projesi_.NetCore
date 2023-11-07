using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage = "Hizmet icon linki giriniz.")]
        public string ServiceIcon { get; set; }//Database Entityler

        [Required(ErrorMessage = "Hizmet başlığı giriniz.")]
        [StringLength(100,ErrorMessage = "Hizmet başlığı en fazla 100 karakter olabilir.")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
