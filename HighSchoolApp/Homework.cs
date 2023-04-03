
namespace HighSchoolApp
{
    public class Homework
    {
        public DateTime? SubmissionDate { get; set; }
        public string? Lesson { get; set; }
        public string? HomeworkTitle { get; set; }
        public int? TeacherId { get; set; }

        public Homework(string? lesson = null, string? homeworkTitle = null, int? teacherId = null)
        {
            SubmissionDate = DateTime.Now;
            Lesson = lesson;
            HomeworkTitle = homeworkTitle;
            TeacherId = teacherId;
        }
    }
}
