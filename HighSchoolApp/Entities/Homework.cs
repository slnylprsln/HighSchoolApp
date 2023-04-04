namespace HighSchoolApp.Entities
{
    public class Homework
    {
        public int? StudentId { get; set; }
        public int? TeacherId { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public string? Lesson { get; set; }
        public string? HomeworkTitle { get; set; }

        public Homework(int? studentId = null, int? teacherId = null, string? lesson = null, string? homeworkTitle = null)
        {
            StudentId = studentId;
            TeacherId = teacherId;
            SubmissionDate = DateTime.Now;
            Lesson = lesson;
            HomeworkTitle = homeworkTitle;
        }
    }
}
