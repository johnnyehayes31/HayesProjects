using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Hayes2
{
    public class Student
    {
        public string name { get; set; }
        public Dictionary<string, Student> studentDictionary { get; }

        public Student(string studentName)
        {
            name = studentName.ToUpper(); // constructor example
        }



        public static void EditStudentDetailMenu()
        {
            Console.Clear();
            Console.WriteLine(" 1. Add Student");
            Console.WriteLine(" 2. Show Student");
            Console.WriteLine(" 3. Edit Grade");
            Console.WriteLine(" 4. Remove Grades ");
            Console.WriteLine(" 5. Show Average Grade");
            Console.WriteLine(" 6. Show Best Grade in Class");
            Console.WriteLine(" 7. Show Worst Grade");

        }


    }
}
