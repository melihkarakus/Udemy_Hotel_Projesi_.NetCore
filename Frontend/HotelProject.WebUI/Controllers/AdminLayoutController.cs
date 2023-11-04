using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult _AdminLayout()
        {
            return View();
        }
        public IActionResult HeadPartial()
        {
            return PartialView();
        }
        public IActionResult PreloaderPartial()
        {
            return PartialView();
        }
        public IActionResult NavheaderPartial()
        {
            return PartialView();
        }
        public IActionResult HeaderPartial()
        {
            return PartialView();
        }
        public IActionResult SidebarPartial()
        {
            return PartialView();
        }
        public IActionResult FooterPartial()
        {
            return PartialView();
        }
        public IActionResult ScriptPartial()
        {
            return PartialView();
        }
    }
}
