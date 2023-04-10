
using HighSchoolApp.IServices;
using HighSchoolApp.Services;

namespace HighSchoolApp.Factories
{
    public class HomeworkFactory
    {
        public static IHomeworkService Create()
        {
            return new HomeworkService();
        }
    }
}
