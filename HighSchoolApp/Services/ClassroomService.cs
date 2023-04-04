using HighSchoolApp.Entities;
using HighSchoolApp.IServices;

namespace HighSchoolApp.Services
{
    public class ClassroomService : IClassroomService
    {
        public void AddClassroom(Classroom classroom)
        {
            Classroom? foundClassroom = Program.Classrooms.Find(c => c.ClassroomName == classroom.ClassroomName);
            if (foundClassroom == null)
            {
                Program.Classrooms.Add(classroom);
                Console.WriteLine($"Classroom {classroom.ClassroomName} is added successfully!");
            }
            else throw new Exception($"Classroom {classroom.ClassroomName} already exists!");
        }

        public void DeleteClassroom(string classroomName)
        {
            Classroom? foundClassroom = Program.Classrooms.Find(c => c.ClassroomName == classroomName);
            if (foundClassroom != null)
            {
                Program.Classrooms.Remove(foundClassroom);
                Console.WriteLine($"Classroom {classroomName} is deleted successfully!");
            }
            else throw new Exception($"Classroom {classroomName} does not exist!");
        }
    }
}
