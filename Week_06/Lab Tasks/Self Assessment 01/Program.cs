using Self_Assessment_01.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Assessment_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CoffeeShopUI.loadItemsFromFile();
            CoffeeShopUI.loadShopFromFile();
            int option = 0;
            while (option < 9)
            {
                option = DriverProgramUI.Menu();
                DriverProgramUI.clearScreen();
                if (option == 1)
                {
                    CoffeeShopUI.addMenuItem();
                    DriverProgramUI.clearScreen();
                }
                else if (option == 2)
                {
                    CoffeeShopUI.viewCheapest();
                    DriverProgramUI.clearScreen();
                }
                else if (option == 3)
                {
                    CoffeeShopUI.viewDrinksMenu();
                    DriverProgramUI.clearScreen();
                }
                else if (option == 4)
                {
                    CoffeeShopUI.viewFoodMenu();
                    DriverProgramUI.clearScreen();
                }
                else if (option == 5)
                {
                    CoffeeShopUI.placeOrder();
                    DriverProgramUI.clearScreen();
                }
                else if (option == 6)
                {
                    CoffeeShopUI.orderFulfill();
                    DriverProgramUI.clearScreen();
                }
                else if (option == 7)
                {
                    CoffeeShopUI.viewOrders();
                    DriverProgramUI.clearScreen();
                }
                else if (option == 8)
                {
                    CoffeeShopUI.viewAmount();
                    DriverProgramUI.clearScreen();
                }
            }
            CoffeeShopUI.storeShopIntoFile();
        
    }
    }
}
