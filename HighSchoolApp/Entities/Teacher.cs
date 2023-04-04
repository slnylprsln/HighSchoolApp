namespace HighSchoolApp.Entities
{
    public class Teacher : Person
    {
        public List<Homework> Homeworks { get; set; }

        public Teacher(int? id = null, string? name = null, string? surname = null, string? email = null) : base(id, name, surname, email)
        {
            Homeworks = new List<Homework>();
        }
    }
}
