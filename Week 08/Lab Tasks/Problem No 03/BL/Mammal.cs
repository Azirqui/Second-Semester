using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_No_03.BL
{
    internal class Mammal: Animal
    {
        public Mammal(string name): base(name) { }
        public override string toString()
        {
            return ("Mammal: Mammal[Animal[ " + name + "]");
        }
        public override void greets()
        {
        }
    }
}
