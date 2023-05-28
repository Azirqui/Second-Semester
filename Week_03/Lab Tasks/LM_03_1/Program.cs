using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using LM_03_1.BL;

namespace LM_03_1
{
    internal class Program
    {
        /*Task: Write a program that creates a new class of students and try printing the values of
                attributes without assigning them any values.*/


        //static void Main(string[] args)
        //{
        //    Student s1 = new Student();
        //    Console.WriteLine(s1.sname);
        //    Console.WriteLine(s1.matricMarks);
        //    Console.WriteLine(s1.fscMarks);
        //    Console.WriteLine(s1.ecatMarks);
        //    Console.WriteLine(s1.aggregate);
        //    Console.ReadKey();
        //}


        /*Task: Write the code to create a default constructor that prints “Default Constructor
                Called”.*/

        //static void Main(string[] args)
        //{
        //    Student s1 = new Student();
        //    Console.ReadKey();
        //}

        /*Task: Write the code to create a default constructor that assigns a default value to one of
                the attributes.*/

        static void Main(string[] args)
        {
            Student s1 = new Student();
            Console.Write(s1.sname);
            Console.Read();
        }
    }
}
