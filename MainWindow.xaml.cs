using CollegeAdmin.Core.Models;   // Student из Core
using CollegeAdmin.Pages;
using System.Windows;




namespace CollegeAdmin
{
    public partial class MainWindow : Window
    {
        private Student currentStudent; // текущий студент

        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new StudentsPage());
        }

        private void StudentsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StudentsPage());
        }

        private void ScheduleButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SchedulePage());
        }

        private void ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentStudent == null)
            {
                MessageBox.Show("Сначала зарегистрируйтесь или выберите студента!");
                return;
            }

            MainFrame.Navigate(new ProfilePage(currentStudent));
        }

        public void SetCurrentStudent(Student student)
        {
            currentStudent = student;
        }
    }
}




