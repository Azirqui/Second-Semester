using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Conventions
//First letter of function and global variable is always capital
//First letter of local variable is always small
namespace LM_1_4
{
    internal class Program
    {
        // ------------------Task 04-----------------------
        //static void Main(string[] args)
        //{
        //    String variable = "I am a Programmer!";
        //    Console.Write("Line is: ");
        //    Console.Write(variable);
        //    Console.ReadKey();
        //}


        //--------------------Task 05-----------------------
        //static void Main(string[] args)
        //{
        //    Char variable = 'N';
        //    Console.Write("Character is: ");
        //    Console.Write(variable);
        //    Console.ReadKey();
        //}


        //--------------------Task 06-----------------------
        //static void Main(string[] args)
        //{
        //    float variable = 35.3F;
        //    Console.Write("Decimal is: ");
        //    Console.Write(variable);
        //    Console.ReadKey();
        //}


        //--------------------Task 07-----------------------
        //static void Main(string[] args)
        //{
        //    String str;
        //    Console.WriteLine("You have entered: ");
        //    str=Console.ReadLine();
        //    int num=int.Parse(str);
        //    Console.Write("Number is: ");
        //    Console.Write(num);
        //    Console.ReadLine();
        //}


        //--------------------Task 08-----------------------
        //static void Main(string[] args)
        //{
        //    String str;
        //    Console.WriteLine("You have entered: ");
        //    str = Console.ReadLine();
        //    float num = float.Parse(str);
        //    Console.Write("Decimal is: ");
        //    Console.Write(num);
        //    Console.ReadLine();
        //}


        //--------------------Task 09-----------------------
        static void Main(string[] args)
        {
            string str;
            int area;
            Console.Write("Enter length of square: ");
            str = Console.ReadLine();
            int length = int.Parse(str);
            area = length * length;
            Console.Write("Area is: ");
            Console.Write(area);
            Console.ReadKey();
        }

    }
}
