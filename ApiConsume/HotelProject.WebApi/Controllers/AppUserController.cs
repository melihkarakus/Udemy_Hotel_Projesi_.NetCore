using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserService _appUserService;

        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        //[HttpGet]
        //public IActionResult AppUserList()
        //{
        //    var values = _appUserService.TUserListWithWorkLocation();
        //    return Ok(values);
        //}
        [HttpGet]
        public IActionResult AppUserList2()
        {
            var values = _appUserService.TGetList();
            return Ok(values);
        }
    }
}
