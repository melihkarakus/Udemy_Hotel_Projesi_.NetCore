using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {
        //instagram Api 
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //İnstagram rapid apiden gelen httpclient kodu - 
            //İnstagram verilerimizi çeker.
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-profile1.p.rapidapi.com/getprofileinfo/melihefex"),
                Headers =
    {
        { "X-RapidAPI-Key", "58e621d680msh2f5df1473676306p1efb2ejsn1d47b59a39b7" },
        { "X-RapidAPI-Host", "instagram-profile1.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                ResultInstagramFollowersDto resultInstagramFollowersDto = JsonConvert.DeserializeObject<ResultInstagramFollowersDto>(body);
                ViewBag.instagramTakip = resultInstagramFollowersDto.following;
                ViewBag.instagramTakici = resultInstagramFollowersDto.followers;
            }


            
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-profile-data.p.rapidapi.com/get-linkedin-profile?linkedin_url=https%3A%2F%2Fwww.linkedin.com%2Fin%2Fmelih-karakus-830a56196%2F&include_skills=false"),
                Headers =
    {
        { "X-RapidAPI-Key", "58e621d680msh2f5df1473676306p1efb2ejsn1d47b59a39b7" },
        { "X-RapidAPI-Host", "fresh-linkedin-profile-data.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                ResultLinkedInFollowersDto resultLinkedInFollowersDto = JsonConvert.DeserializeObject<ResultLinkedInFollowersDto>(body2);
                ViewBag.LinkedinTakip = resultLinkedInFollowersDto.data.followers_count;
                ViewBag.LinkedinTakipEdilen = resultLinkedInFollowersDto.data.connections_count;
            }
            return View();
        }
    }
}
