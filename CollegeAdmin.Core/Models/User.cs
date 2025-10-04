using System;

namespace CollegeAdmin.Core.Models
{
    public class User
    {
        public int Id { get; set; }  // внутренний ID в системе (используется для attendance и т.д.)

        // Минобразовский 6-значный ID (string)
        public string? StudentId { get; set; }

        // ФИО
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;

        // Аутентификация
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // Роль: "Student", "Teacher", "Admin"
        public string Role { get; set; } = "Student";

        // Учебная информация
        public string? Group { get; set; }
        public string? Faculty { get; set; }
        public string? Curator { get; set; }

        public double GPA { get; set; } = 0.0;

        // Путь к фото в wwwroot (унифицировано как PhotoPath)
        public string PhotoPath { get; set; } = "/images/default-user.png";

        // Удобные флаги
        public bool IsStudent => Role?.Equals("Student", StringComparison.OrdinalIgnoreCase) ?? false;
        public bool IsTeacher => Role?.Equals("Teacher", StringComparison.OrdinalIgnoreCase) ?? false;
    }
}









































