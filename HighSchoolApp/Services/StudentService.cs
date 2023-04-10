
using HighSchoolApp.Entities;
using HighSchoolApp.IServices;

namespace HighSchoolApp.Services
{
    public class StudentService : IPersonService<Student>
    {
        public void Add(Student student)
        {
            Student? foundStudent = Program.Students.Find(s => (string.Compare(s.Name, student.Name) == 0) && (string.Compare(s.Surname, student.Surname) == 0));
            if (foundStudent == null)
            {
                Program.Students.Add(student);
                Console.WriteLine($"The student {student.Name} {student.Surname} is added successfully!");
            }
            else Console.WriteLine($"The student {student.Name} {student.Surname} already exists!");
        }

        public void Delete(int? id)
        {
            Student? foundStudent = Program.Students.Find(s => s.Id == id);
            if (foundStudent != null)
            {
                Program.Students.Remove(foundStudent);
                Classroom? foundClassroom = null;
                foreach (var cl in Program.Classrooms)
                {
                    Student? exist = cl.Students.Find(s => s.Id == id);
                    if(exist != null) foundClassroom = cl;
                }
                if (foundClassroom != null) foundClassroom.Students.Remove(foundStudent);
                Console.WriteLine($"The student {foundStudent.Name} {foundStudent.Surname} is deleted successfully!");
            }
            else Console.WriteLine($"Student with the ID: {id} does not exist!");
        }

        public Student? GetById(int? id)
        {
            Student? foundStudent = Program.Students.Find(s => s.Id == id);
            if (foundStudent != null) return foundStudent;
            else
            {
                Console.WriteLine($"Student with the ID: {id} does not exist!");
                return null;
            }
        }

        public Student? GetByNameSurname(string name, string surname)
        {
            Student? foundStudent = Program.Students.Find(s => (string.Compare(s.Name, name) == 0) && (string.Compare(s.Surname, surname) == 0));
            if (foundStudent != null) return foundStudent;
            else
            {
                Console.WriteLine($"Student with the Name Surname: {name} {surname} does not exist!");
                return null;
            }
        }

        public void Update(int? id, Student updateStudent)
        {
            Student? foundStudent = Program.Students.Find(s => s.Id == id);
            if (foundStudent != null)
            {
                if (string.IsNullOrEmpty(updateStudent.Email)) foundStudent.Email = foundStudent.Email;
                else foundStudent.Email = updateStudent.Email;

                Console.WriteLine($"The student {foundStudent.Name} {foundStudent.Surname} is updated successfully!");
            }
            else Console.WriteLine($"Student with the ID: {id} does not exist!");
        }

        public List<Student>? GetAll()
        {
            if (Program.Students.Any())
            {
                return Program.Students;
            }
            else
            {
                Console.WriteLine("Student list is empty!");
                return null;
            }
        }
    }
}
