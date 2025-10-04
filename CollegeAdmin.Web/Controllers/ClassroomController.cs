using Microsoft.AspNetCore.Mvc;
using CollegeAdmin.Core;
using CollegeAdmin.Core.Models;


namespace CollegeAdmin.Web.Controllers
{
    public class ClassroomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}







