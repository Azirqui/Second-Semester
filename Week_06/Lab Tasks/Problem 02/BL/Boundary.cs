using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_02.BL
{
    internal class Boundary
    {
        public Point TopLeft;
        public Point TopRight;
        public Point BottomLeft;
        public Point BottomRight;
        public Boundary()
        {
            this.TopLeft = new Point(0,0);
            this.TopRight = new Point(0,90);
            this.BottomLeft = new Point(90,0);
            this.BottomRight = new Point(90, 90);           
        }
        public Boundary(Point topLeft, Point topRight, Point bottomLeft, Point bottomRight)
        {
            TopLeft = topLeft;
            TopRight = topRight;
            BottomLeft = bottomLeft;
            BottomRight = bottomRight;
        }
        public Point getTopLeft()
        {
            return this.TopLeft;
        }
        public Point getBottomLeft()
        {
            return this.BottomLeft;
        }
        public Point getTopRight()
        {
            return this.TopRight;
        }
        public Point getBottomRight()
        {
            return this.BottomRight;
        }
    }
}
