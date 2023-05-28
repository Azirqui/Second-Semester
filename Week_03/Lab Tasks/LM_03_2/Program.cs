using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LM_03_2.BL;

namespace LM_03_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student("John");
            Console.WriteLine(s1.sname);
            Student s2 = new Student("Jack");
            Console.WriteLine(s2.sname);
            Console.ReadKey();
        }
    }
}
