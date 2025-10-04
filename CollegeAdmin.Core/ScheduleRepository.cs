using CollegeAdmin.Core.Models;

namespace CollegeAdmin.Core
{
    public class ScheduleRepository
    {
        private readonly List<ScheduleItem> _schedule = new();

        public ScheduleRepository()
        {
            _schedule.AddRange(new List<ScheduleItem>
            {
                new ScheduleItem
                {
                    Id = 1,
                    DayOfWeek = "Понедельник",
                    Time = "09:00-10:30",
                    Subject = "Математика",
                    Teacher = "Сидоров Сергей Иванович",
                    Classroom = "Ауд. 101",
                    Group = "ИВТ-21"
                },
                new ScheduleItem
                {
                    Id = 2,
                    DayOfWeek = "Понедельник",
                    Time = "10:40-12:10",
                    Subject = "Программирование",
                    Teacher = "Сидоров Сергей Иванович",
                    Classroom = "Ауд. 102",
                    Group = "ИВТ-21"
                },
                new ScheduleItem
                {
                    Id = 3,
                    DayOfWeek = "Вторник",
                    Time = "09:00-10:30",
                    Subject = "Физика",
                    Teacher = "Сидоров Сергей Иванович",
                    Classroom = "Ауд. 201",
                    Group = "ИВТ-21"
                }
            });
        }

        public IEnumerable<ScheduleItem> GetAll() => _schedule;

        public void Add(ScheduleItem item) => _schedule.Add(item);

        public void Remove(int id)
        {
            var existing = _schedule.FirstOrDefault(x => x.Id == id);
            if (existing != null) _schedule.Remove(existing);
        }
    }
}




