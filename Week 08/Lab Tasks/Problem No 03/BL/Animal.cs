using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_No_03.BL
{
    internal class Animal
    {
        protected string name;
        public Animal(string name) 
        {
            this.name = name;
        }
        public virtual string toString()
        {
            return ("Animal: Animal[ " +name + "]");
        }
        public virtual void greets()
        {
        }
    }
}
