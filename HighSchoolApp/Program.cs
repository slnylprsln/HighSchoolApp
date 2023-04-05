using System.Diagnostics.Metrics;
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

        static public void Main()
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
                                    bool exitAddClassroom = false;
                                    while (!exitAddClassroom)
                                    {
                                        Console.WriteLine("Please enter a name for classroom (If you want to exit, just enter \"0\"):");
                                        string? classroomNameToAdd = Console.ReadLine();
                                        int? comparisonToAddClassroom = string.Compare(classroomNameToAdd, "0");
                                        if (comparisonToAddClassroom == 0) exitAddClassroom = true;
                                        else
                                        {
                                            Console.WriteLine("Please enter a teacher ID to set for classroom (If you prefer not to, just enter \"01\")(If you want to exit, just enter \"0\"):");
                                            int? teacherIdToAdd = Convert.ToInt32(Console.ReadLine());
                                            if (teacherIdToAdd == 01)
                                            {
                                                teacherIdToAdd = null;
                                            }
                                            else if (teacherIdToAdd != 0)
                                            {
                                                exitAddClassroom = true;
                                            }
                                            else
                                            {
                                                Classroom classroomToAdd = new(teacherIdToAdd, classroomNameToAdd);
                                                classroomService.AddClassroom(classroomToAdd);
                                                exitAddClassroom = true;
                                            }
                                        }
                                    }
                                    break;

                                // Delete Classroom
                                case 2:
                                    string? classroomNameToDelete = null;
                                    bool exitDeleting = false;
                                    while (classroomNameToDelete == null && !exitDeleting)
                                    {
                                        Console.WriteLine("Please enter the classroom name you want to delete (If you want to exit, just enter \"0\"):");
                                        classroomNameToDelete = Console.ReadLine();
                                        int comparisonExit = string.Compare(classroomNameToDelete, "0");
                                        if (classroomNameToDelete == null) Console.WriteLine("You entered null value, please try again!");
                                        else if (comparisonExit == 0) exitDeleting = true;
                                        else if (classroomNameToDelete != null && comparisonExit != 0) classroomService.DeleteClassroom(classroomNameToDelete);
                                    }
                                    break;

                                // Get All Students of Classroom
                                case 3:
                                    string? classroomNameToGetStudentList = null;
                                    bool exitGetStudentList = false;
                                    while (classroomNameToGetStudentList == null && !exitGetStudentList)
                                    {
                                        Console.WriteLine("Please enter the classroom name you want to get student list of (If you want to exit, just enter \"0\"):");
                                        classroomNameToGetStudentList = Console.ReadLine();
                                        int comparisonToGetStudentList = string.Compare(classroomNameToGetStudentList, "0");
                                        if (classroomNameToGetStudentList == null) Console.WriteLine("You entered null value, please try again!");
                                        else if (comparisonToGetStudentList == 0) exitGetStudentList = true;
                                        else if (classroomNameToGetStudentList != null && comparisonToGetStudentList != 0)
                                        {
                                            Console.WriteLine($"Here is the student list for the classroom {classroomNameToGetStudentList}");
                                            List<Student> studentOfClassroom = classroomStudentServices.GetAllStudentsOfClassroom(classroomNameToGetStudentList);
                                            foreach (var st in studentOfClassroom)
                                            {
                                                Console.WriteLine($"Student ID: {st.Id}");
                                                Console.WriteLine($"Name Surname: {st.Name} {st.Surname}");
                                                Console.WriteLine($"Email: {st.Email}");
                                            }
                                            Console.WriteLine("--- End of the Student List ---");
                                        }
                                    }
                                    break;

                                // Search Student in Classroom
                                case 4:
                                    bool exitSearchStudent = false;
                                    while (!exitSearchStudent)
                                    {
                                        Console.WriteLine("Please enter a student ID to search for (If you want to exit, just enter \"0\"):");
                                        int? studentIdToSearch = Convert.ToInt32(Console.ReadLine());
                                        if (studentIdToSearch == 0) exitSearchStudent = true;
                                        else
                                        {
                                            Console.WriteLine($"Please enter a classroom name to search for student with the ID: {studentIdToSearch} (If you want to exit, just enter \"0\"):");
                                            string? classroomNameToSearchStudent = Console.ReadLine();
                                            int comparisonSearchStudent = string.Compare(classroomNameToSearchStudent, "0");
                                            if (comparisonSearchStudent == 0) exitSearchStudent = true;
                                            else
                                            {
                                                Student searchedStudent = classroomStudentServices.SearchStudentInClassroom(studentIdToSearch, classroomNameToSearchStudent);
                                                Console.WriteLine($"Classroom {classroomNameToSearchStudent} has this student.");
                                            }
                                        }
                                    }
                                    break;

                                // Add Student to Classroom
                                case 5:
                                    bool exitAddStudentIntoClassroom = false;
                                    while (!exitAddStudentIntoClassroom)
                                    {
                                        Console.WriteLine("Please enter a student ID to add into a classroom (If you want to exit, just enter \"0\"):");
                                        int? studentIdToAddIntoClassroom = Convert.ToInt32(Console.ReadLine());
                                        if (studentIdToAddIntoClassroom == 0) exitAddStudentIntoClassroom = true;
                                        else
                                        {
                                            Console.WriteLine($"Plase enter the classroom name you want to add student with ID: {studentIdToAddIntoClassroom} into (If you want to exit, just enter \"0\"):");
                                            string? classroomNameToAddStudent = Console.ReadLine();
                                            int comparisonAddStudentIntoClassroom = String.Compare(classroomNameToAddStudent, "0");
                                            if (comparisonAddStudentIntoClassroom == 0) exitAddStudentIntoClassroom = true;
                                            else classroomStudentServices.AddStudentToClassroom(studentIdToAddIntoClassroom, classroomNameToAddStudent);
                                        }
                                    }
                                    break;

                                // Delete Student from Classroom
                                case 6:
                                    bool exitDeleteStudentFromClassroom = false;
                                    while (!exitDeleteStudentFromClassroom)
                                    {
                                        Console.WriteLine("Please enter a student ID to delete from a classroom (If you want to exit, just enter \"0\"):");
                                        int? studentIdToDeleteFromClassroom = Convert.ToInt32(Console.ReadLine());
                                        if (studentIdToDeleteFromClassroom == 0) exitDeleteStudentFromClassroom = true;
                                        else
                                        {
                                            Console.WriteLine($"Plase enter the classroom name you want to delete student with ID: {studentIdToDeleteFromClassroom} from (If you want to exit, just enter \"0\"):");
                                            string? classroomNameToDeleteStudent = Console.ReadLine();
                                            int comparisonDeleteStudentFromClassroom = string.Compare(classroomNameToDeleteStudent, "0");
                                            if (comparisonDeleteStudentFromClassroom == 0) exitDeleteStudentFromClassroom = true;
                                            else classroomStudentServices.DeleteStudentFromClassroom(studentIdToDeleteFromClassroom, classroomNameToDeleteStudent);
                                        }
                                    }
                                    break;

                                // Set Teacher for Classroom
                                case 7:
                                    bool exitSetTeacher = false;
                                    while (!exitSetTeacher)
                                    {
                                        Console.WriteLine("Please enter a teacher ID to set as a teacher of a classroom (If you want to exit, just enter \"0\"):");
                                        int? teacherIdToSet = Convert.ToInt32(Console.ReadLine());
                                        if (teacherIdToSet == 0) exitSetTeacher = true;
                                        else
                                        {
                                            Console.WriteLine("Please enter a classroom name to set teacher (If you want to exit, just enter \"0\"):");
                                            string? classroomNameToSetTeacher = Console.ReadLine();
                                            int comparisonToSetTeacher = string.Compare(classroomNameToSetTeacher, "0");
                                            if (comparisonToSetTeacher == 0) exitSetTeacher = true;
                                            else
                                            {
                                                classroomTeacherServices.SetTeacherForClassroom(teacherIdToSet, classroomNameToSetTeacher);
                                                exitSetTeacher = true;
                                            }
                                        }
                                    }
                                    break;

                                // Get Teacher of Classroom
                                case 8:
                                    bool exitGetTeacherOfClassroom = false;
                                    while (!exitGetTeacherOfClassroom)
                                    {
                                        Console.WriteLine("Please enter the classroom name you want to get teacher of (If you want to exit, just enter \"0\"):");
                                        string? classroomNameToGetTeacher = Console.ReadLine();
                                        int? comparisonToGetTeacher = string.Compare(classroomNameToGetTeacher, "0");
                                        if (comparisonToGetTeacher == 0) exitGetTeacherOfClassroom = true;
                                        else
                                        {
                                            if (classroomNameToGetTeacher != null) 
                                            {
                                                classroomTeacherServices.GetTeacherOfClassroom(classroomNameToGetTeacher);
                                                exitGetTeacherOfClassroom = true;
                                            }
                                            else Console.WriteLine("You entered null value, please try again!");
                                        }
                                    }
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


