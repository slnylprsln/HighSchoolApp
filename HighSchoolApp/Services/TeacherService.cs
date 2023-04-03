
using HighSchoolApp.IServices;

namespace HighSchoolApp.Servicesstudent
{
    public class TeacherService : ITeacherService
    {
        public void AddTeacher(Teacher teacher)
        {
            if (!Program.Teachers.Any())
            {
                Program.Teachers.Add(teacher);
                Console.WriteLine($"The teacher {teacher.NameSurname} is added successfully!");
            }
            else
            {
                foreach (var st in Program.Teachers)
                {
                    if (st.NameSurname == teacher.NameSurname)
                    {
                        throw new Exception($"The teacher {teacher.NameSurname} already exists!");
                    }
                }
            }
        }

        public void DeleteTeacher(int id)
        {
            Teacher? found = null;
            foreach (var st in Program.Teachers)
            {
                if (st.TeacherId == id)
                {
                    found = st;
                    break;
                }
            }
            if (found != null)
            {
                Program.Teachers.Remove(found);
                Console.WriteLine($"The teacher {found.NameSurname} is deleted successfully!");
            }
            else throw new Exception("This teacher does not exist!");
        }

        public Teacher GetTeacherById(int id)
        {
            Teacher? found = null;
            foreach (var st in Program.Teachers)
            {
                if (st.TeacherId == id)
                {
                    found = st;
                    break;
                }
            }
            if (found != null) return found;
            else throw new Exception("This teacher does not exist!");
        }

        public Teacher GetTeacherByNameSurname(string nameSurname)
        {
            Teacher? found = null;
            foreach (var st in Program.Teachers)
            {
                if (string.Compare(st.NameSurname, nameSurname) == 0)
                {
                    found = st;
                    break;
                }
            }
            if (found != null) return found;
            else throw new Exception("This teacher does not exist!");
        }

        public void UpdateTeacher(int id, Teacher updateTeacher)
        {
            Teacher? found = null;
            foreach (var st in Program.Teachers)
            {
                if (st.TeacherId == id)
                {
                    found = st;
                    break;
                }
            }
            if (found != null)
            {
                if (string.IsNullOrEmpty(updateTeacher.NameSurname)) found.NameSurname = found.NameSurname;
                else found.NameSurname = updateTeacher.NameSurname;

                Console.WriteLine($"The teacher with the teacher ID {id} is updated successfully!");
            }
            else throw new Exception("This teacher does not exist!");
        }
    }
}
