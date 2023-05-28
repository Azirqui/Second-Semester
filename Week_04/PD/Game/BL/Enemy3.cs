using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.BL
{
    internal class Enemy3
    { 
      public int health;
      public Enemy3()
      {
          health = 100;
      }
      public void Decrease_Health()
      {
          this.health--;
      }        
    }
}
