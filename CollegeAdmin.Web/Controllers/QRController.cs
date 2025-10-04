using Microsoft.AspNetCore.Mvc;
using CollegeAdmin.Core;
using CollegeAdmin.Core.Models;
using System.Linq;

namespace CollegeAdmin.Web.Controllers
{
    public class QRController : Controller
    {
        private readonly AttendanceRepository _attendanceRepo;
        private readonly UserRepository _userRepo;
        private readonly ScheduleRepository _scheduleRepo;

        public QRController(UserRepository userRepo,
                            ScheduleRepository scheduleRepo,
                            AttendanceRepository attendanceRepo)
        {
            _userRepo = userRepo;
            _scheduleRepo = scheduleRepo;
            _attendanceRepo = attendanceRepo;
        }

        // страница с QR (для преподавателя)
        [HttpGet]
        public IActionResult Index()
        {
            var teacher = _userRepo.GetAll().FirstOrDefault(u => u.Role == "Teacher");
            ViewBag.Teacher = teacher;
            ViewBag.Schedule = teacher != null
                ? _scheduleRepo.GetAll().Where(s => s.Teacher?.Contains(teacher.LastName) ?? false).ToList()
                : _scheduleRepo.GetAll().ToList();
            return View();
        }

        // POST: студент отправляет { studentId: "123456", scheduleId: 2 }
        [HttpPost]
        public IActionResult MarkAttendance([FromBody] AttendanceRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.StudentId) || request.ScheduleId <= 0)
                return BadRequest(new { success = false, message = "Неверные данные." });

            // Находим пользователя по внешнему StudentId (строковому)
            var user = _userRepo.GetByStudentId(request.StudentId);
            if (user == null)
            {
                return NotFound(new { success = false, message = "Студент не найден." });
            }

            // Ставим отметку посещаемости по внутреннему Id
            _attendanceRepo.SetAttendance(user.Id, request.ScheduleId, true);

            return Ok(new { success = true, student = $"{user.LastName} {user.FirstName}" });
        }
    }

    public class AttendanceRequest
    {
        public string StudentId { get; set; } = string.Empty; // внешний ID (например, "A12345")
        public int ScheduleId { get; set; }
    }
}























