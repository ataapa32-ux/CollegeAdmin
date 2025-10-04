namespace CollegeAdmin.Core
{
    public class AttendanceRepository
    {
        private readonly Dictionary<(int studentId, int scheduleId), bool> _attendance = new();

        public void SetAttendance(int studentId, int scheduleId, bool present)
            => _attendance[(studentId, scheduleId)] = present;

        public bool IsPresent(int studentId, int scheduleId)
            => _attendance.TryGetValue((studentId, scheduleId), out var present) && present;
    }
}








