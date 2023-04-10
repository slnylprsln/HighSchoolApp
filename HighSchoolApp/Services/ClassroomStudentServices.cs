
using HighSchoolApp.Entities;
using HighSchoolApp.IServices;

namespace HighSchoolApp.Services
{
    public class ClassroomStudentService : IClassroomStudentService
    {
        public void AddStudentToClassroom(int? studentId, string? classroomName)
        {
            Classroom? foundClassroom = Program.Classrooms.Find(c => string.Compare(c.ClassroomName, classroomName) == 0);
            if (foundClassroom != null)
            {
                Student? foundStudent = Program.Students.Find(s => s.Id == studentId);
                if (foundStudent != null)
                {
                    Student? studentInClassroom = foundClassroom.Students.Find(s => s.Id == studentId);
                    if (studentInClassroom == null)
                    {
                        foundClassroom.Students.Add(foundStudent);
                        Console.WriteLine($"Student with the ID: {studentId} is added into the classroom {classroomName} successfully!");
                    }
                    else Console.WriteLine($"Student with the ID: {studentId} already exists in classroom {classroomName}!");
                }
                else Console.WriteLine($"Student with the ID: {studentId} does not exist!");
            }
            else Console.WriteLine($"Classroom {classroomName} does not exist!");
        }

        public void DeleteStudentFromClassroom(int? studentId, string? classroomName)
        {
            Classroom? foundClassroom = Program.Classrooms.Find(c => string.Compare(c.ClassroomName, classroomName) == 0);
            if (foundClassroom != null)
            {
                Student? foundStudent = Program.Students.Find(s => s.Id == studentId);
                if (foundStudent != null)
                {
                    Student? studentInClassroom = foundClassroom.Students.Find(s => s.Id == studentId);
                    if (studentInClassroom != null)
                    {
                        foundClassroom.Students.Remove(foundStudent);
                        Console.WriteLine($"Student with the ID: {studentId} is deleted from the classroom {classroomName} successfully!");
                    }
                    else Console.WriteLine($"Student with the ID: {studentId} does not exists in the classroom {classroomName}!");
                }
                else Console.WriteLine($"Student with the ID: {studentId} does not exist!");
            }
            else Console.WriteLine($"Classroom {classroomName} does not exist!");
        }

        public List<Student>? GetAllStudentsOfClassroom(string classroomName)
        {
            Classroom? foundClassroom = Program.Classrooms.Find(c => string.Compare(c.ClassroomName, classroomName) == 0);
            if (foundClassroom != null)
            {
                if (foundClassroom.Students.Any()) return foundClassroom.Students;
                else 
                {
                    Console.WriteLine($"Classroom {classroomName} does not have any students!");
                    return null;
                }
            }
            else 
            {
                Console.WriteLine($"Classroom {classroomName} does not exist!");
                return null;
            }
        }

        public Student? SearchStudentInClassroom(int? studentId, string? classroomName)
        {
            Classroom? foundClassroom = Program.Classrooms.Find(c => string.Compare(c.ClassroomName, classroomName) == 0);
            if (foundClassroom != null)
            {
                Student? foundStudent = foundClassroom.Students.Find(s => s.Id == studentId);
                if (foundStudent != null)
                {
                    return foundStudent;
                }
                else
                {
                    Console.WriteLine($"Student with the ID: {studentId} does not exist in the classroom {classroomName}!");
                    return null;
                }
            }
            else 
            {
                Console.WriteLine($"Classroom {classroomName} does not exist!");
                return null;
            }
        }
    }
}
