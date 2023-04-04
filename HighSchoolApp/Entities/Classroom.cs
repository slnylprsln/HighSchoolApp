namespace HighSchoolApp.Entities
{
    public class Classroom
    {
        public List<Student> Students { get; set; }
        public int? TeacherId { get; set; }
        public string? ClassroomName { get; set; }

        public Classroom(int? teacherId = null, string? classroomName = null)
        {
            Students = new List<Student>();
            TeacherId = teacherId;
            ClassroomName = classroomName;
        }
    }
}
