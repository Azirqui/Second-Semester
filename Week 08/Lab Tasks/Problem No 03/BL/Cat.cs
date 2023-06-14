using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_No_03.BL
{
    internal class Cat: Mammal
    {
        public Cat(string name):base(name) { }
        public override void greets()
        {
            Console.WriteLine("Meow");
        }
        public override string toString()
        {
            return ("Cat: Cat[Mammal[Animal[ " + name + "]");
        }

    }
}
