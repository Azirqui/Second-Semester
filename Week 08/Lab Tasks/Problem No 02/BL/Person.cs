using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem_No_02.DL;

namespace Problem_No_02.BL
{
    internal class Person
    {
        protected string name;
        protected string address;
        public Person(string name,string address) 
        {
            this.name = name;
            this.address = address;
        }
        public string getName()
        {
            return name;
        }
        public string getAddress()
        {
            return address;
        }
        public void setAddress(string address)
        {
            this.address = address;
        }
        public virtual string toString()
        {
            return ("Person [name: " + name + ", address: " + address + "]");
        }
    }
}
