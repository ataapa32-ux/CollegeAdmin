using Microsoft.AspNetCore.Mvc;
using CollegeAdmin.Core;
using CollegeAdmin.Core.Models;

namespace CollegeAdmin.Web.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ScheduleRepository _scheduleRepo;

        public ScheduleController(ScheduleRepository scheduleRepo)
        {
            _scheduleRepo = scheduleRepo;
        }

        public IActionResult Index()
        {
            var model = new CollegeAdmin.Web.Models.StudentsViewModel

            {
                ScheduleItems = _scheduleRepo.GetAll()
            };
            return View(model);
        }
    }
}












