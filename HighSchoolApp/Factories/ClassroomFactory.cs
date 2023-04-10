
using HighSchoolApp.IServices;
using HighSchoolApp.Services;

namespace HighSchoolApp.Factories
{
    public class ClassroomFactory
    {
        public static IClassroomService Create()
        {
            return new ClassroomService();
        }
    }
}
