using HighSchoolApp.Entities;

namespace HighSchoolApp.IServices
{
    public interface IClassroomService
    {
        public void AddClassroom(Classroom classroom);
        public void DeleteClassroom(string classroomName);
    }
}
