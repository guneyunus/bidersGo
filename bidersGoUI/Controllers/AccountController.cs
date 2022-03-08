using bidersGo.Application.Features.Commands.AdminCreate;
using bidersGo.Application.Features.Commands.ModeratorCreate;
using bidersGo.Application.Features.Commands.StudentCreate;
using bidersGo.Application.Features.Commands.TeacherCreate;
using bidersGo.Application.Features.Queries.LessonGetAll;
using bidersGo.Application.Features.Queries.UserGetById;
using bidersGo.Domain.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult RegisterAdmin()
        {
            return View();
        }

        public async Task<IActionResult> RegisterAdmin(AdminCreateCommandRequest request)
        {
            AdminCreateCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult RegisterStudent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterStudent(StudentCreateCommandRequest request)
        {
            StudentCreateCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> RegisterTeacher()
        {
            LessonGetAllQueryResponse response = await _mediator.Send(new LessonGetAllQueryRequest());
            ViewBag.Lessons = response.LessonGetAll;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RegisterTeacher(TeacherCreateCommandRequest request)
        {
            TeacherCreateCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        public IActionResult RegisterModerator()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterModerator(ModeratorCreateCommandRequest request)
        {
            ModeratorCreateCommandResponse response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
