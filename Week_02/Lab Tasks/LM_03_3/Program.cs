using LM_03_3.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM_03_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            s1.sname = "Jack";
            Student s2 = new Student(s1);
            Console.WriteLine(s1.sname);
            Console.WriteLine(s2.sname);
            Console.ReadKey();
        }
    }
}
