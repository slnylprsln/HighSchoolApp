
using HighSchoolApp.IServices;

namespace HighSchoolApp.Services
{
    public class StudentService : IStudentService
    {
        public void AddStudent(Student student)
        {
            if (!Program.Students.Any())
            {
                Program.Students.Add(student);
                Console.WriteLine($"The student {student.NameSurname} is added successfully!");
            }
            else
            {
                foreach (var st in Program.Students)
                {
                    if (st.NameSurname == student.NameSurname)
                    {
                        throw new Exception($"The student {student.NameSurname} already exists!");
                    }
                }
            }
        }

        public void DeleteStudent(int id)
        {
            Student? found = null;
            foreach (var st in Program.Students)
            {
                if (st.StudentId == id)
                {
                    found = st;
                    break;
                }
            }
            if (found != null)
            {
                Program.Students.Remove(found);
                Console.WriteLine($"The student {found.NameSurname} is deleted successfully!");
            }
            else throw new Exception("This student does not exist!");
        }

        public Student GetStudentById(int id)
        {
            Student? found = null;
            foreach (var st in Program.Students)
            {
                if (st.StudentId == id)
                {
                    found = st;
                    break;
                }
            }
            if (found != null) return found;
            else throw new Exception("This student does not exist!");
        }

        public Student GetStudentByNameSurname(string nameSurname)
        {
            Student? found = null;
            foreach (var st in Program.Students)
            {
                if (string.Compare(st.NameSurname, nameSurname) == 0)
                {
                    found = st;
                    break;
                }
            }
            if (found != null) return found;
            else throw new Exception("This student does not exist!");
        }

        public void UpdateStudent(int id, Student updateStudent)
        {
            Student? found = null;
            foreach (var st in Program.Students)
            {
                if (st.StudentId == id)
                {
                    found = st;
                    break;
                }
            }
            if (found != null)
            {
                if (string.IsNullOrEmpty(updateStudent.NameSurname)) found.NameSurname = found.NameSurname;
                else found.NameSurname = updateStudent.NameSurname;

                Console.WriteLine($"The student with the student ID {id} is updated successfully!");
            }
            else throw new Exception("This student does not exist!");
        }
    }
}
