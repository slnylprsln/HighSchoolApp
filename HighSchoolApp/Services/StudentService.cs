
using HighSchoolApp.Entities;
using HighSchoolApp.IServices;

namespace HighSchoolApp.Services
{
    public class StudentService : IStudentService
    {
        public void AddStudent(Student student)
        {
            Student? foundStudent = Program.Students.Find(s => (string.Compare(s.Name, student.Name) == 0) && (string.Compare(s.Surname, student.Surname) == 0));
            if (foundStudent == null)
            {
                Program.Students.Add(student);
                Console.WriteLine($"The student {student.Name} {student.Surname} is added successfully!");
            }
            else throw new Exception($"The student {student.Name} {student.Surname} already exists!");
        }

        public void DeleteStudent(int? id)
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
            else throw new Exception($"Student with the ID: {id} does not exist!");
        }

        public Student GetStudentById(int? id)
        {
            Student? foundStudent = Program.Students.Find(s => s.Id == id);
            if (foundStudent != null) return foundStudent;
            else throw new Exception($"Student with the ID: {id} does not exist!");
        }

        public Student GetStudentByNameSurname(string name, string surname)
        {
            Student? foundStudent = Program.Students.Find(s => (string.Compare(s.Name, name) == 0) && (string.Compare(s.Surname, surname) == 0));
            if (foundStudent != null) return foundStudent;
            else throw new Exception($"Student with the Name Surname: {name} {surname} does not exist!");
        }

        public void UpdateStudent(int? id, Student updateStudent)
        {
            Student? foundStudent = Program.Students.Find(s => s.Id == id);
            if (foundStudent != null)
            {
                if (string.IsNullOrEmpty(updateStudent.Email)) foundStudent.Email = foundStudent.Email;
                else foundStudent.Email = updateStudent.Email;

                Console.WriteLine($"The teacher {foundStudent.Name} {foundStudent.Surname} is updated successfully!");
            }
            else throw new Exception($"Student with the ID: {id} does not exist!");
        }

        public List<Student> GetAllStudents()
        {
            return Program.Students;
        }
    }
}
