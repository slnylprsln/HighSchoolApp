
namespace HighSchoolApp
{
    public class Classroom
    {
        public List<Student> Students { get; set; }
        public int? TeacherId { get; set; }
        public string? ClassroomName { get; set; }

        public Classroom()
        {
            Students = new List<Student>();
        }

        
    }
}
