using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_01.BL;

namespace Challenge_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*------------------ Objects ---------------------*/
            clockType initial_time = new clockType();
            clockType elapsed_Time = new clockType();
            clockType remaining_Time = new clockType();
            /*------------------ Variables ---------------------*/
            initial_time.hours = 10;
            initial_time.minutes = 10;
            initial_time.seconds = 10;
            /*------------------ Functions Calling ---------------------*/
            elapsed_Time = clockType.elapsedTime(initial_time);
            remaining_Time = clockType.remaining_time(initial_time);
            /*------------------ Output Printing ---------------------*/
            Console.WriteLine("Elapsed Time: "+elapsed_Time.hours+ " " + elapsed_Time.minutes + " " + elapsed_Time.seconds);
            Console.WriteLine("Remaining Time: "+ -remaining_Time.hours+ " " + -remaining_Time.minutes + " " + -remaining_Time.seconds);           
            Console.ReadKey();
        }
    }
}
