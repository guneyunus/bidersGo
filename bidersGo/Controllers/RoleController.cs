using bidersGo.DataAcces.Conctare;
using bidersGo.Models;
using bidersGo.Models.Identity;
using bidersGo.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bidersGo.Controllers
{

    public class RoleController : Controller
    {
        readonly RoleManager<ApplicationRole> _roleManager;
        readonly UserManager<ApplicationUser> _userManager;
        private readonly BidersGoContext _context;
        public RoleController(RoleManager<ApplicationRole> roleManager, UserManager<ApplicationUser> userManager, BidersGoContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }
        public async Task<IActionResult> RoleAssign(string id)
        {

            var user = await _userManager.FindByIdAsync(id);

            var userRoles = _userManager.GetRolesAsync(user).Result.ToList();

            var allRoles = _roleManager.Roles.ToList();

            var model = new RoleAssignViewModel();
            foreach (var role in allRoles)
            {
                model.UserRoles.Add(new RoleListViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    Selected = userRoles.Contains(role.Name)
                });
            }
            model.RoleUserAssignViewModel = new RoleUserAssignViewModel
            {
                Email = user.Email,
                UserId = user.Id,
                UserName = user.UserName,
                UserRoles = userRoles
            };

            //return View(assignRoles);
            return View(model);


        }
        [HttpPost]
        public async Task<ActionResult> RoleAssign(string id, RoleUserAssignViewModel model)
        {
            var user = await _userManager.FindByIdAsync(id);

            var userRoles = _userManager.GetRolesAsync(user).Result.ToList();
            var allRoles = _roleManager.Roles.ToList();
            await _userManager.RemoveFromRolesAsync(user, userRoles); //tablolardaki kullanıcı rollerini siliyoruz
            var model1 = new RoleAssignViewModel();
            foreach (var role in allRoles)
            {
                model1.UserRoles.Add(new RoleListViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                    Selected = userRoles.Contains(role.Name)
                });

                model1.RoleUserAssignViewModel = new RoleUserAssignViewModel
                {
                    Email = user.Email,
                    UserId = user.Id,
                    UserName = user.UserName,
                    UserRoles = userRoles
                };
                
            }
            foreach (var item in model.UserRoles)
            {
                await _userManager.AddToRoleAsync(user, item); //kullacıya yeni sectiğimiz kullanıcı rollerini atıyoruz.
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
