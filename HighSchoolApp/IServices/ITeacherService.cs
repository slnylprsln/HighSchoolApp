
using HighSchoolApp.Entities;

namespace HighSchoolApp.IServices
{
    public interface ITeacherService
    {
        public void AddTeacher(Teacher teacher);
        public Teacher GetTeacherByNameSurname(string name, string surname);
        public Teacher GetTeacherById(int? id);
        public void UpdateTeacher(int? id, Teacher updateTeacher);
        public void DeleteTeacher(int? id);
        public List<Teacher> GetAllTeachers();
    }
}
