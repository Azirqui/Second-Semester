using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01.BL
{
    internal class MyPoint
    {
        public int x;
        public int y;
        public MyPoint() 
        {
            x = 0;
            y = 0;
        }

        public MyPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int getX() 
        {
            return x; 
        }
        public int getY()
        {
            return y;
        }
        public void setX(int x)
        {
            this.x = x;
        }
        public void setY(int y)
        {
            this.y=y;
        }
        public void setXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public double distanceWithCords(int x,int y)
        {
            double distance;
            distance = Math.Sqrt(Math.Pow((this.x - x), 2) + Math.Pow((this.y - y), 2));
            return distance;
        }
        public double distanceWithObject(MyPoint another)
        {
            double distance;
            distance = Math.Sqrt(Math.Pow((this.x - another.x), 2) + Math.Pow((this.y - another.y), 2));
            return distance;
        }
        public double distanceWithZero()
        {
            double distance;
            distance = Math.Sqrt(Math.Pow((this.x-0),2) + Math.Pow((this.y-0),2));
            return distance;
        }
    }
}
