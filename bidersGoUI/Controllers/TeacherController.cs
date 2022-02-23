using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bidersGoUI.Controllers
{
    public class TeacherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SetWorkingHours()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SetWorkingHours(string a)
        {
            return Json("deneme");
        }
    }
}
