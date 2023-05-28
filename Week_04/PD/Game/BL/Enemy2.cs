using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL
{   
    internal class Enemy2
    {
        public int bullet2X;
        public int bullet2Y;
        public int health;
        public Enemy2()
        {
            health = 100;
        }
        public void Decrease_Health()
        {
            this.health--;
        }
    }
}
