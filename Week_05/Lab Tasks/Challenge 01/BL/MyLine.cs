using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01.BL
{
    internal class MyLine
    {
        MyPoint begin;
        MyPoint end;
        public MyLine(MyPoint begin, MyPoint end)
        {
            this.begin = begin;
            this.end = end;
        }
        public MyPoint getBegin()
        {
            return begin;
        }
        public void setBegin(MyPoint begin)
        {
            this.begin = begin;
        }
        public MyPoint getEnd()
        {
            return end;
        }
        public void setEnd(MyPoint end)
        {
            this.end = end;
        }
        public double getLength()
        {
            double length;
            length = Math.Sqrt(Math.Pow((begin.x - end.x), 2) + Math.Pow((begin.y - end.y), 2));
            return length;
        }
        public double getGradient()
        {
            double slope;
            slope = (end.y - begin.y)/ (end.x - begin.x);
            return slope;
        }
    }
}
