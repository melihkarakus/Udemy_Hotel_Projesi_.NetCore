using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileImageController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm]IFormFile file)//File tanımlama yapılması gerekiyor
        {
            // Dosya için benzersiz bir ad oluştur
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

            // Dosyanın tam yolunu oluştur
            var path = Path.Combine(Directory.GetCurrentDirectory(), "images/" + fileName);

            // FileStream oluştur ve dosyayı oluştur veya varsa üzerine yaz
            var stream = new FileStream(path, FileMode.Create);

            // Dosyanın içeriğini FileStream'e kopyala (asenkron olarak)
            await file.CopyToAsync(stream);

            // HTTP 201 Created yanıtı ile işlemi tamamla
            return Created("", file);
        }
    }
}
