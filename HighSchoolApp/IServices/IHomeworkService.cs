
using HighSchoolApp.Entities;

namespace HighSchoolApp.IServices
{
    public interface IHomeworkService
    {
        public void SendHomework(Homework homework);
        public List<Homework>? GetAllHomeworksSubmittedToATeacher(int teacherId);
        public List<Homework>? GetAllHomeworksSubmittedByAStudent(int studentId);
        public List<Homework>? GetAllHomeworksInTheSystem();
        
    }
}
