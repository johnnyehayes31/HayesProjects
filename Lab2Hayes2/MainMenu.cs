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
                classRoomDictionary.Add(userInput, new Classroom(userInput));
                Menu();
            }

        public static void ShowClassroom()
        {
            Console.Clear();
            Console.WriteLine(@"Display Classroom");
            foreach (KeyValuePair<string, Classroom> kvp in classRoomDictionary)
            {
                Console.WriteLine($"Classroom Name:" + kvp.Value.name);

            }
            Console.ReadLine();

            Menu();
        }

        public static void RemoveClassroom()
        {
            Console.Clear();
            Console.WriteLine("Please Enter a Classroom");

            foreach (KeyValuePair<string, Classroom> kvp in classRoomDictionary)
            {
                Console.WriteLine($"Classroom Name:" + kvp.Value.name);

            }
            string userInput = Console.ReadLine();
            classRoomDictionary.Remove(userInput);
            Console.WriteLine("Please Press Enter NOW");
            Console.ReadLine();
            Menu();


        }

        public static void ClassRoomDetailsSubMenu()
        {
            Console.Clear();
            foreach (KeyValuePair<string, Classroom> kvp in classRoomDictionary)
            {
                Console.WriteLine($"Classroom Name:" + kvp.Value.name);

            }
            Console.WriteLine("Enter Class name here");
            //Console.WriteLine(" 0. Return to Last Menu");

            string userInput = Console.ReadLine().ToUpper();
            
           Classroom.ClassroomDetailsMenu(userInput);
        }


    }
}
