using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL
{
    internal class Player
    {
        public int health;

        public Player()
        {
            health = 100;
        }
        public void DecreaseHealth()
        {
            this.health--;
        }
    }
}
