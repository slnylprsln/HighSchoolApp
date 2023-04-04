namespace HighSchoolApp.Entities
{
    public class Student : Person
    {
        public List<Homework> Homeworks { get; set; }

        public Student(int? id = null, string? name = null, string? surname = null, string? email = null) : base(id, name, surname, email)
        {
            Homeworks = new List<Homework>();
        }
    }
}
