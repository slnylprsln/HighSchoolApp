
namespace HighSchoolApp
{
    public class Student
    {
        public int StudentId { get; set; }
        public string? NameSurname { get; set; }
        public string? Email { get; set; }
        public List<Homework> Homeworks { get; set; }

        public Student(string? nameSurname = null, string? email = null)
        {
            Random r = new();
            StudentId = r.Next(1,100000);
            NameSurname = nameSurname;
            Email = email;
        }
    }
}
