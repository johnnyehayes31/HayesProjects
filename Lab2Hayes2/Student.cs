using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Hayes2
{
    public class Student
    {
        public string name { get; set; }
        public Dictionary<string, Assignment> assignmentsDictionary { get; set; }

        public Student(string studentName)
        {
            name = studentName.ToUpper(); // constructor example
            assignmentsDictionary = new Dictionary<string, Assignment>();
        }

        public static void StudentDetailsMenu(string currentClassRoom, string currentStudent)
        {

            Console.Clear();
            Console.WriteLine(" 1. Add Assignment");
            Console.WriteLine(" 2. Show Assignments");
            Console.WriteLine(" 3. Grade Assigment");
            Console.WriteLine(" 4. Remove Assigments ");
            Console.WriteLine(" 5. Show Average Grade");
            Console.WriteLine(" 6. Show Best Grade in Class");
            Console.WriteLine(" 7. Show Worst Grade");
            Console.WriteLine(" 8. Return to Last Menu");
            Console.WriteLine(" 9.Classroom Summary");
            Console.WriteLine("0. Main Menu");

            string menuChoice = Console.ReadLine();
            if (menuChoice == "1" || menuChoice == "2" || menuChoice == "3" || menuChoice == "4" || menuChoice == "5" || menuChoice == "6" || menuChoice == "7" || menuChoice == "8" || menuChoice == "0")
            {

                switch (menuChoice)
                {
                    case "1":
                        AddAssignment(currentClassRoom, currentStudent);
                        {
                            break;
                        }
                    case "2":
                        ShowAssignments(currentClassRoom, currentStudent);
                        {
                            break;
                        }
                    case "3":
                        GradeAssignmentsSubMenu(currentClassRoom, currentStudent);

                        {
                            break;
                        }
                    case "4":
                        RemoveAssignment(currentClassRoom, currentStudent);
                        {
                            break;
                        }
                    case "5":
                       // AverageMethod(currentClassRoom, currentStudent);
                        {
                            break;
                        }
                    case "6":
                        //ShowBestGrade(); 
                        {
                            break;

                        }
                    case "7":
                        //ShowWorstClass();
                        {
                            break;
                        }
                    case "8":
                        Classroom.ClassroomDetailsMenu(currentClassRoom);

                        {
                            break;
                        }

                    case "0":
                        MainMenu.Menu();
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
                StudentDetailsMenu(currentClassRoom, currentStudent);
            }
        }

        public static void AddAssignment(string currentClassRoom, string currentStudent)
        {

            Classroom currentClassRoomObject = MainMenu.classRoomDictionary[currentClassRoom];

            Student currentStudentObject = currentClassRoomObject.studentDictionary[currentStudent];
            Console.Clear();
            Console.WriteLine(currentClassRoomObject.name);
            Console.WriteLine(currentStudentObject.name);
            Console.WriteLine(@"Add Assigment");
            Console.WriteLine("Enter Assignment Name:");
            // string name = Console.ReadLine();
            string assignmentToAdd = Console.ReadLine();
            if (assignmentToAdd != null)
            {
            currentStudentObject.assignmentsDictionary.Add(assignmentToAdd, new Assignment(assignmentToAdd));
                Console.WriteLine(assignmentToAdd);
                Console.WriteLine(@"Press Enter to move forwward");
                Console.ReadLine();
                StudentDetailsMenu(currentClassRoom, currentStudent);
            }
            else
            {
                Console.WriteLine(@"Nothing was entered to file");
                Console.ReadLine();
                StudentDetailsMenu(currentClassRoom, currentStudent);

            }


        }
        public static void ShowAssignments(string currentClassRoom, string currentStudent)
        {
            Classroom currentClassRoomObject = MainMenu.classRoomDictionary[currentClassRoom];
            Student currentStudentObject = currentClassRoomObject.studentDictionary[currentStudent];

            Console.Clear();
            Console.WriteLine(@"Logged Assignments");
            foreach (KeyValuePair<string, Assignment> kvp in currentStudentObject.assignmentsDictionary)
            {
                
                Console.WriteLine($"Assignment Name:" + kvp.Key);
                Console.WriteLine($"Assignment Grade: " + kvp.Value.Grade);
                Console.WriteLine($"Completed?" + kvp.Value.IsComplete);
            }
            Console.WriteLine(" Please Press Enter to Continue");
            Console.ReadLine();

            StudentDetailsMenu(currentClassRoom, currentStudent);

        }
        public static void GradeAssignmentsSubMenu(string currentClassRoom, string currentStudent)
        {
            Classroom currentClassRoomObject = MainMenu.classRoomDictionary[currentClassRoom];
            Student currentStudentObject = currentClassRoomObject.studentDictionary[currentStudent];
            Console.Clear();
            Console.WriteLine(@"Grade Assigments Menu");

            foreach (KeyValuePair<string, Assignment> kvp in currentStudentObject.assignmentsDictionary)
            {
                Console.WriteLine($@" Assigment: " + kvp.Key);
                Console.WriteLine($"Completed?" + kvp.Value.IsComplete);

            }
            Console.WriteLine(@"Pick an Assignment to grade ");
            string currentAssignment = Console.ReadLine();
            if (currentAssignment != null && currentStudentObject.assignmentsDictionary.ContainsKey(currentAssignment)) 
            {
                GradeAssignments(currentClassRoom, currentStudent, currentAssignment);

            }
            else
            {
                Console.WriteLine($@" Failed input try again");
                Console.WriteLine(@"Press Enter to continue");
                Console.ReadLine();
                GradeAssignmentsSubMenu(currentClassRoom, currentStudent);

            }

        }

        public static void GradeAssignments(string currentClassRoom, string currentStudent, string currentAssignment)
        {
            //string currentStudent = Console.ReadLine().ToUpper();
            Classroom currentClassRoomObject = MainMenu.classRoomDictionary[currentClassRoom];
            Student currentStudentObject = currentClassRoomObject.studentDictionary[currentStudent];
            Assignment currentAssignmentsObject = currentStudentObject.assignmentsDictionary[currentAssignment];
           
            Console.Clear();
            Console.WriteLine(@"Enter Grade for Assignment");
            double assignmentGrade = double.Parse(Console.ReadLine());
            if(assignmentGrade > 0)
            {
            currentAssignmentsObject.Grade = assignmentGrade;

            if(assignmentGrade > 0)
            {
                currentAssignmentsObject.IsComplete = true; 

            }
            else
            {
                currentAssignmentsObject.IsComplete = false;
                Console.WriteLine(@"Assignment is not turned in");
                 StudentReturn(currentClassRoom, currentStudent);
            }
            }
            StudentDetailsMenu(currentClassRoom, currentStudent);

        }
        public static void RemoveAssignment(string currentClassRoom, string currentStudent)
        {   
            
            
                Classroom currentClassRoomObject = MainMenu.classRoomDictionary[currentClassRoom];
                Student currentStudentObject = currentClassRoomObject.studentDictionary[currentStudent];
                Console.Clear();

                Console.WriteLine(@"Remove Assigment Menu");
            if( currentStudentObject.assignmentsDictionary.Count > 0)
            {

                foreach (KeyValuePair<string, Assignment> kvp in currentStudentObject.assignmentsDictionary)
                {
                    Console.WriteLine($@" Assigment: " + kvp.Key);

                }
                Console.WriteLine(@"Pick an Assignment to remove ");
                string assignmentToRemove = Console.ReadLine();
                if (assignmentToRemove != null && currentStudentObject.assignmentsDictionary.ContainsKey(assignmentToRemove))
                {
                    currentStudentObject.assignmentsDictionary.Remove(assignmentToRemove);
                    StudentDetailsMenu(currentClassRoom, currentStudent);

                }
                else
                {
                    StudentReturn( currentClassRoom, currentStudent);

                }
            }
            else
            {
                Console.WriteLine(@"There are Assignments at this time");
                Console.WriteLine(@"Press Enter to Continue");
                Console.ReadLine();
                StudentDetailsMenu(currentClassRoom, currentStudent);
            }

        }
            public static void StudentReturn(string currentClassRoom, string currentStudent)
            {
            Console.WriteLine($@" Failed input try again");
            Console.WriteLine(@"Press Enter to continue");
            Console.ReadLine();

             StudentDetailsMenu(currentClassRoom, currentStudent);
            }


    }


}

