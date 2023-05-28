using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LM_03_2_SAT1_b_.BL;

namespace LM_03_2_SAT1_b_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Student 1's Name: ");
            string name1 = Console.ReadLine();
            Console.WriteLine("Enter Student 1's Matric Marks: ");
            float matricMarks1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student 1's Fsc Marks: ");
            float fscMarks1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student 1's Ecat Marks: ");
            float ecatMarks1 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student 1's Aggregate: ");
            float aggregate1 = float.Parse(Console.ReadLine());
            // Creating Object and Passing Parameters
            Student s1 = new Student(name1, matricMarks1, fscMarks1, ecatMarks1, aggregate1);
            Console.Clear();

            Console.WriteLine("Enter Student 2's Name: ");
            string name2 = Console.ReadLine();
            Console.WriteLine("Enter Student 2's Matric Marks: ");
            float matricMarks2 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student 2's Fsc Marks: ");
            float fscMarks2 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student 2's Ecat Marks: ");
            float ecatMarks2 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student 2's Aggregate: ");
            float aggregate2 = float.Parse(Console.ReadLine());
            Student s2 = new Student(name2, matricMarks2, fscMarks2, ecatMarks2, aggregate2);
            Console.Clear();


            Console.WriteLine("Enter Student 3's Name: ");
            string name3 = Console.ReadLine();
            Console.WriteLine("Enter Student 3's Matric Marks: ");
            float matricMarks3 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student 3's Fsc Marks: ");
            float fscMarks3 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student 3's Ecat Marks: ");
            float ecatMarks3 = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student 3's Aggregate: ");
            float aggregate3 = float.Parse(Console.ReadLine());
            Student s3 = new Student(name3, matricMarks3, fscMarks3, ecatMarks3, aggregate3);
            Console.Clear();


            // Printing Values On the Console
            Console.Clear();
            Console.WriteLine("Name: " + s1.sname);
            Console.WriteLine("Matric Marks: " + s1.matricMarks);
            Console.WriteLine("Fsc Marks: " + s1.fscMarks);
            Console.WriteLine("Ecat Marks: " + s1.ecatMarks);
            Console.WriteLine("Aggregate: " + s1.aggregate);

            Console.WriteLine();
            Console.WriteLine("Name: " + s2.sname);
            Console.WriteLine("Matric Marks: " + s2.matricMarks);
            Console.WriteLine("Fsc Marks: " + s2.fscMarks);
            Console.WriteLine("Ecat Marks: " + s2.ecatMarks);
            Console.WriteLine("Aggregate: " + s2.aggregate);

            Console.WriteLine();
            Console.WriteLine("Name: " + s3.sname);
            Console.WriteLine("Matric Marks: " + s3.matricMarks);
            Console.WriteLine("Fsc Marks: " + s3.fscMarks);
            Console.WriteLine("Ecat Marks: " + s3.ecatMarks);
            Console.WriteLine("Aggregate: " + s3.aggregate);
            Console.ReadKey();
        }
    }
}
