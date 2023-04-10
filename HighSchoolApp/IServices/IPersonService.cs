
namespace HighSchoolApp.IServices
{
    public interface IPersonService<T>
    {
        public void Add(T t);
        public T? GetByNameSurname(string name, string surname);
        public T? GetById(int? id);
        public void Update(int? id, T update);
        public void Delete(int? id);
        public List<T>? GetAll();
    }
}
