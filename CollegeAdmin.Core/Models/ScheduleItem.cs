namespace CollegeAdmin.Core.Models
{
    public class ScheduleItem
    {
        public int Id { get; set; }
        public required string DayOfWeek { get; set; }
        public required string Time { get; set; }
        public required string Subject { get; set; }
        public required string Teacher { get; set; }
        public required string Classroom { get; set; }
        public required string Group { get; set; }
    }
}













