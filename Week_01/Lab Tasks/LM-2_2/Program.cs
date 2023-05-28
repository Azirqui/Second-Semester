using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM_2_2
{
    internal class Program
    {
        static int add(int x, int y)
        {
            return x + y;
        }
        static void Main(string[] args)
        {
            int num1;
            int num2;
            Console.Write("Enter number1: ");
            num1=int.Parse(Console.ReadLine());
            Console.Write("Enter number2: ");
            num2 = int.Parse(Console.ReadLine());
            int result=add(num1,num2);
            Console.WriteLine("Result is: {0}",result);
            Console.ReadKey();

        }
    }
}
