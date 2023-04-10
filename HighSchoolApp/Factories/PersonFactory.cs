
using HighSchoolApp.Entities;
using HighSchoolApp.IServices;
using HighSchoolApp.Services;

namespace HighSchoolApp.Factories
{
    public class PersonFactory
    {
        public static IPersonService<T> Create<T>()
        {
            if (typeof(T) == typeof(Student))
            {
                return (IPersonService<T>) new StudentService();
            }
            else if (typeof(T) == typeof(Teacher))
            {
                return (IPersonService<T>)new TeacherService();
            }
            else throw new InvalidOperationException();
        }
    }
}
