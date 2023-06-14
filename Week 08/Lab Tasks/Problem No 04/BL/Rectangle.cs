using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_No_04.BL
{
    internal class Rectangle : Shape
    {
        private double width;
        private double height;
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public override string toString()
        {
            return ("Area of Rectangle is: " + getArea());
        }
        public override double getArea()
        {
            return (width * height);
        }
    }
}
