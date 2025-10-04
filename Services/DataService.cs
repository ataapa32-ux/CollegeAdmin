using CollegeAdmin.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CollegeAdmin.Services
{
    public static class DataService
    {
        private static readonly string StudentsFile = "students.json";
        private static readonly string ScheduleFile = "schedule.json";

        private static readonly JsonSerializerOptions options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        // ------------------ STUDENTS ------------------
        public static List<Student> LoadStudents()
        {
            if (!File.Exists(StudentsFile))
                return new List<Student>();

            string json = File.ReadAllText(StudentsFile);
            return JsonSerializer.Deserialize<List<Student>>(json, options) ?? new List<Student>();
        }

        public static void SaveStudents(List<Student> students)
        {
            string json = JsonSerializer.Serialize(students, options);
            File.WriteAllText(StudentsFile, json);
        }

        public static void AddStudent(Student student)
        {
            var students = LoadStudents();
            students.Add(student);
            SaveStudents(students);
        }

        // ------------------ SCHEDULE ------------------
        public static List<ScheduleItem> LoadSchedule()
        {
            if (!File.Exists(ScheduleFile))
                return new List<ScheduleItem>();

            string json = File.ReadAllText(ScheduleFile);
            return JsonSerializer.Deserialize<List<ScheduleItem>>(json, options) ?? new List<ScheduleItem>();
        }

        public static void SaveSchedule(List<ScheduleItem> schedule)
        {
            string json = JsonSerializer.Serialize(schedule, options);
            File.WriteAllText(ScheduleFile, json);
        }
    }
}









