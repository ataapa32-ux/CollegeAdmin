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

        // �������� � QR (��� �������������)
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

        // POST: ������� ���������� { studentId: "123456", scheduleId: 2 }
        [HttpPost]
        public IActionResult MarkAttendance([FromBody] AttendanceRequest request)
        {
            if (request == null || string.IsNullOrWhiteSpace(request.StudentId) || request.ScheduleId <= 0)
                return BadRequest(new { success = false, message = "�������� ������." });

            // ������� ������������ �� �������� StudentId (����������)
            var user = _userRepo.GetByStudentId(request.StudentId);
            if (user == null)
            {
                return NotFound(new { success = false, message = "������� �� ������." });
            }

            // ������ ������� ������������ �� ����������� Id
            _attendanceRepo.SetAttendance(user.Id, request.ScheduleId, true);

            return Ok(new { success = true, student = $"{user.LastName} {user.FirstName}" });
        }
    }

    public class AttendanceRequest
    {
        public string StudentId { get; set; } = string.Empty; // ������� ID (��������, "A12345")
        public int ScheduleId { get; set; }
    }
}























