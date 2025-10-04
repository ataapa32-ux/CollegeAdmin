using Microsoft.AspNetCore.Mvc;
using CollegeAdmin.Core;
using CollegeAdmin.Core.Models;


namespace CollegeAdmin.Web.Controllers
{
    public class PagesController : Controller
    {
        public IActionResult Students()
        {
            return View();
        }

        public IActionResult Schedule()
        {
            return View();
        }

        public IActionResult Journal()
        {
            return View();
        }

        public IActionResult Calendar()
        {
            return View();
        }

        public IActionResult Classroom()
        {
            return View();
        }

        public IActionResult Tasks()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult QR()
        {
            return View();
        }
    }
}






