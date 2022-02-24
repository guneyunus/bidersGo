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
        //[HttpGet("/{id}")]
        //public IActionResult SetWorkingHours(string id)
        //{
        //    return View();
        //}
        [HttpPost]
        public IActionResult SetWorkingHours(string id)
        {
            return View();
        }
    }
}
