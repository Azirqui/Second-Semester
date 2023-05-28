using Problem_02.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Problem_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string direction;

            Console.WriteLine("Enter Direction:(Projectile/Diagonal/Patrol)");
            direction = Console.ReadLine();
            char[,] shape = new char[2, 4] {
                {'<', 'o', 'o', '>'},
                {' ', '/', '\\', ' '} };
                
            Boundary premises = new Boundary();
            GameObject g1 = new GameObject(shape, new Point(16, 0), premises, direction);
            while (true)
            {
                Thread.Sleep(100);
                Console.Clear();
                g1.Move();
                g1.draw();             
            }
        }
    }
}
