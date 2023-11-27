using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HotelProject.WebUI.Controllers
{
    public class AdminFileController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            // Yeni bir MemoryStream oluştur
            var stream = new MemoryStream();

            // Dosyanın içeriğini MemoryStream'e kopyala (asenkron olarak)
            await file.CopyToAsync(stream);

            // MemoryStream'i byte dizisine dönüştür
            var bytes = stream.ToArray();

            // Byte dizisini içeren bir ByteArrayContent oluştur
            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);

            // Dosyanın MIME türüne göre içerik tipini ayarla
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            // Multipart form verisi içeren bir MultipartFormDataContent oluştur
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();

            // ByteArrayContent'i MultipartFormDataContent'e ekle
            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);

            // HTTP isteğini gerçekleştirmek için yeni bir HttpClient oluştur
            var httpClient = new HttpClient();

            // API'ye POST isteği gönder ve yanıtı al
            var responseMessage = await httpClient.PostAsync("http://Localhost:44322/api/FileProcess", multipartFormDataContent);

            // İşlem tamamlandığında bir görünüm döndür
            return View();
        }
    }
}
