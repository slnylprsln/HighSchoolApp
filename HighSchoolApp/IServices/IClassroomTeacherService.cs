
using HighSchoolApp.Entities;

namespace HighSchoolApp.IServices
{
    public interface IClassroomTeacherService
    {
        public Teacher? GetTeacherOfClassroom(string classroomName);
        public void SetTeacherForClassroom(int? teacherId, string? classroomName);
    }
}
