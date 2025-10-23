using System.Diagnostics.CodeAnalysis;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager1 = new();
            string? input;
            do
            {
                Console.WriteLine("     ╔══════════════ Student Manager ═════════════════════╗");
                Console.WriteLine("     ║ 1  - Add Student                                   ║");
                Console.WriteLine("     ║ 2  - Add Instructor                                ║");
                Console.WriteLine("     ║ 3  - Add Course                                    ║");
                Console.WriteLine("     ║ 4  - Enroll Student in Course                      ║");
                Console.WriteLine("     ║ 5  - Show All Students                             ║");
                Console.WriteLine("     ║ 6  - Show All Courses                              ║");
                Console.WriteLine("     ║ 7  - Show All Instructors                          ║");
                Console.WriteLine("     ║ 8  - Find Student by Id                            ║");
                Console.WriteLine("     ║ 9  - Find Student by Name                          ║");
                Console.WriteLine("     ║ 10 - Find Course by Id                             ║");
                Console.WriteLine("     ║ 11 - Find Course by Name                           ║");
                Console.WriteLine("     ║ 12 - Check if Student enrolled in specific course  ║");
                Console.WriteLine("     ║ 13 - Return the instructor name by course name     ║");
                Console.WriteLine("     ║ 14 - Delete a student                              ║");
                Console.WriteLine("     ║ 15 - Exit                                          ║");
                Console.WriteLine("     ╚════════════════════════════════════════════════════╝");

                Console.Write("==> ");
                input = Console.ReadLine();

                switch (input)
                {
                    //Add student
                    case "1":
                        int age = 0;
                        string? nameStd = AddString("Student Name");
                        if (nameStd != null)
                            age = AddNum("Student Age");
                        if (manager1.AddStudent(nameStd, age))
                        {
                            Console.WriteLine("╔═════════════════════════════════════");
                            Console.WriteLine("  new Student is added          ");
                            Console.WriteLine($" {manager1.Students[manager1.Students.Count - 1].PrintDetails()}");
                            Console.WriteLine("                             ═════════════════════════════════════╝");
                        }
                        else
                            Console.WriteLine(" No student is added");
                        break;
                    //Add Instructor
                    case "2":
                        string? specialization = null;
                        string? nameIns = AddString("Instructor Name");
                        if (nameIns != null)
                            specialization = AddString("Instructor Specialization");
                        if (manager1.AddInstructor(nameIns, specialization))
                        {
                            Console.WriteLine("╔═════════════════════════════════════");
                            Console.WriteLine("  new Instructor is added          ");
                            Console.WriteLine($" {manager1.Instructors[manager1.Instructors.Count - 1].PrintDetails()}");
                            Console.WriteLine("                             ═════════════════════════════════════╝");
                        }
                        else
                            Console.WriteLine(" No Instructor is added");
                        break;
                    //Add Course
                    case "3":
                        int insIdIndex = -1;
                        string? title = AddString("Course Title");
                        if (title != null)
                        {
                            insIdIndex = FindInstructor(manager1);
                            if (insIdIndex != -1)
                            {
                                if (manager1.AddCourse(title, manager1.Instructors[insIdIndex]))
                                {
                                    Console.WriteLine("╔═════════════════════════════════════");
                                    Console.WriteLine("  new Course is added          ");
                                    Console.WriteLine($" {manager1.Courses[manager1.Courses.Count - 1].PrintDetails()}");
                                    Console.WriteLine("                             ═════════════════════════════════════╝");
                                }
                            }
                            else
                                Console.WriteLine(" No Course is added");
                        }
                        else
                            Console.WriteLine(" No Course is added");
                        break;
                    //Enroll Students in course
                    case "4":
                        int cIdIndex = -1;
                        int stdIdIndex = FindStudent(manager1);
                        if (stdIdIndex != -1)
                            cIdIndex = FindCourse(manager1);
                        if (!manager1.Enroll(cIdIndex, stdIdIndex))
                            Console.WriteLine("Failed!");
                        else
                        {
                            Console.WriteLine("╔═════════════════════════════════════");
                            Console.WriteLine("  Done");
                            Console.WriteLine(manager1.Students[stdIdIndex].PrintDetails());
                            Console.WriteLine("                             ═════════════════════════════════════╝");
                        }
                        break;
                    //Show all students
                    case "5":
                        Console.WriteLine("╔═════════════════════════════════════");
                        Console.WriteLine("  List of Students:");
                        Console.WriteLine($" {manager1.GetStudents()}");
                        Console.WriteLine("                             ═════════════════════════════════════╝");
                        break;
                    //Show all courses
                    case "6":
                        Console.WriteLine("╔═════════════════════════════════════");
                        Console.WriteLine("  List of Courses:");
                        Console.WriteLine($" {manager1.GetCourses()}");
                        Console.WriteLine("                             ═════════════════════════════════════╝");
                        break;
                    //Show all instructors
                    case "7":
                        Console.WriteLine("╔═════════════════════════════════════");
                        Console.WriteLine("  List of Instructors:");
                        Console.WriteLine($" {manager1.GetInstructors()}");
                        Console.WriteLine("                             ═════════════════════════════════════╝");
                        break;
                    //Find student by id
                    case "8":
                        stdIdIndex = FindStudent(manager1);
                        if (stdIdIndex != -1)
                        {
                            Console.WriteLine("╔═════════════════════════════════════");
                            Console.WriteLine($" {manager1.Students[stdIdIndex].PrintDetails()}");
                            Console.WriteLine("                             ═════════════════════════════════════╝");
                        }
                        break;
                    //Find student by name
                    case "9":
                        stdIdIndex = FindStudentName(manager1);
                        if (stdIdIndex != -1)
                        {
                            Console.WriteLine("╔═════════════════════════════════════");
                            Console.WriteLine($" {manager1.Students[stdIdIndex].PrintDetails()}");
                            Console.WriteLine("                             ═════════════════════════════════════╝");
                        }
                        break;
                    //Find course by id
                    case "10":
                        cIdIndex = FindCourse(manager1);
                        if (cIdIndex != -1)
                        {
                            Console.WriteLine("╔═════════════════════════════════════");
                            Console.WriteLine($" {manager1.Courses[cIdIndex].PrintDetails()}");
                            Console.WriteLine("                             ═════════════════════════════════════╝");
                        }
                        break;
                    //Find course by name
                    case "11":
                        cIdIndex = FindCourseName(manager1);
                        if (cIdIndex != -1)
                        {
                            Console.WriteLine("╔═════════════════════════════════════");
                            Console.WriteLine($" {manager1.Courses[cIdIndex].PrintDetails()}");
                            Console.WriteLine("                             ═════════════════════════════════════╝");
                        }
                        break;
                    //Check if Student enrolled in specific course
                    case "12":
                        stdIdIndex = -1;
                        cIdIndex = FindCourse(manager1);
                        if (cIdIndex != -1)
                        {
                            stdIdIndex = FindStudent(manager1);
                            if (stdIdIndex != -1)
                            {
                                if (manager1.CheckIfEnroll(cIdIndex, stdIdIndex))
                                {
                                    Console.WriteLine("╔═════════════════════════════════════");
                                    Console.WriteLine("  Student is enrolled");
                                    Console.WriteLine($" {manager1.Students[stdIdIndex].PrintDetails()}");
                                    Console.WriteLine("                             ═════════════════════════════════════╝");
                                }
                                else
                                    Console.WriteLine("Student is not enrolled");
                            }
                        }
                        break;
                    //Return the instructor name by course name
                    case "13":
                        string insName;
                        cIdIndex = FindCourseName(manager1);
                        if (cIdIndex != -1)
                        {
                            insName = manager1.Courses[cIdIndex].Instructor.Name;
                            Console.WriteLine($" Instructor Name: {insName}");
                        }
                        break;
                    //Delete a Student
                    case "14":
                        stdIdIndex = FindStudent(manager1);
                        if (manager1.DeleteStudent(stdIdIndex))
                            Console.WriteLine("Student has been deleted");
                        else Console.WriteLine("failed to delete");
                        break;

                }

            } while (input != "15");
        }
        static int AddNum(string noun) //convert string to int avoiding null and letters
        {
            Console.Write($"{noun}: ");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                return result;
            }
            else
            {
                Console.Write("Invalid number! Try again (y/n)?");
                if ((Console.ReadLine() ?? "").ToUpper() == "N") return 0;
                return AddNum(noun);
            }

        }
        static string? AddString(string noun) //check for null and empty strings
        {
            Console.Write($"{noun}: ");
            string? input = Console.ReadLine();
            if (input == null || input == "")
            {
                Console.Write("Invalid! Try again(y/n)?");
                if ((Console.ReadLine() ?? "").ToUpper() == "N") return null;
                return AddString(noun);
            }
            return input;
        }
        static int FindStudent(StudentManager manager) //return index of student Id or -1 if not found
        {
            int stdIdIndex;
            string? stdId;
            Console.Write("Enter Student Id: ");
            stdId = Console.ReadLine();
            stdIdIndex = manager.FindStdId(stdId);
            if (stdIdIndex == -1)
            {
                Console.Write("Id Not Found! Try Again (y/n)?");
                if ((Console.ReadLine() ?? "").ToUpper() == "N") return -1;
                else return FindStudent(manager);
            }
            return stdIdIndex;
        }
        static int FindCourse(StudentManager manager) //return index of Course Id or -1 if not found
        {
            int cIdIndex;
            string? cId;
            Console.Write("Enter Course Id: ");
            cId = Console.ReadLine();
            cIdIndex = manager.FindCourseId(cId);
            if (cIdIndex == -1)
            {
                Console.Write("Not Found! Try Again (y/n)?");
                if ((Console.ReadLine() ?? "").ToUpper() == "N") return -1;
                else return FindCourse(manager);
            }
            return cIdIndex;
        }
        static int FindInstructor(StudentManager manager) //return index of Instructor Id or -1 if not found
        {
            int insIdIndex;
            string? insId;
            Console.Write("Instructor Id: ");
            insId = Console.ReadLine();
            insIdIndex = manager.FindInsId(insId);
            if (insIdIndex == -1)
            {
                Console.Write("Not Found! Try Again (y/n)?");
                if ((Console.ReadLine() ?? "").ToUpper() == "N") return -1;
                else return FindInstructor(manager);
            }
            return insIdIndex;
        }
        static int FindStudentName(StudentManager manager) //return index of Student Name or -1 if not found
        {
            int stdNameIndex;
            string? stdName;
            Console.Write("Enter Student Name: ");
            stdName = Console.ReadLine();
            stdNameIndex = manager.FindStdName(stdName);
            if (stdNameIndex == -1)
            {
                Console.Write("Not Found! Try Again (y/n)?");
                if ((Console.ReadLine() ?? "").ToUpper() == "N") return -1;
                else return FindStudentName(manager);
            }
            return stdNameIndex;
        }
        static int FindCourseName(StudentManager manager) //return index of Course Name or -1 if not found
        {
            int cNameIndex;
            string? cName;
            Console.Write("Enter Course Name: ");
            cName = Console.ReadLine();
            cNameIndex = manager.FindCourseName(cName);
            if (cNameIndex == -1)
            {
                Console.Write("Not Found! Try Again (y/n)?");
                if ((Console.ReadLine() ?? "").ToUpper() == "N") return -1;
                else return FindStudentName(manager);
            }
            return cNameIndex;
        }
    }

}
