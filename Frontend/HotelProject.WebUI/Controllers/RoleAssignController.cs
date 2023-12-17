using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class RoleAssignController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            // Kullanıcıyı kullanıcı yöneticisinden (UserManager) belirtilen 'id' ile bul.
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);

            // TempData kullanarak kullanıcı kimliğini geçici olarak sakla.
            TempData["userid"] = user.Id;

            // Rol yöneticisinden (RoleManager) tüm rolleri al.
            var roles = _roleManager.Roles.ToList();

            // Kullanıcının sahip olduğu rolleri al.
            var userRoles = await _userManager.GetRolesAsync(user);

            // Rol atama görünüm modellerini içerecek bir liste oluştur.
            List<RoleAssignViewModel> roleAssignViewModels = new List<RoleAssignViewModel>();

            // Tüm roller için döngü başlat.
            foreach (var item in roles)
            {
                // Her rol için bir RoleAssignViewModel oluştur.
                RoleAssignViewModel roleAssignViewModel = new RoleAssignViewModel();

                // RoleAssignViewModel'e rol kimliği ve adını ata.
                roleAssignViewModel.RoleID = item.Id;
                roleAssignViewModel.RoleName = item.Name;

                // Kullanıcının bu role sahip olup olmadığını kontrol et ve RoleExist özelliğine ata.
                roleAssignViewModel.RoleExist = userRoles.Contains(item.Name);

                // Oluşturulan RoleAssignViewModel'i listeye ekle.
                roleAssignViewModels.Add(roleAssignViewModel);
            }

            // Rol atama görünüm modellerini içeren listeyi view'e gönder.
            return View(roleAssignViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> roleAssignViewModel)
        {
            var userid = (int)TempData["userid"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach (var item in roleAssignViewModel)
            {
                if (item.RoleExist)
                {
                    await _userManager.AddToRoleAsync(user, item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
