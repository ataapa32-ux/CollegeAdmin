using CollegeAdmin.Core.Models;
using CollegeAdmin.Services;
using Microsoft.Win32;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CollegeAdmin.Pages
{
    public partial class ProfilePage : Page
    {
        private Student _student;

        public ProfilePage(Student student)
        {
            InitializeComponent();
            _student = student;

            // Заполняем поля
            FirstNameTextBox.Text = _student.FirstName;
            LastNameTextBox.Text = _student.LastName;
            MiddleNameTextBox.Text = _student.MiddleName;
            GroupTextBox.Text = _student.Group;
            CourseTextBox.Text = _student.Course.ToString();

            if (_student.Photo != null && File.Exists(_student.Photo))
            {
                StudentPhotoImage.Source = new BitmapImage(new Uri(_student.Photo));
            }
        }

        private void ChangePhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Изображения|*.jpg;*.jpeg;*.png";

            if (openFile.ShowDialog() == true)
            {
                _student.Photo = openFile.FileName;
                StudentPhotoImage.Source = new BitmapImage(new Uri(_student.Photo));
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Сохраняем изменения в объекте
            _student.FirstName = FirstNameTextBox.Text;
            _student.LastName = LastNameTextBox.Text;
            _student.MiddleName = MiddleNameTextBox.Text;
            _student.Group = GroupTextBox.Text;

            if (int.TryParse(CourseTextBox.Text, out int course))
                _student.Course = course;
            else
            {
                MessageBox.Show("Неверный формат курса!");
                return;
            }

            // Сохраняем список студентов через DataService
            var students = DataService.LoadStudents();
            var index = students.FindIndex(s => s.Id == _student.Id);
            if (index >= 0)
                students[index] = _student;
            else
                students.Add(_student);

            DataService.SaveStudents(students);

            MessageBox.Show("Профиль сохранен!");
        }
    }
}










