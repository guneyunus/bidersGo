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
        private readonly IMediator _mediator;
        public AccountController(SignInManager<ApplicationUser> signInManager, IMediator mediator)
        {
            _signInManager = signInManager;
            _mediator = mediator;
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
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı..");
                return View(request);

            }

        }
    }
}
