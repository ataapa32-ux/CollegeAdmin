using CollegeAdmin.Core;
using CollegeAdmin.Core.Models;
using System.Collections.Generic;

namespace CollegeAdmin.Web.Models
{
    public class StudentsViewModel
    {
        // Список студентов
        public IEnumerable<User> Students { get; set; } = new List<User>();

        // Расписание
        public IEnumerable<ScheduleItem> ScheduleItems { get; set; } = new List<ScheduleItem>();

        // Репозиторий посещаемости
        public AttendanceRepository Attendance { get; set; } = new AttendanceRepository();

        // Метод для проверки присутствия
        public bool IsPresent(int studentId, int scheduleId)
            => Attendance.IsPresent(studentId, scheduleId);
    }
}


























