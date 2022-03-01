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

        public Dictionary<string, Student> studentDictionary { get; }


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
                        RemoveStudents(currentClassRoom);
                        {
                            break;
                        }
                    case "4":
                        StudentDetailsSubMenu(currentClassRoom);
                        {
                            break;
                        }
                    case "5":
                        ShowClassAverage(currentClassRoom);
                        {
                            break;
                        }
                    case "6":
                        //Show Best Class Grade 
                        {
                            break;

                        }
                    case "7":
                        //Show Worst Class Grade
                        {
                            break;
                        }
                    case "0":
                        //Return to Last Menu
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
            string studentToAdd = Console.ReadLine().ToUpper();            
            Console.WriteLine(@" Add Student:");

            if (studentToAdd != null) 
            {
                Student newStudentObject = new Student(studentToAdd);
                Classroom currentClassRoomObject = MainMenu.classRoomDictionary[currentClassRoom]; // instance of Classroom object
                currentClassRoomObject.studentDictionary.Add(newStudentObject.name, newStudentObject);

                Console.WriteLine(currentClassRoom);
                
                ClassroomDetailsMenu(currentClassRoom);

                Console.WriteLine(currentClassRoom.ToString());
                if(studentToAdd != null && currentClassRoomObject.studentDictionary.ContainsKey(studentToAdd))
                {
                Console.WriteLine(@"Classroom is empty");
                Console.WriteLine(currentClassRoom.ToString());

                }
                else
                {
                    Console.WriteLine(@"Please Add a student");
                }
            }

            else
            {
                Student newStudentObject = new Student(currentClassRoom);
                EmptyStudentsClassroom(currentClassRoom);
            }
             
        }



        public static void ShowStudents(string currentClassRoom)
        {
            Classroom currentClassRoomObject = MainMenu.classRoomDictionary[currentClassRoom];// instance of Classroom object
            Console.Clear();
            Console.WriteLine(@"Display Student");
            if(currentClassRoom == null)
            {
            foreach (KeyValuePair<string, Student> kvp in currentClassRoomObject.studentDictionary)
            {
                Console.WriteLine($"Student Name:" + kvp.Value.name);
            }
            Console.ReadLine();
            }
            else
            {

            ClassroomDetailsMenu(currentClassRoom);

            }

        }
        public static void RemoveStudents(string currentClassRoom)
        {
            Console.Clear();
            Console.WriteLine(@"Student Manager");
            Classroom currentClassRoomObject = MainMenu.classRoomDictionary[currentClassRoom];
            // Adding If ELSE Statement to remove
            foreach (KeyValuePair<string, Student> kvp in currentClassRoomObject.studentDictionary)
            {
                Console.WriteLine($"Student Name:" + kvp.Value.name);

            }
            Console.WriteLine(@" Remove Student:");
            string studentToRemove = Console.ReadLine();
            currentClassRoomObject.studentDictionary.Remove(studentToRemove);
            Console.WriteLine("Please Enter to Remove Student");
            Console.ReadLine();
            ClassroomDetailsMenu(currentClassRoom);

        }
        public static void StudentDetailsSubMenu(string currentClassRoom)
        {

            Classroom currentClassRoomObject = MainMenu.classRoomDictionary[currentClassRoom]; // instance of Classroom object

            Console.Clear();
            if(currentClassRoom != null)
            {

                foreach (KeyValuePair<string, Student> kvp in currentClassRoomObject.studentDictionary)
                {
                Console.WriteLine($"Student Name:" + kvp.Value.name);

                }
                Console.WriteLine("Enter Student name here");
            //Console.WriteLine(" 0. Return to Last Menu");
            }
            else
                {
                    Console.WriteLine("No Student was Entered");
                }
            string currentStudent = Console.ReadLine().ToUpper();
            Student currentStudentObject = currentClassRoomObject.studentDictionary[currentStudent]; // Instance of Current Student

            Student.StudentDetailsMenu(currentClassRoom, currentStudent);

            ////Classroom.StudentDetailsSubMenu(currentClassRoom);

        }
        public static void ShowClassAverage(string currentClassRoom)

        {
            Classroom currentClassRoomObject = MainMenu.classRoomDictionary[currentClassRoom];
            string currentStudent = Console.ReadLine();
            Student currentStudentObject = currentClassRoomObject.studentDictionary[currentStudent];

            Console.Clear();
            Console.WriteLine(@"Class Average:  ");
            double classTotal = 0;
            double assignmentTotal = 0;
            if (currentClassRoom != null)
            {

            foreach (var student in currentClassRoomObject.studentDictionary)
            {
                double sum = 0;
                foreach(var assignment in currentStudentObject.assignmentsDictionary)
                {
                    sum = assignmentTotal + assignment.Value.Grade;
                }
                double studentAverage = sum/currentStudentObject.assignmentsDictionary.Count;
                classTotal += studentAverage;
               
            }
            }
            else
            {
                Console.WriteLine("No grades are entered");
                ShowClassAverage(currentClassRoom);
            }
            double classRoomAverage = classTotal / currentClassRoomObject.studentDictionary.Count;

            Console.WriteLine(classRoomAverage);

           
        }

            



        

        
        public static void EmptyStudentsClassroom(string currentClassRoom)
        {
            Console.WriteLine(@"No Students at this time.
                        Please add a Student");
            Console.ReadLine();
            ClassroomDetailsMenu(currentClassRoom);

        }
    }

}
