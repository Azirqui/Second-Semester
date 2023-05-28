using Challenge_01.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyLine myLine = null;
            int option;
            do
            {
                option = Menu();
                Console.Clear();
                if (option == 1)
                {
                    myLine = makeLine();
                }
                else if (option == 2)
                {
                    Update_beginPoint(myLine);
                    Console.ReadKey();
                }
                else if (option == 3)
                {
                    Update_endPoint(myLine);
                    Console.ReadKey();
                }
                else if (option == 4)
                {                   
                    Console.WriteLine(myLine.getBegin().x);                    
                    Console.WriteLine(myLine.getBegin().y);
                    Console.ReadKey();
                }
                else if (option == 5)
                {
                    Console.WriteLine(myLine.getEnd().x);
                    Console.WriteLine(myLine.getEnd().y);
                    Console.ReadKey();
                }
                else if (option == 6)
                {
                    Console.WriteLine(myLine.getLength());
                    Console.ReadKey();
                }
                else if (option == 7)
                {
                    Console.WriteLine(myLine.getGradient());
                    Console.ReadKey();
                }
                else if (option == 8)
                {
                    Console.WriteLine(myLine.getBegin().distanceWithZero());
                    Console.ReadKey();
                }
                else if (option == 9)
                {
                    Console.WriteLine(myLine.getEnd().distanceWithZero());
                    Console.ReadKey();
                }
                Console.Clear();

            }
            while (option != 10);
            Console.ReadKey();
        }
        static int Menu()
        {
            int choice;
            Console.WriteLine("1. Make a Line");
            Console.WriteLine("2. Update the begin point");
            Console.WriteLine("3. Update the end point");
            Console.WriteLine("4. Show the begin point");
            Console.WriteLine("5. Show the end point");
            Console.WriteLine("6. Get the Length of the line");
            Console.WriteLine("7. Get the Gradient of the line");
            Console.WriteLine("8. Find the distance of begin point from zero coordinates");
            Console.WriteLine("9. Find the distance of end point from zero coordinates");
            Console.WriteLine("10. Exit");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        static MyLine makeLine()
        {
            int x1;
            int x2;
            int y1;
            int y2;
            Console.WriteLine("Enter 1st Point x-Coordinate: ");
            x1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter 1st Point y-Coordinate: ");
            y1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter 2nd Point x-Coordinate: ");
            x2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter 2nd Point y-Coordinate: ");
            y2 = int.Parse(Console.ReadLine());
            MyLine myLine = new MyLine(new MyPoint(x1, y1),new MyPoint(x2,y2));
            return myLine;
        }
        static void Update_beginPoint(MyLine myLine)
        {
            MyPoint point;
            MyPoint begin_point = myLine.getBegin();
            point = get_MyPoint();
            begin_point.setXY(point.x, point.y);  
        }
        static void Update_endPoint(MyLine myLine)
        {
            MyPoint point;
            MyPoint end_point = myLine.getEnd();
            point = get_MyPoint();
            end_point.setXY(point.x, point.y);
        }
        static MyPoint get_MyPoint()
        {
            int x, y;
            Console.WriteLine("Enter Point x-Coordinate: ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Point x-Coordinate: ");
            y = int.Parse(Console.ReadLine());
            MyPoint point = new MyPoint(x, y);
            return point;
        }

    }
}
