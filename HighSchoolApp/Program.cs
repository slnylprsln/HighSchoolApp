using HighSchoolApp.Entities;
using HighSchoolApp.Services;
using HighSchoolApp.Servicesstudent;
using System;

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
            StudentService studentService = new();
            TeacherService teacherService = new();

            Random r = new Random();

            ShowMainPage();
            int option1 = Convert.ToInt32(Console.ReadLine());
            switch (option1)
            {
                case 1:
                    ShowClassroomOperations();
                    int option2 = Convert.ToInt32(Console.ReadLine());
                    switch (option2)
                    {
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                    }
                    break;
                case 2:
                    ShowHumanOperations("Student");
                    int option3 = Convert.ToInt32(Console.ReadLine());
                    switch (option3)
                    {
                        case 1:
                            Console.WriteLine("Please enter credentials of student");
                            Console.WriteLine("Name Surname:");
                            string? nameSurname = Console.ReadLine();
                            Console.WriteLine("Classroom Name:");
                            string? classroomName = Console.ReadLine();
                            int studentId = r.Next(1, 101);
                            Student studentToAdd = new()
                            {
                                StudentId = studentId,
                                NameSurname = nameSurname,
                                // EMAIL EKLE
                            };
                            studentService.AddStudent(studentToAdd);
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                    }
                    break;
                case 3:
                    ShowHumanOperations("Teacher");
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }


        }

        public static void ShowMainPage()
        {
            Console.WriteLine("Welcome to Anatolian High School!");
            Console.WriteLine("Here are the group of operation options can be performed, please pick one:");
            Console.WriteLine("1) Classroom");
            Console.WriteLine("2) Student");
            Console.WriteLine("3) Teacher");
            Console.WriteLine("4) Quit");
        }

        public static void ShowClassroomOperations()
        {
            Console.WriteLine("Here are the group of operation options can be performed on classrooms, please pick one:");
            Console.WriteLine("1) Add a Classroom");
            Console.WriteLine("2) Get All Students of a Classroom");
            Console.WriteLine("3) Delete a Classroom");
            Console.WriteLine("4) Update a Classroom");
        }

        public static void ShowHumanOperations(string human)
        {
            Console.WriteLine($"Here are the group of operation options can be performed on {human}, please pick one:");
            Console.WriteLine($"1) Add a {human}");
            Console.WriteLine($"2) Get {human} by {human} ID");
            Console.WriteLine($"3) Delete a {human}");
            Console.WriteLine($"4) Update a {human}");
        }
    }




}


