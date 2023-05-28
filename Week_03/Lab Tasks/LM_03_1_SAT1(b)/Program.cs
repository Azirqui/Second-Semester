using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LM_03_1_SAT1_b_.BL;

namespace LM_03_1_SAT1_b_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            Console.WriteLine(s1.sname);
            Console.WriteLine(s1.matricMarks);
            Console.WriteLine(s1.fscMarks);
            Console.WriteLine(s1.ecatMarks);
            Console.WriteLine(s1.aggregate);
            Console.WriteLine();

            Student s2 = new Student();
            Console.WriteLine(s2.sname);
            Console.WriteLine(s2.matricMarks);
            Console.WriteLine(s2.fscMarks);
            Console.WriteLine(s2.ecatMarks);
            Console.WriteLine(s2.aggregate);
            Console.WriteLine();

            Student s3 = new Student();
            Console.WriteLine(s3.sname);
            Console.WriteLine(s3.matricMarks);
            Console.WriteLine(s3.fscMarks);
            Console.WriteLine(s3.ecatMarks);
            Console.WriteLine(s3.aggregate);
            Console.ReadKey();

        }
    }
}
