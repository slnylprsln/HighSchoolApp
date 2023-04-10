
using HighSchoolApp.IServices;
using HighSchoolApp.Services;

namespace HighSchoolApp.Factories
{
    public class ClassroomTeacherFactory
    {
        public static IClassroomTeacherService Create()
        {
            return new ClassroomTeacherService();
        }
    }
}
