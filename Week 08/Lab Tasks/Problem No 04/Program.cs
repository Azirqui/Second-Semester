using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem_No_04.BL;
using Problem_No_04.DL;

namespace Problem_No_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Objects Initializing
            Rectangle rectangle = new Rectangle(4,4);
            Square square = new Square(4);
            Circle circle = new Circle(4);
            // Adding into the List
            ShapeDL.shapesData.Add(rectangle);
            ShapeDL.shapesData.Add(square);
            ShapeDL.shapesData.Add(circle);
            // Printing output on Console
            foreach (Shape shape in ShapeDL.shapesData)
            {
                Console.WriteLine(shape.toString());
            }
            Console.ReadKey();
        }
    }
}
