using CollegeAdmin.Core;
using CollegeAdmin.Core.Models;
using System.Collections.Generic;

namespace CollegeAdmin.Web.Models
{
    public class JournalViewModel
    {
        public IEnumerable<User> Students { get; set; } = new List<User>();
        public IEnumerable<ScheduleItem> ScheduleItems { get; set; } = new List<ScheduleItem>();

        public AttendanceRepository Attendance { get; set; } = new AttendanceRepository();

        public bool IsPresent(int studentId, int scheduleId)
            => Attendance.IsPresent(studentId, scheduleId);
    }
}


























