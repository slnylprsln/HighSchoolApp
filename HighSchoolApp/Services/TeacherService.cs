
using HighSchoolApp.Entities;
using HighSchoolApp.IServices;

namespace HighSchoolApp.Servicesstudent
{
    public class TeacherService : ITeacherService
    {
        public void AddTeacher(Teacher teacher)
        {
            Teacher? foundTeacher = Program.Teachers.Find(t => t.Name == teacher.Name && teacher.Surname == teacher.Surname);
            if (foundTeacher == null)
            {
                Program.Teachers.Add(teacher);
                Console.WriteLine($"The teacher {teacher.Name} {teacher.Surname} is added successfully!");
            }
            else throw new Exception($"The teacher {teacher.Name} {teacher.Surname} already exists!");
        }

        public void DeleteTeacher(int id)
        {
            Teacher? foundTeacher = Program.Teachers.Find(t => t.Id == id);
            if (foundTeacher != null)
            {
                Program.Teachers.Remove(foundTeacher);
                Classroom? foundClassroom = Program.Classrooms.Find(c => c.TeacherId == id);
                if (foundClassroom != null) foundClassroom.TeacherId = null;
                Console.WriteLine($"The teacher {foundTeacher.Name} {foundTeacher.Surname} is deleted successfully!");
            }
            else throw new Exception($"Teacher with the ID: {id} does not exist!");
        }

        public Teacher GetTeacherById(int id)
        {
            Teacher? foundTeacher = Program.Teachers.Find(t => t.Id == id);
            if (foundTeacher != null) return foundTeacher;
            else throw new Exception($"Teacher with the ID: {id} does not exist!");
        }

        public Teacher GetTeacherByNameSurname(string name, string surname)
        {
            Teacher? foundTeacher = Program.Teachers.Find(t => t.Name == name && t.Surname == surname);
            if (foundTeacher != null) return foundTeacher;
            else throw new Exception($"Teacher with the Name Surname: {name} {surname} does not exist!");
        }

        public void UpdateTeacher(int id, Teacher updateTeacher)
        {
            Teacher? foundTeacher = Program.Teachers.Find(t => t.Id == id);
            if (foundTeacher != null)
            {
                if (string.IsNullOrEmpty(updateTeacher.Email)) foundTeacher.Email = foundTeacher.Email;
                else foundTeacher.Email = updateTeacher.Email;

                Console.WriteLine($"The teacher {foundTeacher.Name} {foundTeacher.Surname} is updated successfully!");
            }
            else throw new Exception($"Teacher with the ID: {id} does not exist!");
        }
    }
}
