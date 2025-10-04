using CollegeAdmin.Core.Models;
using CollegeAdmin.Services;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace CollegeAdmin.Pages
{
    public partial class StudentsPage : Page
    {
        public ObservableCollection<Student> Students { get; set; }
        public Student SelectedStudent { get; set; }

        public StudentsPage()
        {
            InitializeComponent();

            // Инициализация коллекции студентов
            var savedStudents = DataService.LoadStudents();
            if (savedStudents.Count > 0)
                Students = new ObservableCollection<Student>(savedStudents);
            else
                Students = new ObservableCollection<Student>
                {
                    new Student { FirstName="Иван", LastName="Иванов", MiddleName="Иванович", Group="A1", Course=1 },
                    new Student { FirstName="Петр", LastName="Петров", MiddleName="Петрович", Group="A2", Course=2 },
                    new Student { FirstName="Сидор", LastName="Сидоров", MiddleName="Сидорович", Group="B1", Course=3 }
                };

            this.DataContext = this;
        }

        private void EditProfileButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedStudent != null)
            {
                // Переход на страницу профиля студента
                ProfilePage profilePage = new ProfilePage(SelectedStudent);
                this.NavigationService?.Navigate(profilePage);
            }
            else
            {
                MessageBox.Show("Выберите студента из списка.", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}







