using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class AdminRoomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminRoomController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//Bir istemci oluştu
            var responseMessage = await client.GetAsync("https://localhost:44322/api/Room");//Adrese istek gönderdi
            if (responseMessage.IsSuccessStatusCode) //Eğer istek doğruysa
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//isteği jsondata atadık
                var values = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);//ve ekrana jsondata çevirip normal tabloya yansıttık 
                return View(values);//ekranda gösterdik
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddRoom()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRoom(CreateRoomDto createRoomDto)
        {
            var client = _httpClientFactory.CreateClient();//bir istemci oluştur
            var jsonData = JsonConvert.SerializeObject(createRoomDto);//parametreyi jsonData atadık
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//StringContent değişkeninni içine gerekli işlemler yapıldı
            var responseMessage = await client.PostAsync("https://localhost:44322/api/Room", stringContent);//Adrese istek gönderip eklendi
            if (responseMessage.IsSuccessStatusCode)//eğer responsemessage doğru ise 
            {
                return RedirectToAction("Index");//Indexe yönlendiriyoruz
            }
            return View();
        }

        public async Task<IActionResult> DeleteRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44322/api/Room/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRoom(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44322/api/Room/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateRoomDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRoom(UpdateRoomDto updateRoomDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateRoomDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44322/api/Room", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
