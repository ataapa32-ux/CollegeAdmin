using Microsoft.AspNetCore.Mvc;
using CollegeAdmin.Core;
using CollegeAdmin.Web.Models; // <-- исправлено
using System.Linq;

namespace CollegeAdmin.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly UserRepository _userRepo;
        private readonly ScheduleRepository _scheduleRepo;
        private readonly AttendanceRepository _attendanceRepo;

        public StudentsController(UserRepository userRepo,
                                  ScheduleRepository scheduleRepo,
                                  AttendanceRepository attendanceRepo)
        {
            _userRepo = userRepo;
            _scheduleRepo = scheduleRepo;
            _attendanceRepo = attendanceRepo;
        }

        public IActionResult Index()
        {
            var model = new StudentsViewModel
            {
                Students = _userRepo.GetAll().Where(u => u.IsStudent).ToList(),
                ScheduleItems = _scheduleRepo.GetAll(),
                Attendance = _attendanceRepo
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult MarkAttendance(int studentId, int scheduleId, bool present)
        {
            _attendanceRepo.SetAttendance(studentId, scheduleId, present);
            return RedirectToAction("Index");
        }
    }
}















