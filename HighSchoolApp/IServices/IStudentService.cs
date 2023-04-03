﻿
namespace HighSchoolApp.IServices
{
    public interface IStudentService
    {
        public void AddStudent(Student student);
        public Student GetStudentByNameSurname(string nameSurname);
        public Student GetStudentById(int id);
        public void UpdateStudent(int id, Student updateStudent);
        public void DeleteStudent(int id);
    }
}