using HighSchoolApp.Entities;
using HighSchoolApp.Factories;
using HighSchoolApp.IServices;
using HighSchoolApp.Services;

namespace HighSchoolApp
{
    public class Program
    {
        public static List<Classroom> Classrooms = new();
        public static List<Student> Students = new();
        public static List<Teacher> Teachers = new();
        public static List<Homework> Homeworks = new();

        public static IClassroomService classroomService = ClassroomFactory.Create();
        public static IClassroomStudentService classroomStudentServices = ClassroomStudentFactory.Create();
        public static IClassroomTeacherService classroomTeacherServices = ClassroomTeacherFactory.Create();
        public static IPersonService<Student> studentService = PersonFactory.Create<Student>();
        public static IPersonService<Teacher> teacherService = PersonFactory.Create<Teacher>();
        public static IHomeworkService homeworkService = HomeworkFactory.Create();

        static public void Main()
        {
            Console.WriteLine("Welcome to Anatolian High School!");

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
                                    while (!exitAddClassroom) exitAddClassroom = HandleAddClassroom();
                                    break;

                                // Delete Classroom
                                case 2:
                                    bool exitDeleting = false;
                                    while (!exitDeleting) exitDeleting = HandleDeleteClassroom();
                                    break;
                               
                                // Get All Classrooms
                                case 3:
                                    HandleGetAllClassrooms();
                                    break;

                                // Get All Students of Classroom
                                case 4:
                                    bool exitGetStudentList = false;
                                    while (!exitGetStudentList) exitGetStudentList = HandleGetAllStudentsOfClassroom();
                                    break;

                                // Search Student in Classroom
                                case 5:
                                    bool exitSearchStudent = false;
                                    while (!exitSearchStudent) exitSearchStudent = HandleSearchStudentInClassroom();
                                    break;

                                // Add Student to Classroom
                                case 6:
                                    bool exitAddStudentIntoClassroom = false;
                                    while (!exitAddStudentIntoClassroom) exitAddStudentIntoClassroom = HandleAddStudentToClassroom();
                                    break;

                                // Delete Student from Classroom
                                case 7:
                                    bool exitDeleteStudentFromClassroom = false;
                                    while (!exitDeleteStudentFromClassroom) exitDeleteStudentFromClassroom = HandleDeleteStudentFromClassroom();
                                    break;

                                // Set Teacher for Classroom
                                case 8:
                                    bool exitSetTeacher = false;
                                    while (!exitSetTeacher) exitSetTeacher = HandleSetTeacherForClassroom();
                                    break;

                                // Get Teacher of Classroom
                                case 9:
                                    bool exitGetTeacherOfClassroom = false;
                                    while (!exitGetTeacherOfClassroom) exitGetTeacherOfClassroom = HandleGetTeacherOfClassroom();
                                    break;

                                // --> Get Back to Main Page <--
                                case 10:
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
                                    bool exitStudentAdd = false;
                                    while (!exitStudentAdd) exitStudentAdd = HandleAddStudent();
                                    break;

                                // Get Student by Name Surname
                                case 2:
                                    bool exitSearchStudent = false;
                                    while (!exitSearchStudent) exitSearchStudent = HandleGetStudentByNameSurname();
                                    break;

                                // Get Student by ID
                                case 3:
                                    bool exitSearchID = false;
                                    while (!exitSearchID) exitSearchID = HandleGetStudentById();
                                    break;

                                // Update Student
                                case 4:
                                    bool exitUpdateID = false;
                                    while (!exitUpdateID) exitUpdateID = HandleUpdateStudent();
                                    break;

                                // Delete Student
                                case 5:
                                    bool exitDeleteID = false;
                                    while (!exitDeleteID) exitDeleteID = HandleDeleteStudent();
                                    break;

                                // Get All Students
                                case 6:
                                    HandleGetAllStudents();
                                    break;

                                // --> Get Back to Main Page <--
                                case 7:
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
                                    bool exitTeacherAdd = false;
                                    while (!exitTeacherAdd) exitTeacherAdd = HandleAddTeacher();
                                    break;

                                // Get Teacher by Name Surname
                                case 2:
                                    bool exitSearchTeacher = false;
                                    while (!exitSearchTeacher) exitSearchTeacher = HandleGetTeacherByNameSurname();
                                    break;

                                // Get Teacher by ID
                                case 3:
                                    bool exitSearchID = false;
                                    while (!exitSearchID) exitSearchID = HandleGetTeacherById();
                                    break;

                                // Update Teacher
                                case 4:
                                    bool exitUpdateID = false;
                                    while (!exitUpdateID) exitUpdateID = HandleUpdateTeacher();
                                    break;

                                // Delete Teacher
                                case 5:
                                    bool exitDeleteID = false;
                                    while (!exitDeleteID) exitDeleteID = HandleDeleteTeacher();
                                    break;

                                // Get All Teachers
                                case 6:
                                    HandleGetAllTeachers();
                                    break;

                                // --> Get Back to Main Page <--
                                case 7:
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
                                    bool exitSendHomework = false;
                                    while (!exitSendHomework) exitSendHomework = HandleSendHomework();
                                    break;

                                // Get All Homeworks Submitted by a Student
                                case 2:
                                    bool exitByStudent = false;
                                    while (!exitByStudent) exitByStudent = HandleGetAllHomeworksSubmittedByAStudent();
                                    break;

                                // Get All Homeworks Submitted to a Teacher
                                case 3:
                                    bool exitToTeacher = false;
                                    while (!exitToTeacher) exitToTeacher = HandleGetAllHomeworksSubmittedToATeacher();
                                    break;

                                // Get All Homeworks in the System
                                case 4:
                                    GetAllHomeworksInTheSystem();
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
                        Console.WriteLine("Goodbye! Have a nice day!");
                        Environment.Exit(0);
                        break;
                }
            }
        }

        public static void ShowMainPage()
        {
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
            Console.WriteLine("3) Get All Classrooms");
            Console.WriteLine("4) Get All Students of Classroom");
            Console.WriteLine("5) Search Student in Classroom");
            Console.WriteLine("6) Add Student to Classroom");
            Console.WriteLine("7) Delete Student from Classroom");
            Console.WriteLine("8) Set Teacher for Classroom");
            Console.WriteLine("9) Get Teacher of Classroom");
            Console.WriteLine("10) --> Get Back to Main Page <--");
        }

        public static void ShowHumanOperations(string human)
        {
            Console.WriteLine($"Here are the group of operation options can be performed on {human}, please pick one:");
            Console.WriteLine($"1) Add {human}");
            Console.WriteLine($"2) Get {human} by Name Surname");
            Console.WriteLine($"3) Get {human} by {human} ID");
            Console.WriteLine($"4) Update {human}");
            Console.WriteLine($"5) Delete {human}");
            Console.WriteLine($"6) Get All {human}s");
            Console.WriteLine("7) --> Get Back to Main Page <--");
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

        /* CLASSROOM OPERATIONS */
        public static bool HandleAddClassroom()
        {
            Console.WriteLine("Please enter a name for classroom (If you want to exit, just enter \"0\"):");
            string? classroomNameToAdd = Console.ReadLine();
            int? comparisonToAddClassroom = string.Compare(classroomNameToAdd, "0");
            if (comparisonToAddClassroom == 0) return true;
            else
            {
                Console.WriteLine("Please enter a teacher ID to set for classroom (If you prefer not to, just enter \"01\")(If you want to exit, just enter \"0\"):");
                int? teacherIdToAdd = Convert.ToInt32(Console.ReadLine());
                if (teacherIdToAdd == 0) return true;
                else
                {
                    if (classroomNameToAdd != null)
                    {
                        if (teacherIdToAdd == 01)
                        {
                            teacherIdToAdd = null;
                        }
                        Classroom classroomToAdd = new(teacherIdToAdd, classroomNameToAdd);
                        classroomService.AddClassroom(classroomToAdd);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("You entered null value, please try again!");
                        return false;
                    }
                }
            }
        }

        public static bool HandleDeleteClassroom()
        {
            Console.WriteLine("Please enter the classroom name you want to delete (If you want to exit, just enter \"0\"):");
            string? classroomNameToDelete = Console.ReadLine();
            int comparisonExit = string.Compare(classroomNameToDelete, "0");
            if (comparisonExit == 0) return true;
            else
            {
                if (classroomNameToDelete != null)
                {
                    classroomService.DeleteClassroom(classroomNameToDelete);
                    return true;
                }
                else
                {
                    Console.WriteLine("You entered null value, please try again!");
                    return false;
                }
            }
        }

        public static void HandleGetAllClassrooms()
        {
            List<Classroom>? allClassrooms = classroomService.GetAllClassrooms();
            if (allClassrooms != null)
            {
                foreach (var t in allClassrooms)
                {
                    Console.WriteLine($"Classroom Name: {t.ClassroomName}\nStudent Count: {t.Students.Count}\nTeacher ID: {t.TeacherId}");
                }
            }
            Console.WriteLine("--- End of the Classroom List ---");
        }

        public static bool HandleGetAllStudentsOfClassroom()
        {
            Console.WriteLine("Please enter the classroom name you want to get student list of (If you want to exit, just enter \"0\"):");
            string? classroomNameToGetStudentList = Console.ReadLine();
            int comparisonToGetStudentList = string.Compare(classroomNameToGetStudentList, "0");
            if (comparisonToGetStudentList == 0) return true;
            else
            {
                if (classroomNameToGetStudentList != null)
                {
                    Console.WriteLine($"Here is the student list for the classroom {classroomNameToGetStudentList}");
                    List<Student>? studentOfClassroom = classroomStudentServices.GetAllStudentsOfClassroom(classroomNameToGetStudentList);
                    if (studentOfClassroom != null)
                    {
                        foreach (var st in studentOfClassroom)
                        {
                            Console.WriteLine($"Student ID: {st.Id}");
                            Console.WriteLine($"Name Surname: {st.Name} {st.Surname}");
                            Console.WriteLine($"Email: {st.Email}");
                        }
                    }
                    Console.WriteLine("--- End of the Student List ---");
                    return true;
                }
                else
                {
                    Console.WriteLine("You entered null value, please try again!");
                    return false;
                }
            }
        }

        public static bool HandleSearchStudentInClassroom()
        {
            Console.WriteLine("Please enter a student ID to search for (If you want to exit, just enter \"0\"):");
            int? studentIdToSearch = Convert.ToInt32(Console.ReadLine());
            if (studentIdToSearch == 0) return true;
            else
            {
                Console.WriteLine($"Please enter a classroom name to search for student with the ID: {studentIdToSearch} (If you want to exit, just enter \"0\"):");
                string? classroomNameToSearchStudent = Console.ReadLine();
                if (classroomNameToSearchStudent != null)
                {
                    int comparisonSearchStudent = string.Compare(classroomNameToSearchStudent, "0");
                    if (comparisonSearchStudent == 0) return true;
                    else
                    {
                        Student? searchedStudent = classroomStudentServices.SearchStudentInClassroom(studentIdToSearch, classroomNameToSearchStudent);
                        if (searchedStudent != null) Console.WriteLine($"Classroom {classroomNameToSearchStudent} has this student.");
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("You entered null value, please try again!");
                    return false;
                }
            }
        }

        public static bool HandleAddStudentToClassroom()
        {
            Console.WriteLine("Please enter a student ID to add into a classroom (If you want to exit, just enter \"0\"):");
            int? studentIdToAddIntoClassroom = Convert.ToInt32(Console.ReadLine());
            if (studentIdToAddIntoClassroom == 0) return true;
            else
            {
                Console.WriteLine($"Plase enter the classroom name you want to add student with ID: {studentIdToAddIntoClassroom} into (If you want to exit, just enter \"0\"):");
                string? classroomNameToAddStudent = Console.ReadLine();
                int comparisonAddStudentIntoClassroom = string.Compare(classroomNameToAddStudent, "0");
                if (comparisonAddStudentIntoClassroom == 0) return true;
                else
                {
                    classroomStudentServices.AddStudentToClassroom(studentIdToAddIntoClassroom, classroomNameToAddStudent);
                    return true;
                }
            }
        }

        public static bool HandleDeleteStudentFromClassroom()
        {
            Console.WriteLine("Please enter a student ID to delete from a classroom (If you want to exit, just enter \"0\"):");
            int? studentIdToDeleteFromClassroom = Convert.ToInt32(Console.ReadLine());
            if (studentIdToDeleteFromClassroom == 0) return true;
            else
            {
                Console.WriteLine($"Plase enter the classroom name you want to delete student with ID: {studentIdToDeleteFromClassroom} from (If you want to exit, just enter \"0\"):");
                string? classroomNameToDeleteStudent = Console.ReadLine();
                int comparisonDeleteStudentFromClassroom = string.Compare(classroomNameToDeleteStudent, "0");
                if (comparisonDeleteStudentFromClassroom == 0) return true;
                else
                {
                    classroomStudentServices.DeleteStudentFromClassroom(studentIdToDeleteFromClassroom, classroomNameToDeleteStudent);
                    return true;
                }
            }
        }

        public static bool HandleSetTeacherForClassroom()
        {
            Console.WriteLine("Please enter a teacher ID to set as a teacher of a classroom (If you want to exit, just enter \"0\"):");
            int? teacherIdToSet = Convert.ToInt32(Console.ReadLine());
            if (teacherIdToSet == 0) return true;
            else
            {
                Console.WriteLine("Please enter a classroom name to set teacher (If you want to exit, just enter \"0\"):");
                string? classroomNameToSetTeacher = Console.ReadLine();
                int comparisonToSetTeacher = string.Compare(classroomNameToSetTeacher, "0");
                if (comparisonToSetTeacher == 0) return true;
                else
                {
                    classroomTeacherServices.SetTeacherForClassroom(teacherIdToSet, classroomNameToSetTeacher);
                    return true;
                }
            }
        }

        public static bool HandleGetTeacherOfClassroom()
        {
            Console.WriteLine("Please enter the classroom name you want to get teacher of (If you want to exit, just enter \"0\"):");
            string? classroomNameToGetTeacher = Console.ReadLine();
            int? comparisonToGetTeacher = string.Compare(classroomNameToGetTeacher, "0");
            if (comparisonToGetTeacher == 0) return true;
            else
            {
                if (classroomNameToGetTeacher != null)
                {
                    Teacher? foundTeacher = classroomTeacherServices.GetTeacherOfClassroom(classroomNameToGetTeacher);
                    if (foundTeacher != null)
                    {
                        Console.WriteLine($"The teacher of the classroom {classroomNameToGetTeacher} is {foundTeacher.Name} {foundTeacher.Surname}!");
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("You entered null value, please try again!");
                    return false;
                }
            }
        }

        /* STUDENT OPERATIONS */
        public static bool HandleAddStudent()
        {
            Console.WriteLine("Please enter name of the student (If you want to exit, just enter \"0\"):");
            string? studentNameToAdd = Console.ReadLine();
            int compareToAddStudentName = string.Compare(studentNameToAdd, "0");
            if (compareToAddStudentName == 0) return true;
            else
            {
                if (studentNameToAdd != null)
                {
                    Console.WriteLine("Please enter surname of the student (If you want to exit, just enter \"0\"):");
                    string? studentSurnameToAdd = Console.ReadLine();
                    int compareToAddStudentSurname = string.Compare(studentSurnameToAdd, "0");
                    if (compareToAddStudentSurname == 0) return true;
                    else
                    {
                        if (studentSurnameToAdd != null)
                        {
                            Console.WriteLine("Please enter email of the student (If you want to exit, just enter \"0\"):");
                            string? studentEmailToAdd = Console.ReadLine();
                            int compareToAddStudentEmail = string.Compare(studentEmailToAdd, "0");
                            if (compareToAddStudentEmail == 0) return true;
                            else
                            {
                                if (studentEmailToAdd != null)
                                {
                                    Student toAdd = new()
                                    {
                                        Name = studentNameToAdd,
                                        Surname = studentSurnameToAdd,
                                        Email = studentEmailToAdd
                                    };
                                    studentService.Add(toAdd);
                                    return true;
                                }
                                else
                                {
                                    Console.WriteLine("You entered null value, please try again!");
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("You entered null value, please try again!");
                            return false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You entered null value, please try again!");
                    return false;
                }
            }
        }

        public static bool HandleGetStudentByNameSurname()
        {
            Console.WriteLine("Please enter name and surname of the student that you want to search (If you want to exit, just enter \"0\"):");
            string? nameSurname = Console.ReadLine();
            int compareNameSurname = string.Compare(nameSurname, "0");
            if (compareNameSurname == 0) return true;
            else
            {
                if (nameSurname != null)
                {
                    string[] both = nameSurname.Split(' ');
                    if (both.Length != 2)
                    {
                        Console.WriteLine("You entered less or more expressions. Please try again!");
                        return false;
                    }
                    else
                    {
                        string name = both[0];
                        string surname = both[1];
                        Student? foundStudent = studentService.GetByNameSurname(name, surname);
                        if (foundStudent != null)
                        {
                            Console.WriteLine($"Student {name} {surname} exists! The student's ID is {foundStudent.Id} and email is {foundStudent.Email}.");
                        }
                        return true;
                    }

                }
                else
                {
                    Console.WriteLine("You entered null value, please try again!");
                    return false;
                }
            }
        }

        public static bool HandleGetStudentById()
        {
            Console.WriteLine("Please enter ID of the student that you want to search (If you want to exit, just enter \"0\"):");
            int? Id = Convert.ToInt32(Console.ReadLine());
            if (Id == 0) return true;
            else
            {
                if (Id != null)
                {
                    Student? foundStudent = studentService.GetById(Id);
                    if (foundStudent != null)
                    {
                        Console.WriteLine($"Student with the ID: {Id} exists! The student's name surname is {foundStudent.Name} {foundStudent.Surname} and email is {foundStudent.Email}.");
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("You entered null value, please try again!");
                    return false;
                }
            }
        }

        public static bool HandleUpdateStudent()
        {
            Console.WriteLine("Please enter ID of the student that you want to update (If you want to exit, just enter \"0\"):");
            int? Id = Convert.ToInt32(Console.ReadLine());
            if (Id == 0) return true;
            else
            {
                if (Id != null)
                {
                    Console.WriteLine("Please enter a new email to update student (If you want to exit, just enter \"0\"):");
                    string? newEmail = Console.ReadLine();
                    int compareEmail = string.Compare(newEmail, "0");
                    if (compareEmail == 0) return true;
                    else
                    {
                        if (newEmail != null)
                        {
                            Student updatedStudent = new()
                            {
                                Name = null,
                                Surname = null,
                                Email = newEmail
                            };
                            studentService.Update(Id, updatedStudent);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("You entered null value, please try again!");
                            return false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You entered null value, please try again!");
                    return false;
                }
            }
        }

        public static bool HandleDeleteStudent()
        {
            Console.WriteLine("Please enter ID of the student that you want to delete (If you want to exit, just enter \"0\"):");
            int? Id = Convert.ToInt32(Console.ReadLine());
            if (Id == 0) return true;
            else
            {
                if (Id != null)
                {
                    studentService.Delete(Id);
                    return true;
                }
                else
                {
                    Console.WriteLine("You entered null value, please try again!");
                    return false;
                }
            }
        }

        public static void HandleGetAllStudents()
        {
            List<Student>? allStudents = studentService.GetAll();
            if (allStudents != null)
            {
                foreach (var t in allStudents)
                {
                    Console.WriteLine($"Student ID: {t.Id}\nName Surname: {t.Name} {t.Surname}\nEmail: {t.Email}");
                }
            }
            Console.WriteLine("--- End of the Student List ---");
        }

        /* TEACHER OPERATIONS */
        public static bool HandleAddTeacher()
        {
            Console.WriteLine("Please enter name of the teacher (If you want to exit, just enter \"0\"):");
            string? teacherNameToAdd = Console.ReadLine();
            int compareToAddTeacherName = string.Compare(teacherNameToAdd, "0");
            if (compareToAddTeacherName == 0) return true;
            else
            {
                if (teacherNameToAdd != null)
                {
                    Console.WriteLine("Please enter surname of the teacher (If you want to exit, just enter \"0\"):");
                    string? teacherSurnameToAdd = Console.ReadLine();
                    int compareToAddTeacherSurname = string.Compare(teacherSurnameToAdd, "0");
                    if (compareToAddTeacherSurname == 0) return true;
                    else
                    {
                        if (teacherSurnameToAdd != null)
                        {
                            Console.WriteLine("Please enter email of the teacher (If you want to exit, just enter \"0\"):");
                            string? teacherEmailToAdd = Console.ReadLine();
                            int compareToAddTeacherEmail = string.Compare(teacherEmailToAdd, "0");
                            if (compareToAddTeacherEmail == 0) return true;
                            else
                            {
                                if (teacherEmailToAdd != null)
                                {
                                    Teacher toAdd = new()
                                    {
                                        Name = teacherNameToAdd,
                                        Surname = teacherSurnameToAdd,
                                        Email = teacherEmailToAdd
                                    };
                                    teacherService.Add(toAdd);
                                    return true;
                                }
                                else
                                {
                                    Console.WriteLine("You entered null value, please try again!");
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("You entered null value, please try again!");
                            return false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You entered null value, please try again!");
                    return false;
                }
            }
        }

        public static bool HandleGetTeacherByNameSurname()
        {
            Console.WriteLine("Please enter name and surname of the teacher that you want to search (If you want to exit, just enter \"0\"):");
            string? nameSurname = Console.ReadLine();
            int compareNameSurname = string.Compare(nameSurname, "0");
            if (compareNameSurname == 0) return true;
            else
            {
                if (nameSurname != null)
                {
                    string[] both = nameSurname.Split(' ');
                    if (both.Length != 2)
                    {
                        Console.WriteLine("You entered less or more expressions. Please try again!");
                        return false;
                    }
                    else
                    {
                        string name = both[0];
                        string surname = both[1];
                        Teacher? foundTeacher = teacherService.GetByNameSurname(name, surname);
                        if (foundTeacher != null)
                        {
                            Console.WriteLine($"Teacher {name} {surname} exists! The teacher's ID is {foundTeacher.Id} and email is {foundTeacher.Email}.");
                        }
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("You entered null value, please try again!");
                    return false;
                }
            }
        }

        public static bool HandleGetTeacherById()
        {
            Console.WriteLine("Please enter ID of the teacher that you want to search (If you want to exit, just enter \"0\"):");
            int? Id = Convert.ToInt32(Console.ReadLine());
            if (Id == 0) return true;
            else
            {
                if (Id != null)
                {
                    Teacher? foundTeacher = teacherService.GetById(Id);
                    if (foundTeacher != null)
                    {
                        Console.WriteLine($"Teacher with the ID: {Id} exists! The teacher's name surname is {foundTeacher.Name} {foundTeacher.Surname} and email is {foundTeacher.Email}.");
                    }
                    return true;
                }
                else
                {
                    Console.WriteLine("You entered null value, please try again!");
                    return false;
                }
            }
        }

        public static bool HandleUpdateTeacher()
        {
            Console.WriteLine("Please enter ID of the teacher that you want to update (If you want to exit, just enter \"0\"):");
            int? Id = Convert.ToInt32(Console.ReadLine());
            if (Id == 0) return true;
            else
            {
                if (Id != null)
                {
                    Console.WriteLine("Please enter a new email to update teacher (If you want to exit, just enter \"0\"):");
                    string? newEmail = Console.ReadLine();
                    int compareEmail = string.Compare(newEmail, "0");
                    if (compareEmail == 0) return true;
                    else
                    {
                        if (newEmail != null)
                        {
                            Teacher updatedTeacher = new()
                            {
                                Name = null,
                                Surname = null,
                                Email = newEmail
                            };
                            teacherService.Update(Id, updatedTeacher);
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("You entered null value, please try again!");
                            return false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You entered null value, please try again!");
                    return false;
                }
            }
        }

        public static bool HandleDeleteTeacher()
        {
            Console.WriteLine("Please enter ID of the teacher that you want to delete (If you want to exit, just enter \"0\"):");
            int? Id = Convert.ToInt32(Console.ReadLine());
            if (Id == 0) return true;
            else
            {
                if (Id != null)
                {
                    teacherService.Delete(Id);
                    return true;
                }
                else
                {
                    Console.WriteLine("You entered null value, please try again!");
                    return false;
                }
            }
        }

        public static void HandleGetAllTeachers()
        {
            List<Teacher>? allTeachers = teacherService.GetAll();
            if (allTeachers != null)
            {
                foreach (var t in allTeachers)
                {
                    Console.WriteLine($"Teacher ID: {t.Id}\nName Surname: {t.Name} {t.Surname}\nEmail: {t.Email}");
                }
            }
            Console.WriteLine("--- End of the Teacher List ---");
        }

        /* HOMEWORK OPERATIONS */
        public static bool HandleSendHomework()
        {
            Console.WriteLine("Please enter the student ID who prepared the homework (If you want to exit, just enter \"0\"):");
            int studentId = Convert.ToInt32(Console.ReadLine());
            if (studentId == 0) return true;
            else
            {
                Console.WriteLine("Please enter the teacher ID to send homework to (If you want to exit, just enter \"0\"):");
                int teacherId = Convert.ToInt32(Console.ReadLine());
                if (teacherId == 0) return true;
                else
                {
                    Console.WriteLine("Please enter name of the lesson (If you want to exit, just enter \"0\"):");
                    string? lesson = Console.ReadLine();
                    int comparisonLesson = string.Compare(lesson, "0");
                    if (comparisonLesson == 0) return true;
                    else
                    {
                        Console.WriteLine("Please enter title of the homework (If you want to exit, just enter \"0\"):");
                        string? homeworkTitle = Console.ReadLine();
                        int comparisonTitle = string.Compare(homeworkTitle, "0");
                        if (comparisonTitle == 0) return true;
                        else
                        {
                            Homework hw = new()
                            {
                                StudentId = studentId,
                                TeacherId = teacherId,
                                Lesson = lesson,
                                HomeworkTitle = homeworkTitle
                            };
                            homeworkService.SendHomework(hw);
                            return true;
                        }
                    }
                }
            }
        }

        public static bool HandleGetAllHomeworksSubmittedByAStudent()
        {
            Console.WriteLine("Please enter student ID that you want to see homeworks of (If you want to exit, just enter \"0\"):");
            int studentHomeworkId = Convert.ToInt32(Console.ReadLine());
            if (studentHomeworkId == 0) return true;
            else
            {
                List<Homework>? homeworksStudent = homeworkService.GetAllHomeworksSubmittedByAStudent(studentHomeworkId);
                if (homeworksStudent != null)
                {
                    foreach (var h in homeworksStudent)
                    {
                        Console.WriteLine($"Teacher ID: {h.TeacherId}\nSubmission Date: {h.SubmissionDate}\nLesson: {h.Lesson}\nHomework Title: {h.HomeworkTitle}");
                    }
                }
                else Console.WriteLine($"Student with the ID: {studentHomeworkId} does not have any homeworks!");
                return true;
            }
        }

        public static bool HandleGetAllHomeworksSubmittedToATeacher()
        {
            Console.WriteLine("Please enter teacher ID to see all homeworks sent to that teacher (If you want to exit, just enter \"0\"):");
            int teacherHomeworkId = Convert.ToInt32(Console.ReadLine());
            if (teacherHomeworkId == 0) return true;
            else
            {
                List<Homework>? homeworksTeacher = homeworkService.GetAllHomeworksSubmittedToATeacher(teacherHomeworkId);
                if (homeworksTeacher != null)
                {
                    foreach (var h in homeworksTeacher)
                    {
                        Console.WriteLine($"Student ID: {h.StudentId}\nSubmission Date: {h.SubmissionDate}\nLesson: {h.Lesson}\nHomework Title: {h.HomeworkTitle}");
                    }
                }
                else Console.WriteLine($"Students did not send any homeworks to the teacher with ID: {teacherHomeworkId}.");
                return true;
            }
        }

        public static void GetAllHomeworksInTheSystem()
        {
            List<Homework>? allHomeworks = homeworkService.GetAllHomeworksInTheSystem();
            if (allHomeworks != null)
            {
                allHomeworks.ForEach(h => Console.WriteLine($"Student with the ID: {h.StudentId} sent a homework titled as {h.HomeworkTitle} to the teacher with the ID: {h.TeacherId}. The lesson was {h.Lesson} and submission date for the homework was {h.SubmissionDate}."));
            }
        }
    }
}