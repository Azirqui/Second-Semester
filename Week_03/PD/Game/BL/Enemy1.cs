using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL
{
    internal class Enemy1
    {
        public int bullet1X;
        public int bullet1Y;
        public int health;

        public Enemy1()
        {
            health = 100;
        }
        public void Decrease_Health()
        {
            this.health--;
        }
    }
}
