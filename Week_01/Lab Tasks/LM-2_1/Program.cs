using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM_2_1
{
    internal class Program
    {
        //-------------------Task 01-----------------------
        //static void Main(string[] args)
        //{
        //    String str;
        //    Console.Write("Enter your marks: ");
        //    str=Console.ReadLine();
        //    float marks=float .Parse(str);
        //    if(marks>50)
        //    {
        //        Console.WriteLine("You are Passed!!!");
        //    }
        //    else
        //    {
        //        Console.WriteLine("You are Failed!!!");
        //    }
        //    Console.ReadKey();
        //}


        //-------------------Task 02-----------------------
        //static void Main(string[] args) 
        //{
        //    for(int x=0;x<5;x++)
        //    {
        //        Console.WriteLine("Welcome Noman!!!");
        //    }
        //    Console.ReadKey();
        //}


        //-------------------Task 03-----------------------
        //static void Main(string[] args)
        //{
        //    int num;
        //    int sum = 0;
        //    String str;
        //    Console.WriteLine("Enter Number: ");
        //    str=Console.ReadLine();
        //    num=int.Parse(str);
        //    while(num !=-1)
        //    {
        //        sum = sum + num;
        //        Console.WriteLine("Enter Number");
        //        num=int.Parse(Console.ReadLine());
        //    }
        //    Console.WriteLine("The total sum is: {0}", sum);
        //    Console.ReadKey();
        //}

        //-------------------Task 04-----------------------
        //static void Main(string[] args) 
        //{
        //    int num;
        //    int sum = 0;
        //    do
        //    {
        //        Console.Write("Enter Number: ");
        //        num = int.Parse(Console.ReadLine());
        //        sum = sum + num;
        //    }
        //    while (num != -1);
        //    {
        //        sum = sum + 1;
        //        Console.Write("Sum is: {0}", sum);
        //        Console.ReadKey();
        //    }
        //}


        //-------------------Task 05-----------------------
        //static void Main(string[] args) 
        // {
        // int[] numbers = new int[10];
        //  for(int x=0;x<10;x++)
        //     {
        //         Console.WriteLine("Enter Number {0}", x + 1);
        //         numbers[x] = int.Parse(Console.ReadLine());
        //     }
        //     int largest = -1;
        //     for(int x=0;x<10;x++)
        //     {
        //         if (largest < numbers[x])
        //         {
        //             largest = numbers[x];
        //         }
        //     }
        //     Console.WriteLine("Largest number is: {0}", largest);
        //     Console.ReadKey();
        // }


        //-------------------Task 05-----------------------
        static void Main(string[] args) 
        {
            int age;
            float toy_price;
            float machine_price;
            Console.Write("Enter Age: ");
            age=int.Parse(Console.ReadLine());
            Console.Write("Enter Toy Price: ");
            toy_price = float.Parse(Console.ReadLine());
            Console.Write("Enter Machine Price: ");
            machine_price = float.Parse(Console.ReadLine());
            int even_count = 0;
            int odd_count = 0;
            float total=0;
            float total_money;
            int remainder;
            float even_sum;
            float odd_price;
            float result;
            for(int x=0;x<age;x++)
            {
                remainder = x % 2;
                if(remainder == 0)
                {
                    even_count++;
                }
                else
                {
                    odd_count++;
                }
            }
            for(int x=1;x<=even_count;x++) 
            {
                even_sum = (10 * x) - 1;
                total = total + even_sum;
            }
            odd_price = toy_price * odd_count;
            total_money = odd_price + total;
            if(total_money> machine_price)
            {
                result = total_money - machine_price;
                Console.Write("Yes!!! {0}", result);
            }
            else if(total_money < machine_price) 
            {
                result = machine_price - total_money;
                Console.Write("No!!! {0}", result);
            }
            Console.ReadKey();

        }
    }
}
