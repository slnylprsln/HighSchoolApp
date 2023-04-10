
using HighSchoolApp.Entities;
using HighSchoolApp.IServices;

namespace HighSchoolApp.Services
{
    public class TeacherService : IPersonService<Teacher>
    {
        public void Add(Teacher teacher)
        {
            Teacher? foundTeacher = Program.Teachers.Find(t => (string.Compare(t.Name, teacher.Name) == 0) && (string.Compare(t.Surname, teacher.Surname) == 0));
            if (foundTeacher == null)
            {
                Program.Teachers.Add(teacher);
                Console.WriteLine($"The teacher {teacher.Name} {teacher.Surname} is added successfully!");
            }
            else Console.WriteLine($"The teacher {teacher.Name} {teacher.Surname} already exists!");
        }

        public void Delete(int? id)
        {
            Teacher? foundTeacher = Program.Teachers.Find(t => t.Id == id);
            if (foundTeacher != null)
            {
                Program.Teachers.Remove(foundTeacher);
                Classroom? foundClassroom = Program.Classrooms.Find(c => c.TeacherId == id);
                if (foundClassroom != null) foundClassroom.TeacherId = null;
                Console.WriteLine($"The teacher {foundTeacher.Name} {foundTeacher.Surname} is deleted successfully!");
            }
            else Console.WriteLine($"Teacher with the ID: {id} does not exist!");
        }

        public Teacher? GetById(int? id)
        {
            Teacher? foundTeacher = Program.Teachers.Find(t => t.Id == id);
            if (foundTeacher != null) return foundTeacher;
            else
            {
                Console.WriteLine($"Teacher with the ID: {id} does not exist!");
                return null;
            }
        }

        public Teacher? GetByNameSurname(string name, string surname)
        {
            Teacher? foundTeacher = Program.Teachers.Find(t => (string.Compare(t.Name, name) == 0) && (string.Compare(t.Surname, surname) == 0));
            if (foundTeacher != null) return foundTeacher;
            else
            {
                Console.WriteLine($"Teacher with the Name Surname: {name} {surname} does not exist!");
                return null;
            }
        }

        public void Update(int? id, Teacher updateTeacher)
        {
            Teacher? foundTeacher = Program.Teachers.Find(t => t.Id == id);
            if (foundTeacher != null)
            {
                if (string.IsNullOrEmpty(updateTeacher.Email)) foundTeacher.Email = foundTeacher.Email;
                else foundTeacher.Email = updateTeacher.Email;

                Console.WriteLine($"The teacher {foundTeacher.Name} {foundTeacher.Surname} is updated successfully!");
            }
            else Console.WriteLine($"Teacher with the ID: {id} does not exist!");
        }

        public List<Teacher>? GetAll()
        {
            if (Program.Teachers.Any())
            {
                return Program.Teachers;
            }
            else
            {
                Console.WriteLine("Teacher list is empty!");
                return null;
            }
        }
    }
}
