namespace HighSchoolApp.Entities
{
    public class Person
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }

        public Person(string? name = null, string? surname = null, string? email = null)
        {
            Random r = new Random();
            Id = r.Next(1, 1000000);
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}
