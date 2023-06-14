using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_No_03.BL
{
    internal class Dog: Mammal
    {
        public Dog(string name) : base(name) { }
        public override void greets()
        {
            Console.WriteLine("Woof");
        }
        public override string toString()
        {
            return ("Dog: Dog[Mammal[Animal[ " + name + "]");
        }
    }
}
