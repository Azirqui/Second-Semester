using Problem_No_03.BL;
using Problem_No_03.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_No_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cat c1 = new Cat("Cat1");
            Cat c2 = new Cat("Cat2");
            Dog d1 = new Dog("Dog1");
            Dog d2 = new Dog("Dog2");

            AnimalDL.animal.Add(d1);
            AnimalDL.animal.Add(d2);
            AnimalDL.animal.Add(c1);
            AnimalDL.animal.Add(c2);

            foreach (Animal a in AnimalDL.animal)
            {
                a.greets();
                Console.WriteLine(a.toString());
            }
            Console.ReadKey();
        }
    }
}
