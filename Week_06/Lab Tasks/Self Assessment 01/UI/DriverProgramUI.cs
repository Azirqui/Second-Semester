using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Assessment_01.UI
{
    internal class DriverProgramUI
    {
        public static int Menu()
        {
            int choice;
            Console.WriteLine("1.Add a Menu item");
            Console.WriteLine("2.View the Cheapest Item in the menu");
            Console.WriteLine("3.View the Drink’s Menu");
            Console.WriteLine("4.View the Food’s Menu");
            Console.WriteLine("5.Add Order");
            Console.WriteLine("6.Fulfill the Order");
            Console.WriteLine("7.View the Orders’s List");
            Console.WriteLine("8.Total Payable Amount");
            Console.WriteLine("9.Exit");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        public static void clearScreen()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
