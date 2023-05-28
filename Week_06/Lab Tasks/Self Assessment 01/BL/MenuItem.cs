using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Assessment_01.BL
{
    internal class MenuItem
    {
        public string name;
        public string type;
        public float price;
        public MenuItem(string name,string type,float price)
        {
            this.name = name;
            this.type = type;
            this.price = price;
        }
        public string getName()
        {
            return name;
        }
        public string getType()
        {
            return type;
        }
        public float getPrice()
        {
            return price;
        }
    }
}
