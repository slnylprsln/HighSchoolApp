
using HighSchoolApp.IServices;
using HighSchoolApp.Services;

namespace HighSchoolApp.Factories
{
    public class ClassroomStudentFactory
    {
        public static IClassroomStudentService Create()
        {
            return new ClassroomStudentService();
        }
    }
}
