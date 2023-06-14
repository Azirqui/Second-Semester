using Problem_No_02.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem_No_02.DL;

namespace Problem_No_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student("Ali","Lahore","CS",2022,70000);
            Student s2 = new Student("Ahmad", "Sarghodha", "CE", 2021, 50000);
            Staff sf1 = new Staff("Akmal","Lahore","Alnoor",30000);
            Staff sf2 = new Staff("Ashraf", "Sarghodha", "CityCadet", 40000);
            PersonDL.person.Add(s1);
            PersonDL.person.Add(s2);
            PersonDL.person.Add(sf1);
            PersonDL.person.Add(sf2);

            foreach (Person  p in PersonDL.person)
            {
                Console.WriteLine(p.toString());
            }
         
            Console.ReadKey();
        }
    }
}
