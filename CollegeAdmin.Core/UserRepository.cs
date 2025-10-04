using CollegeAdmin.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CollegeAdmin.Core
{
    public class UserRepository
    {
        private readonly List<User> _users = new();

        public UserRepository()
        {
            // seed (можно добавить тестовые данные при необходимости)
        }

        public IEnumerable<User> GetAll() => _users;

        public User? GetByEmail(string email)
            => _users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

        public User? GetById(int id)
            => _users.FirstOrDefault(u => u.Id == id);

        public User? GetByStudentId(string studentId)
            => _users.FirstOrDefault(u =>
                !string.IsNullOrEmpty(u.StudentId) &&
                u.StudentId.Equals(studentId, StringComparison.OrdinalIgnoreCase));

        public void Add(User user)
        {
            // Генерация уникального Id для базы
            if (user.Id == 0)
                user.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;

            // Автоматическая генерация StudentId, если роль = "Student"
            if (user.Role.Equals("Student", StringComparison.OrdinalIgnoreCase))
            {
                if (string.IsNullOrEmpty(user.StudentId))
                    user.StudentId = GenerateStudentId();
            }
            else
            {
                user.StudentId = null;
            }

            _users.Add(user);
        }

        public void Update(User user)
        {
            var existing = GetById(user.Id);
            if (existing == null) return;

            existing.FirstName = user.FirstName;
            existing.LastName = user.LastName;
            existing.MiddleName = user.MiddleName;
            existing.Email = user.Email;
            existing.Password = user.Password;
            existing.Role = user.Role;
            existing.StudentId = user.StudentId;
            existing.Group = user.Group;
            existing.Faculty = user.Faculty;
            existing.Curator = user.Curator;
            existing.GPA = user.GPA;
            existing.PhotoPath = user.PhotoPath;
        }

        // ===== Хелпер генерации StudentId =====
        private string GenerateStudentId()
        {
            var rnd = new Random();
            string newId;

            do
            {
                newId = rnd.Next(100000, 999999).ToString(); // 6-значный ID
            }
            while (_users.Any(u => u.StudentId == newId)); // Проверка на уникальность

            return newId;
        }
    }
}




















