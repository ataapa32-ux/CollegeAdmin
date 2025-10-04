using CollegeAdmin.Core.Models;

namespace CollegeAdmin.Mobile.Pages;

public partial class SchedulePage : ContentPage
{
    public SchedulePage()
    {
        InitializeComponent();

        // Пример данных
        var schedule = new List<Schedule>
        {
            new Schedule { Subject = "Математика", Teacher = "Иванов И.И.", Date = DateTime.Today, Room = "101" },
            new Schedule { Subject = "Физика", Teacher = "Петров П.П.", Date = DateTime.Today.AddDays(1), Room = "102" },
        };

        ScheduleList.ItemsSource = schedule;
    }
}







