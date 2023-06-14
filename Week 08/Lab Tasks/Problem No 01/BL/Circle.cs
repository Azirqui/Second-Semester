using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_No_01.BL
{
    internal class Circle
    {
        protected double radius;
        protected string color;
        public Circle()
        {
            radius = 1.0;
            color = "red";
        }
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public Circle(double radius, string color)
        {
            this.radius = radius;
            this.color = color;
        }
        public double getRadius()
        {
            return radius;
        }
        public string getColor() 
        {
            return color;
        }
        public void setRadius(double radius)
        {
            this.radius = radius;
        }
        public void setColor(string color)
        {
            this.color = color;
        }
        public double getArea()
        {
            return (Math.Pow(radius, 2) * 3.1415);
        }
        public string toString()
        {
            return ("Circle [Radius: " + radius + ", Color: " + color + "]");
        }
    }
}
