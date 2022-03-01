using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Hayes2
{
    public class Assignment
    {


        public string name { get; set; }


        public double Grade { get; set; } = 0;
        public bool IsComplete { get; set; } = false;

        public Assignment(string assignmentName)
        {
            name = assignmentName.ToUpper(); // constructor example
        }
    }
        
         
       
}
