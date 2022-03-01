using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Hayes2
{
    public class MainMenu
    {
        public static Dictionary<string, Classroom> classRoomDictionary = new Dictionary<string, Classroom>();

        public static void Menu()
        {


            Console.Clear(); // Will clear the menu doesn't repeatedly show in console window
            Console.WriteLine(
            @"****************************************************************************
            Grade Manager
            1. Add Classroom
            2. Show Classroom
            3. Remove Classroom
            4. Classroom Details Menu
            9. Exit Application
            Please Select one of the above options: ");

            string menuChoice = Console.ReadLine();
            if (menuChoice == "1" || menuChoice == "2" || menuChoice == "3" || menuChoice == "4" || menuChoice == "9")
            {

                switch (menuChoice)
                {
                    case "1":
                        AddClassroom();
                        {
                            break;
                           
                        }
                    case "2":
                        ShowClassroom();
                        {
                            break;
                        }
                    case "3":
                        RemoveClassroom();
                        {
                            break;
                        }
                    case "4":
                        ClassRoomDetailsSubMenu();
                        {
                            break;
                        }
                    case "9":
                        Environment.Exit(9);
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
                Menu();
            }
        }

        public static void AddClassroom()
        {
            

            Console.Clear();
            Console.WriteLine(@"Add Classroom");
            string userInput = Console.ReadLine();
            if(userInput != null)
            {
                classRoomDictionary.Add(userInput, new Classroom(userInput));
                Console.WriteLine(@"Press Enter to save added classroom");
                
            Menu();
            }
            else
            {
                HailMary();
            }


        }                


        public static void ShowClassroom()
        {
            Console.Clear();
            if (classRoomDictionary.Count > 0)
            {

            Console.WriteLine(@"Display Classrooms");
            foreach (KeyValuePair<string, Classroom> kvp in classRoomDictionary)
            {
                Console.WriteLine($"Classroom Name:" + kvp.Value.name);

            }
                Console.WriteLine(@"Press Enter to go back to Menu");
            Console.ReadLine();
            Menu();
            }
            else
            {
                Console.WriteLine(@"No Classrooms at this time.
                        Please add classroom");
                Console.ReadLine();
                Menu();
            }

        }

        public static void RemoveClassroom()
        {
            Console.Clear();
            if(classRoomDictionary.Count > 0)
            {
            Console.WriteLine("Please Enter a Classroom");
            foreach (KeyValuePair<string, Classroom> kvp in classRoomDictionary)
            {
                Console.WriteLine($"Classroom Name:" + kvp.Value.name);

            }
            
            string userInput = Console.ReadLine();
                if( userInput != null && classRoomDictionary.ContainsKey(userInput))
                {
                    classRoomDictionary.Remove(userInput);
                    Console.WriteLine("Please Press Enter NOW");
                    Console.ReadLine();
                    Menu();
                    
                }
                else
                {
                    HailMary();
                }
            }
            else
            {
                EmptyClassroomDictionary();

            }
            


        }

        public static void ClassRoomDetailsSubMenu()
        {
            Console.Clear();
            if(classRoomDictionary != null)
            {
                foreach (KeyValuePair<string, Classroom> kvp in classRoomDictionary)
                {
                    Console.WriteLine($"Classroom Name:" + kvp.Value.name);

                }
                Console.WriteLine("Enter Class name here");
                string userInput = Console.ReadLine().ToUpper();

                if(userInput != null && classRoomDictionary.ContainsKey(userInput))
                {
                    Classroom.ClassroomDetailsMenu(userInput);
                    
                }
                else
                {
                    HailMary();
                }

            }
            else
            {
                EmptyClassroomDictionary();
            }

        }

     public static void HailMary()
        {
            Console.WriteLine(@"UserInput failed Press Enter");
            Console.ReadLine();
            Menu();

        }
        public static void EmptyClassroomDictionary()
        {
             Menu();

        }



    }
}
