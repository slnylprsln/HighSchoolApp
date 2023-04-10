
using HighSchoolApp.Entities;
using HighSchoolApp.IServices;

namespace HighSchoolApp.Services
{
    public class HomeworkService : IHomeworkService
    {
        public List<Homework>? GetAllHomeworksInTheSystem()
        {
            return Program.Homeworks;
        }

        public List<Homework>? GetAllHomeworksSubmittedByAStudent(int studentId)
        {
            Student? foundStudent = Program.Students.Find(s => s.Id == studentId);
            if (foundStudent != null)
            {
                return foundStudent.Homeworks;
            }
            else
            {
                Console.WriteLine($"Student with the ID: {studentId} does not exist!");
                return null;
            }
        }

        public List<Homework>? GetAllHomeworksSubmittedToATeacher(int teacherId)
        {
            Teacher? foundTeacher = Program.Teachers.Find(t => t.Id == teacherId);
            if (foundTeacher != null)
            {
                return foundTeacher.Homeworks;
            }
            else
            {
                Console.WriteLine($"Teacher with the ID: {teacherId} does not exist!");
                return null;
            }
        }

        public void SendHomework(Homework homework)
        {
            Teacher? foundTeacher = Program.Teachers.Find(t => t.Id == homework.TeacherId);
            Student? foundStudent = Program.Students.Find(s => s.Id == homework.StudentId);

            if (foundTeacher != null)
            {
                if (foundStudent != null)
                {
                    foundTeacher.Homeworks.Add(homework);
                    foundStudent.Homeworks.Add(homework);
                    Program.Homeworks.Add(homework);
                    Console.WriteLine($"Homework \"{homework.HomeworkTitle}\" prepared by {foundStudent.Name} {foundStudent.Surname} is submitted to {foundTeacher.Name} {foundTeacher.Surname} successfully!");
                }
                else Console.WriteLine($"Student with the ID: {homework.StudentId} does not exist!");
            }
            else Console.WriteLine($"Teacher with the ID: {homework.TeacherId} does not exist!");
        }
    }
}
