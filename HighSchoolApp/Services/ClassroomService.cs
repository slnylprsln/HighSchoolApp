﻿using HighSchoolApp.Entities;
using HighSchoolApp.IServices;

namespace HighSchoolApp.Services
{
    public class ClassroomService : IClassroomService
    {
        public void AddClassroom(Classroom classroom)
        {
            Classroom? foundClassroom = Program.Classrooms.Find(c => string.Compare(c.ClassroomName, classroom.ClassroomName) == 0);
            if (foundClassroom == null)
            {
                Program.Classrooms.Add(classroom);
                Console.WriteLine($"Classroom {classroom.ClassroomName} is added successfully!");
            }
            else Console.WriteLine($"Classroom {classroom.ClassroomName} already exists!");
        }

        public void DeleteClassroom(string classroomName)
        {
            Classroom? foundClassroom = Program.Classrooms.Find(c => string.Compare(c.ClassroomName, classroomName) == 0);
            if (foundClassroom != null)
            {
                Program.Classrooms.Remove(foundClassroom);
                Console.WriteLine($"Classroom {classroomName} is deleted successfully!");
            }
            else Console.WriteLine($"Classroom {classroomName} does not exist!");
        }

        public List<Classroom>? GetAllClassrooms()
        {
            if (Program.Classrooms.Any())
            {
                return Program.Classrooms;
            }
            else
            {
                Console.WriteLine("Student list is empty!");
                return null;
            }
        }
    }
}
