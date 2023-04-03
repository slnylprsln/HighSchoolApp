using HighSchoolApp.IServices;

namespace HighSchoolApp.Services
{
    public class ClassroomService : IClassroomService
    {
        public void AddClassroom(Classroom classroom)
        {
            Classroom? foundClassroom = Program.Classrooms.Find(c => c.ClassroomName == classroom.ClassroomName);
            if (foundClassroom == null)
            {
                Program.Classrooms.Add(classroom);
                Console.WriteLine($"Classroom {classroom.ClassroomName} is added successfully!");
            }
            else throw new Exception($"Classroom {classroom.ClassroomName} already exists!");
        }

        public List<Student> GetAllStudentsOfClassroom(string classroomName)
        {
            Classroom? foundClassroom = Program.Classrooms.Find(c => c.ClassroomName == classroomName);
            if (foundClassroom != null)
            {
                if (!foundClassroom.Students.Any()) throw new Exception($"Classroom {classroomName} does not have any students!");
                else return foundClassroom.Students;
            }
            else throw new Exception($"Classroom {classroomName} does not exist!");
        }

        public Teacher GetTeacherOfClassroom(string classroomName)
        {
            Classroom? foundClassroom = Program.Classrooms.Find(c => c.ClassroomName == classroomName);
            if (foundClassroom != null)
            {
                Teacher? foundTeacher = Program.Teachers.Find(t => t.TeacherId == foundClassroom.TeacherId);
                if (foundTeacher != null) return foundTeacher;
                else throw new Exception($"Classroom {classroomName} does not have any teacher!");
            }
            else throw new Exception($"Classroom {classroomName} does not exist!");
        }

        public void RemoveClassroom(string classroomName)
        {
            Classroom? foundClassroom = Program.Classrooms.Find(c => c.ClassroomName == classroomName);
            if (foundClassroom != null)
            {
                Program.Classrooms.Remove(foundClassroom);
                Console.WriteLine($"Classroom {classroomName} is deleted successfully!");
            }
            else throw new Exception($"Classroom {classroomName} does not exist!");
        }

        //public Student SearchStudentInClassroom(string nameSurname, string classroomName, int classroomGrade)
        //{
        //    Student? found = Program.Students.Find(s => string.Compare(s.NameSurname, nameSurname) == 0 &&
        //        string.Compare(s.ClassroomName, classroomName) == 0 && s.ClassroomGrade == classroomGrade);
        //    if (found != null)
        //    {
        //        return found;
        //    }
        //    else throw new Exception($"Student {nameSurname} does not exist in the classroom {classroomName}!");
        //}

        //public void UpdateClassroom(string classroomName, Classroom updateClassroom)
        //{
        //    Classroom? foundClassroom = Program.Classrooms.Find(c => c.ClassroomName == classroomName);
        //    if (foundClassroom != null)
        //    {
        //        if (string.IsNullOrEmpty(updateClassroom.ClassroomName)) foundClassroom.ClassroomName = foundClassroom.ClassroomName;
        //        else foundClassroom.ClassroomName = classroomName;

        //        if (updateClassroom.TeacherId == null) foundClassroom.TeacherId = foundClassroom.TeacherId;
        //        else
        //        {
        //            Teacher? foundOldTeacher = Program.Teachers.Find(t => t.TeacherId == foundClassroom.TeacherId);
        //            foundOldTeacher.ClassroomName = null;

        //            Teacher? foundNewTeacher = Program.Teachers.Find(t => t.TeacherId == updateClassroom.TeacherId);
        //            if (foundNewTeacher != null)
        //            {
        //                if (foundNewTeacher.ClassroomName == null)
        //                {
        //                    foundNewTeacher.ClassroomName = foundClassroom.ClassroomName;
        //                    foundClassroom.TeacherId = updateClassroom.TeacherId;
        //                }
        //                else throw new Exception($"Teacher with the ID {foundNewTeacher.TeacherId} have another class! Operation cannot be performed!");
        //            }
        //            else throw new Exception($"Teacher with the ID {updateClassroom.TeacherId} does not exist!");
        //        }

        //        Console.WriteLine($"Classroom {foundClassroom.ClassroomName} is updated successfully!");
        //    }
        //    else throw new Exception($"Classroom {classroomName} does not exist!");
        //}
    }
}
