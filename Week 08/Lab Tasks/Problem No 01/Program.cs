using Problem_No_01.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_No_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cylinder c1= new Cylinder();
            Cylinder c2= new Cylinder(4,4);
            Cylinder c3= new Cylinder(5,5,"Blue");
            Console.WriteLine(c1.getVolume());
            Console.WriteLine(c2.getVolume());
            Console.WriteLine(c3.getVolume());
            Console.ReadKey();
        }
    }
}
