using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using CollegeAdmin.Core.Models;
using CollegeAdmin.Services;

namespace CollegeAdmin.Windows
{
    public partial class RegistrationWindow : Window
    {
        private string photoPath; // Храним путь к фото

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void SelectPhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Изображения (*.png;*.jpg)|*.png;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                // Загружаем фото в Image
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                PhotoImage.Source = bitmap;

                // Запоминаем путь к файлу
                photoPath = openFileDialog.FileName;
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            // Проверка, чтобы все поля были заполнены
            if (string.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(FirstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(GroupTextBox.Text) ||
                string.IsNullOrWhiteSpace(CourseTextBox.Text) ||
                string.IsNullOrWhiteSpace(photoPath))
            {
                MessageBox.Show("Пожалуйста, заполните все поля и выберите фото.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Создаём нового студента
            Student newStudent = new Student
            {
                LastName = LastNameTextBox.Text,
                FirstName = FirstNameTextBox.Text,
                MiddleName = MiddleNameTextBox.Text,
                Group = GroupTextBox.Text,
                Course = int.Parse(CourseTextBox.Text), // теперь без ошибки
                Photo = photoPath
            };

            // Сохраняем через DataService
            DataService.AddStudent(newStudent);

            MessageBox.Show("Студент зарегистрирован!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close(); // Закрываем окно регистрации
        }
    }
}

