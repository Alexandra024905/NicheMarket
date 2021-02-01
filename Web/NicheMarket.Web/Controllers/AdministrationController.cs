using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NicheMarket.Web.Models.ViewModels;
using System.Threading.Tasks;

namespace NicheMarket.Web.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }       

        [HttpPost("/Administration/CreateRole")]
        public async Task<IActionResult> CreateRole (CreateRoleViewModel createRoleViewModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = createRoleViewModel.RoleName
                };
                IdentityResult identityResult = await this.roleManager.CreateAsync(identityRole);

                if (identityResult.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                foreach(IdentityError error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(createRoleViewModel);
        }

    }
}
