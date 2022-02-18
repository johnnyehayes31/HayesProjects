using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Hayes2
{
    public class Classroom
    {

        public string name { get; set; } // Property example
        public Dictionary<string, Student> Student { get; }

        public Dictionary<string, Student> studentDictionary { get;}


        public Classroom(string classRoomName)
        {
            name = classRoomName.ToUpper();// constructor example
            studentDictionary = new Dictionary<string, Student>();

        }

        public static void ClassroomDetailsMenu(string currentClassRoom)
        {


            Console.Clear();
            Console.WriteLine(" 1. Add Student");
            Console.WriteLine(" 2. Show Student");
            Console.WriteLine(" 3. Remove Student");
            Console.WriteLine(" 4. Student Details Menu ");
            Console.WriteLine(" 5. Show Class Average");
            Console.WriteLine(" 6. Show Best Student");
            Console.WriteLine(" 7. Show Worst Student");
            Console.WriteLine(" 0. Return to Last Menu");

            Console.WriteLine(currentClassRoom);// Delete this last

            string menuChoice = Console.ReadLine();

            if (menuChoice == "1" || menuChoice == "2" || menuChoice == "3" || menuChoice == "4" || menuChoice == "5" || menuChoice == "6" || menuChoice == "7" || menuChoice == "0")
            {

                switch (menuChoice)
                {
                    case "1":
                        AddStudent(currentClassRoom);
                        {
                            break;
                        }
                    case "2":
                        ShowStudents(currentClassRoom);
                        {
                            break;
                        }
                    case "3":
                        {
                            break;
                        }
                    case "4":
                        {
                            break;
                        }
                    case "5":

                        {
                            break;
                        }
                    case "6":

                        {
                            break;

                        }
                    case "7":
                        {
                            break;
                        }
                    case "0":
                        {
                            break;
                        }

                    default:
                        {
                            break;
                        }


                }

            }
            else
            {
                ClassroomDetailsMenu(currentClassRoom);
            }
        }

        public static void AddStudent(string currentClassRoom)
        {
            Console.Clear();
            Console.WriteLine(@"Student Manager");
            Console.WriteLine(@" Add Student:");
            string studentToAdd = Console.ReadLine();
            Student newStudentObject = new Student(studentToAdd);
            Classroom currentClassRoomObject = MainMenu.classRoomDictionary[currentClassRoom];// instance of Classroom object
            currentClassRoomObject.studentDictionary.Add(newStudentObject.name, newStudentObject);
            
            ClassroomDetailsMenu(currentClassRoom);

        }
        public static void ShowStudents(string currentClassRoom)
        {
            Classroom currentClassRoomObject = MainMenu.classRoomDictionary[currentClassRoom];// instance of Classroom object
            Console.Clear();
            Console.WriteLine(@"Display Student");

            foreach (KeyValuePair<string, Student> kvp in currentClassRoomObject.studentDictionary)
            {
                Console.WriteLine($"Student Name:" + kvp.Value.name);

            }

            Console.ReadLine();



        }

    }
}
