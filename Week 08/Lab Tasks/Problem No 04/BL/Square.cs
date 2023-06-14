using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_No_04.BL
{
    internal class Square : Shape
    {
        private double side;
        public Square(double side) 
        {
            this.side = side;
        }
        public override string toString()
        {
            return ("Area of Square is: " + getArea());
        }
        public override double getArea()
        {
            return (Math.Pow(side,2));
        }

    }
}
