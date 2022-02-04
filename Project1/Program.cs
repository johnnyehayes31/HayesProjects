using System;
using System.Collections.Generic;

namespace LAB1
{ 
    internal class GradingSystemProgram
    {

        public static void Main(string[] args)
        {
            List<double> classGrades = new List<double>();

            Menu();

            void Menu()
            {
                Console.Clear(); // Will clear the menu doesn't repeatedly show in console window
                Console.WriteLine(" Grade Manager: \n");
                Console.WriteLine(" 1. Add Grade");
                Console.WriteLine(" 2. Show Grades");
                Console.WriteLine(" 3. Edit Grade");
                Console.WriteLine(" 4. Remove Grades ");
                Console.WriteLine(" 5. Show Average Grade");
                Console.WriteLine(" 6. Show Best Grade in Class");
                Console.WriteLine(" 7. Show Worst Grade");
                Console.WriteLine(" 8. Exit Application \n");
                Console.WriteLine(" Please Select one of the above options: ");

                string Choice = Console.ReadLine();

                if (Choice == "1" || Choice == "2" || Choice == "3" || Choice == "4" || Choice == "5" || Choice == "6" || Choice == "7" || Choice == "8")
                { 

                
                    switch (Choice)
                    {
                        case "1":
                            AddGradeMenu();
                            break;

                        case "2":
                            ShowGrade();
                            break;

                        case "3":
                            ModifyGrade();
                            break;

                        case "4":
                            RemoveGrade();
                            break;

                        case "5":
                            ShowAverageGrade();
                            break;

                        case "6":
                            BestGrade();
                            break;

                        case "7":
                            //ShowWorstGrade();
                            break;

                        case "8":
                            //
                            break;

                        default:
                            break;
                    }
                    
                }
                else
                {
                    Menu();
                }


                void AddGradeMenu()
                {
                    Console.Clear(); // Will clear the menu doesn't repeatedly show in console window
                    Console.WriteLine(" Grade Manager:");
                    Console.WriteLine(" 1. Add Grade");
                    Console.WriteLine(" 2. Main Menu");

                    string Choice1 = Console.ReadLine();
                    
                    switch (Choice1)
                    {
                        case "1":
                            AddGrade();
                            break;

                        case "2":
                            Menu();
                            break;

                        default:
                            break;
                    }
                }
                void AddGrade()
                {
                    Console.Clear();
                    Console.WriteLine("enter grade from 1 to 100");
                    Console.WriteLine("No more than two decimal points");
                    var  userInput = Console.ReadLine();
                    double grade = 0;
                    if (double.TryParse(userInput, out grade))
                    {
                   // double grade = Convert.ToDouble(userInput);
                    classGrades.Add(grade);
                    AddGradeMenu();

                    }
                    else
                    {
                        Menu();
                    }

                }
                void ShowGrade()
                {
                    Console.Clear();
                    Console.WriteLine("Press enter to continue");

                    for (int i = 0; i < classGrades.Count; i++)
                    {
                        Console.WriteLine(classGrades[i]);
                    }
                    Console.ReadLine();
                    Menu();
                }

                void ModifyGrade()
                    {
                    Console.Clear();

                for (int i = 0; i < classGrades.Count; i++)
                {
                        string Student = i.ToString();
                        Console.WriteLine(Student +". "+ classGrades[i]);
                }
                Console.WriteLine("Select Grade");
                int choice4 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("New Grade");
                int Adjustedgrade = Convert.ToInt32(Console.ReadLine());
                classGrades[choice4] = Adjustedgrade;

                    Menu();
                }

                void RemoveGrade()

                    {
                        Console.Clear();
                        Console.WriteLine("Select Grade for Removal");
                    
                        for (int i = 0; i < classGrades.Count; i++)
                        {
                            string Student = i.ToString();
                            Console.WriteLine(Student + ". " + classGrades[i]);
                        }

                    var userInput = Console.ReadLine();
                    int choice5 = 0; 
                    if (Int32.TryParse(userInput, out choice5))
                    {
                    classGrades.RemoveAt(choice5);
                    ShowGrade();

                    }
                    else
                    {
                        Menu(); 
                    }
                    

                }
                
                 void ShowAverageGrade()
                {
                    double sum = 0;
                    for (int i = 0;i < classGrades.Count; i++)
                    {
                        sum +=  classGrades[i];
                        
                    }
                    sum /= classGrades.Count;
                    Console.WriteLine("Classroom Average");
                    if (classGrades.Count == 0)
                    {
                        Console.WriteLine("No grades are entered.");
                        Console.WriteLine("Please enter grades.");
                    }
                    else
                    {

                        Console.WriteLine("Please enter grades.");

                    }
                        
                    Console.WriteLine(sum);
                    Console.ReadLine();

                    Menu();
                }

                void BestGrade()
                {
                    Console.Clear();
                    if (classGrades.Count > 0)
                    {
                        double max = 0;
                        for (int i = 0; i < classGrades.Count; i++)
                        {
                            if (classGrades[i] > max)
                            {
                                max = classGrades[i];
                            }
                        }

                        Console.WriteLine($"Best Grade: {max}");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();

                        Menu();
                    }
                    else
                    {

                        Console.WriteLine("No grades entered.");
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();

                        Menu();


                    }
                }

                //void ShowWorstGrade()
                //{
                //    Console.Clear();

                //    if (classGrades.Count > 0)
                //    {
                //        double min = double.MaxValue;
                //        foreach (double classGrades in classGrades)
                //        {
                //            min = Math.Min(classGrades, min);

                //        }
                //        Console.WriteLine($"Worst Grade: {min}");
                //Console.WriteLine("Press Enter to Continue");
                //Console.ReadLine();

                //        Menu();
                //    }



            }



            
        }
    }
}
//c => c.Number == someTextBox.Text
//var index = classGrades.FindIndex(c => choice4 == choice4.);
//list[index] = new SomeClass(...);