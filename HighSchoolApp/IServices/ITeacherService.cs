
namespace HighSchoolApp.IServices
{
    public interface ITeacherService
    {
        public void AddTeacher(Teacher teacher);
        public Teacher GetTeacherByNameSurname(string nameSurname);
        public Teacher GetTeacherById(int id);
        public void UpdateTeacher(int id, Teacher updateTeacher);
        public void DeleteTeacher(int id);
    }
}
