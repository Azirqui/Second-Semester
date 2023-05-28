using LM_03_4_Task1.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM_03_4_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // default constructor
            clockType empty_time = new clockType();
            Console.WriteLine("Empty time: ");
            empty_time.printTime();

            // Parameterized constructor (one pararmeter)
            clockType hour_time = new clockType(8);
            Console.Write("Hour time: ");
            hour_time.printTime();
            // Parameterized constructor (two parameter)
            clockType minute_time = new clockType(8,10);
            Console.Write("Minute time: ");
            minute_time.printTime();
            // Parameterized constructor (three parameter)
            clockType full_time = new clockType(8,10,10);
            Console.Write("Full time: ");
            full_time.printTime();

            // increment second
            full_time.incrementSecond();
            Console.Write("Full time (Increment Second): ");
            full_time.printTime();
            // increment hours
            full_time.incrementHours();
            Console.Write("Full time (Increment hours): ");
            full_time.printTime();
            // increment minutes
            full_time.incrementMinutes();
            Console.Write("Full time (Increment Minutes): ");
            full_time.printTime();

            // check if equal
            bool flag = full_time.isEqual(9, 11, 11);
            Console.WriteLine("Flag: " + flag);

            // check if equal with object
            clockType cmp = new clockType(10, 12, 1);
            flag = full_time.isEqual(cmp);
            Console.WriteLine("Object Flag: " + flag);
            Console.ReadKey();
        }
    }
}
