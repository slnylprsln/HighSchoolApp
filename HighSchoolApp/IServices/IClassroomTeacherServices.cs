
using HighSchoolApp.Entities;

namespace HighSchoolApp.IServices
{
    public interface IClassroomTeacherServices
    {
        public Teacher GetTeacherOfClassroom(string classroomName);
        public void SetTeacherForClassroom(int? teacherId, string? classroomName);
    }
}
