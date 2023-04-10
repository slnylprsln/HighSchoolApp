
using HighSchoolApp.Entities;

namespace HighSchoolApp.IServices
{
    public interface IClassroomStudentService
    {
        public Student? SearchStudentInClassroom(int? studentId, string? classroomName);
        public List<Student>? GetAllStudentsOfClassroom(string classroomName);
        public void AddStudentToClassroom(int? studentId, string? classroomName);
        public void DeleteStudentFromClassroom(int? studentId, string? classroomName);
    }
}
