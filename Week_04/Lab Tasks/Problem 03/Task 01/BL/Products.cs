using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_03.BL
{
    internal class Products
    {
        /*-------------- Data Members --------------*/
        public string name;
        public string category;
        public int price;

        /*-------------- Parameterized Constructor --------------*/
        public Products(string name,string category,int price)
        {
             this.name= name;
             this.category= category;
             this.price= price;
        }
        /*-------------- Calculate Tax Function --------------*/
        public float calculateTax()
        {
            return 0.0F;
        }
    }
}
