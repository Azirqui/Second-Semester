using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_01.BL
{
    internal class Ship
    {
        /*------------------ Data Members ----------------*/
        public string shipNumber;
        public Angle latitude;
        public Angle longitude;
        /*------------------ Parameterized Constructor ----------------*/
        public Ship(string shipNumber, Angle latitude, Angle longitude)
        {
            this.shipNumber = shipNumber;
            this.latitude = latitude;
            this.longitude = longitude;
        }
       
    }
}
