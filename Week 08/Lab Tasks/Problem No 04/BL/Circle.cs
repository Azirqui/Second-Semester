using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_No_04.BL
{
    internal class Circle: Shape
    {
        private double radius;
        public Circle(double radius)
        { 
            this.radius = radius; 
        }
        public override string toString()
        {
            return ("Area of Circle is: " + getArea());
        }
        public override double getArea()
        {
            return (Math.Pow(radius, 2) * 3.1416);
        }

    }
}
