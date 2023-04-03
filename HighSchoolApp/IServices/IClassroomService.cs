namespace HighSchoolApp.IServices
{
    public interface IClassroomService
    {
        public void AddClassroom(Classroom classroom);
        public void RemoveClassroom(string classroomName);
        //public void UpdateClassroom(string classroomName, Classroom updateClassroom);
        //public Student SearchStudentInClassroom(string nameSurname, string classroomName);
        public Teacher GetTeacherOfClassroom(string classroomName);
        public List<Student> GetAllStudentsOfClassroom(string classroomName);
    }
}
