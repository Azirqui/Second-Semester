using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_01.BL
{
    internal class Angle
    {
        /*------------------ Data Members ----------------*/
        public int degrees;
        public float minutes;
        public char direction;
        /*------------------ Parameterized Constructor ----------------*/
        public Angle(int degrees, float minutes, char direction)
        {
            this.degrees = degrees;
            this.minutes = minutes;
            this.direction = direction;
        }
        /*------------------ Print Angle Function ----------------*/
        public void print_angle()
        {
            Console.Write(degrees + "\u00b0" + minutes + "'" + direction);
        }
    }
}
