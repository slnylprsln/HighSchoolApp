
using HighSchoolApp.Entities;
using HighSchoolApp.IServices;

namespace HighSchoolApp.Services
{
    public class ClassroomTeacherService : IClassroomTeacherService
    {
        public Teacher? GetTeacherOfClassroom(string classroomName)
        {
            Classroom? foundClassroom = Program.Classrooms.Find(c => string.Compare(c.ClassroomName, classroomName) == 0);
            if (foundClassroom != null)
            {
                Teacher? foundTeacher = Program.Teachers.Find(t => t.Id == foundClassroom.TeacherId);
                if (foundTeacher != null) return foundTeacher;
                else 
                {
                    Console.WriteLine($"Classroom {classroomName} does not have any teacher!");
                    return null;
                }
            }
            else 
            {
                Console.WriteLine($"Classroom {classroomName} does not exist!");
                return null;
            }
        }

        public void SetTeacherForClassroom(int? teacherId, string? classroomName)
        {
            Classroom? foundClassroom = Program.Classrooms.Find(c => string.Compare(c.ClassroomName, classroomName) == 0);
            if (foundClassroom != null)
            {
                if (foundClassroom.TeacherId == null)
                {
                    Teacher? foundTeacher = Program.Teachers.Find(t => t.Id == teacherId);
                    if (foundTeacher != null)
                    {
                        foundClassroom.TeacherId = foundTeacher.Id;
                        Console.WriteLine($"For the classroom {classroomName}, teacher {foundTeacher.Name} {foundTeacher.Surname} is set successfully!");
                    }
                    else Console.WriteLine($"Teacher with the ID: {teacherId} does not exist!");
                }
                else Console.WriteLine($"Classroom {classroomName} already has a teacher!");

            }
            else Console.WriteLine($"Classroom {classroomName} does not exist!");
        }
    }
}