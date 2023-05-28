using LM_03_1_SAT1_a_.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM_03_1_SAT1_a_
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
            Console.ReadKey();
        }

    }
}
