using HighSchoolApp.Entities;
using HighSchoolApp.Services;
using HighSchoolApp.Servicesstudent;

namespace HighSchoolApp
{
    public class Program
    {
        public static List<Classroom> Classrooms = new();
        public static List<Student> Students = new();
        public static List<Teacher> Teachers = new();
        public static List<Homework> Homeworks = new();

        static public void Main(String[] args)
        {
            ClassroomService classroomService = new();
            ClassroomStudentServices classroomStudentServices = new();
            ClassroomTeacherServices classroomTeacherServices = new();
            StudentService studentService = new();
            TeacherService teacherService = new();
            HomeworkService homeworkService = new();

            bool exit = false;

            while (!exit)
            {
                ShowMainPage();
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    // Classroom
                    case 1:
                        bool classroomExit = false;

                        while (!classroomExit)
                        {
                            ShowClassroomOperations();
                            int option1 = Convert.ToInt32(Console.ReadLine());

                            switch (option1)
                            {
                                // Add Classroom
                                case 1:
                                    break;

                                // Delete Classroom
                                case 2:
                                    break;

                                // Get All Students of Classroom
                                case 3:
                                    break;

                                // Search Student in Classroom
                                case 4:
                                    break;

                                // Add Student to Classroom
                                case 5:
                                    break;

                                // Delete Student from Classroom
                                case 6:
                                    break;

                                // Set Teacher for Classroom
                                case 7:
                                    break;

                                // Get Teacher of Classroom
                                case 8:
                                    break;

                                // --> Get Back to Main Page <--
                                case 9:
                                    classroomExit = true;
                                    break;
                            }
                        }
                        break;

                    // Student
                    case 2:
                        bool studentExit = false;

                        while (!studentExit)
                        {
                            ShowHumanOperations("Student");
                            int option2 = Convert.ToInt32(Console.ReadLine());

                            switch (option2)
                            {
                                // Add Student
                                case 1:
                                    break;

                                // Get Student by Name Surname
                                case 2:
                                    break;

                                // Get Student by ID
                                case 3:
                                    break;
                                
                                // Update Student
                                case 4:
                                    break;
                                
                                // Delete Student
                                case 5:
                                    break;

                                // --> Get Back to Main Page <--
                                case 6:
                                    studentExit = true;
                                    break;
                            }
                        }
                        break;

                    // Teacher
                    case 3:
                        bool teacherExit = false;

                        while (!teacherExit)
                        {
                            ShowHumanOperations("Teacher");
                            int option3 = Convert.ToInt32(Console.ReadLine());

                            switch (option3)
                            {
                                // Add Teacher
                                case 1:
                                    break;

                                // Get Teacher by Name Surname
                                case 2:
                                    break;

                                // Get Teacher by ID
                                case 3:
                                    break;

                                // Update Teacher
                                case 4:
                                    break;

                                // Delete Teacher
                                case 5:
                                    break;

                                // --> Get Back to Main Page <--
                                case 6:
                                    teacherExit = true;
                                    break;
                            }
                        }
                        break;

                    // Homework
                    case 4:
                        bool homeworkExit = false;

                        while (!homeworkExit) 
                        {
                            ShowHomeworkOperations();
                            int option4 = Convert.ToInt32(Console.ReadLine());
                            
                            switch (option4)
                            {
                                // Send Homework
                                case 1:
                                    break;

                                // Get All Homeworks Submitted by a Student
                                case 2:
                                    break;

                                // Get All Homeworks Submitted to a Teacher
                                case 3:
                                    break;

                                // Get All Homeworks in the System
                                case 4:
                                    List<Homework> allHomeworks = homeworkService.GetAllHomeworksInTheSystem();
                                    allHomeworks.ForEach(h => Console.WriteLine($"Student with the ID: {h.StudentId} sent a homework titled as {h.HomeworkTitle} to the teacher with the ID: {h.TeacherId}. The lesson was {h.Lesson} and submission date for the homework was {h.SubmissionDate}."));
                                    break;

                                // --> Get Back to Main Page <--
                                case 5:
                                    homeworkExit = true;
                                    break;
                            }
                        }
                        break;

                    // --> Exit the System <--
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public static void ShowMainPage()
        {
            Console.WriteLine("Welcome to Anatolian High School!");
            Console.WriteLine("Here are the group of operation options can be performed, please pick one:");
            Console.WriteLine("1) Classroom");
            Console.WriteLine("2) Student");
            Console.WriteLine("3) Teacher");
            Console.WriteLine("4) Homework");
            Console.WriteLine("5) --> Exit the System <--");
        }

        public static void ShowClassroomOperations()
        {
            Console.WriteLine("Here are the group of operation options can be performed on classrooms, please pick one:");
            Console.WriteLine("1) Add Classroom");
            Console.WriteLine("2) Delete Classroom");
            Console.WriteLine("3) Get All Students of Classroom");
            Console.WriteLine("4) Search Student in Classroom");
            Console.WriteLine("5) Add Student to Classroom");
            Console.WriteLine("6) Delete Student from Classroom");
            Console.WriteLine("7) Set Teacher for Classroom");
            Console.WriteLine("8) Get Teacher of Classroom");
            Console.WriteLine("9) --> Get Back to Main Page <--");
        }

        public static void ShowHumanOperations(string human)
        {
            Console.WriteLine($"Here are the group of operation options can be performed on {human}, please pick one:");
            Console.WriteLine($"1) Add {human}");
            Console.WriteLine($"2) Get {human} by Name Surname");
            Console.WriteLine($"3) Get {human} by {human} ID");
            Console.WriteLine($"4) Update {human}");
            Console.WriteLine($"5) Delete {human}");
            Console.WriteLine("6) --> Get Back to Main Page <--");
        }

        public static void ShowHomeworkOperations()
        {
            Console.WriteLine("Here are the group of operation options can be performed on homeworks, please pick one:");
            Console.WriteLine("1) Send Homework");
            Console.WriteLine("2) Get All Homeworks Submitted by a Student");
            Console.WriteLine("3) Get All Homeworks Submitted to a Teacher");
            Console.WriteLine("4) Get All Homeworks in the System");
            Console.WriteLine("5) --> Get Back to Main Page <--");
        }
    }
}


