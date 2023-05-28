using LM_03_2_SAT1_a_.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM_03_2_SAT1_a_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Student's Name: ");
            string name=Console.ReadLine();
            Console.WriteLine("Enter Student's Matric Marks: ");
            float matricMarks = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student's Fsc Marks: ");
            float fscMarks  = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student's Ecat Marks: ");
            float ecatMarks = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student's Aggregate: ");
            float aggregate = float.Parse(Console.ReadLine());
            // Creating Object and Passing Parameters
            Student s1 = new Student(name,matricMarks,fscMarks,ecatMarks,aggregate);
            // Printing Values On the Console
            Console.Clear();
            Console.WriteLine("Name: "+s1.sname);
            Console.WriteLine("Matric Marks: "+s1.matricMarks);
            Console.WriteLine("Fsc Marks: "+s1.fscMarks);
            Console.WriteLine("Ecat Marks: "+s1.ecatMarks);
            Console.WriteLine("Aggregate: "+s1.aggregate);
            Console.ReadKey();
            
        }
    }
}
