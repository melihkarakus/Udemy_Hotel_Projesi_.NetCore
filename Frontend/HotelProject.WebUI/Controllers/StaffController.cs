using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//Bir istemci oluştu
            var responseMessage = await client.GetAsync("https://localhost:44322/api/Staff");//Adrese istek gönderdi
            if (responseMessage.IsSuccessStatusCode) //Eğer istek doğruysa
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();//isteği jsondata atadık
                var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);//ve ekrana jsondata çevirip normal tabloya yansıttık 
                return View(values);//ekranda gösterdik
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddStaff()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddStaff(AddStafViewModel addStafViewModel)
        {
            var client = _httpClientFactory.CreateClient();//bir istemci oluştur
            var jsonData = JsonConvert.SerializeObject(addStafViewModel);//parametreyi jsonData atadık
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");//StringContent değişkeninni içine gerekli işlemler yapıldı
            var responseMessage = await client.PostAsync("https://localhost:44322/api/Staff", stringContent);//Adrese istek gönderip eklendi
            if (responseMessage.IsSuccessStatusCode)//eğer responsemessage doğru ise 
            {
                return RedirectToAction("Index");//Indexe yönlendiriyoruz
            }
            return View();
        }

        public async Task<IActionResult> DeleteStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44322/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStaff(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44322/api/Staff/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateStaffViewModel>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStaff(UpdateStaffViewModel updateStaffViewModel)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateStaffViewModel);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44322/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
