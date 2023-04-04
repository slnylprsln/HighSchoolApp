
using HighSchoolApp.Entities;
using HighSchoolApp.IServices;

namespace HighSchoolApp.Services
{
    public class ClassroomTeacherServices : IClassroomTeacherServices
    {
        public Teacher GetTeacherOfClassroom(string classroomName)
        {
            Classroom? foundClassroom = Program.Classrooms.Find(c => c.ClassroomName == classroomName);
            if (foundClassroom != null)
            {
                Teacher? foundTeacher = Program.Teachers.Find(t => t.Id == foundClassroom.TeacherId);
                if (foundTeacher != null) return foundTeacher;
                else throw new Exception($"Classroom {classroomName} does not have any teacher!");
            }
            else throw new Exception($"Classroom {classroomName} does not exist!");
        }

        public void SetTeacherForClassroom(int teacherId, string classroomName)
        {
            Classroom? foundClassroom = Program.Classrooms.Find(c => c.ClassroomName == classroomName);
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
                    else throw new Exception($"Teacher with the ID: {teacherId} does not exist!");
                }
                else throw new Exception($"Classroom {classroomName} already has a teacher!");

            }
            else throw new Exception($"Classroom {classroomName} does not exist!");
        }
    }
}
