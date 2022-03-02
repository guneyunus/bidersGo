using bidersGo.Application.Features.Queries.UserGetById;
using bidersGo.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace bidersGoUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMediator _mediator;
        public AccountController(SignInManager<ApplicationUser> signInManager, IMediator mediator, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _mediator = mediator;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserGetByIdQueryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }
            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password, true, false);

            if (result.Succeeded)
            {

                //1.adım usernameden userı bul
                var user = await _userManager.FindByNameAsync(request.UserName);

                //2.adım userın rolunu tespit et
                var role = await _userManager.GetRolesAsync(user);

                if (role[0] == "Admin")
                {
                    return RedirectToAction("Users", "Admin");
                }
                else if (role[0] == "Teacher")
                {
                    return RedirectToAction("Index", "Teacher");

                }
                else if (role[0] == "Student")
                {
                    return RedirectToAction("Index", "Student");

                }
                else if (role[0] == "Moderator")
                {
                    return RedirectToAction("Index", "Moderator");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

                //3.userin rolune göre controllerina yönlendir
                
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı..");
                return View(request);

            }

        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
