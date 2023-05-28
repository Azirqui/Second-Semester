using Self_Assessment_01.BL;
using Self_Assessment_01.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Assessment_01.UI
{
    internal class CoffeeShopUI
    {
        public static CoffeeShop myCoffeeShop = new CoffeeShop("Alpha");
        public static void loadItemsFromFile()
        {
            MenuItemDL.loadFromFile("Shopdata.txt", myCoffeeShop);
        }
        public static void loadShopFromFile()
        {
            CoffeeShopDL.loadFromFile("MenuItem.txt", myCoffeeShop);
        }
        public static void storeShopIntoFile()
        {
            CoffeeShopDL.storeIntoFile("MenuItem.txt", myCoffeeShop);
        }
        public static void addMenuItem()
        {
            MenuItem newMenuItem = MenuItemUI.takeInput();
            myCoffeeShop.addMenuItem(newMenuItem);
            MenuItemDL.storeIntoFile("Shopdata.txt", newMenuItem);

        }
        public static void placeOrder()
        {

            Console.WriteLine("Enter name of the item you want to order: ");
            string itemName = Console.ReadLine();
            bool order = CoffeeShop.addOrder(itemName);
            if (order = true)
            {
                Console.WriteLine("Order Added!");
            }
            else 
            {
                Console.WriteLine("This item is currently unavailable!");
            }
        }
        public static void viewCheapest()
        {
            string cheapest = CoffeeShop.cheapestItem();
            Console.WriteLine("Cheapest item is : " + cheapest);
        }
        public static void viewDrinksMenu()
        {
            List<string> newList = CoffeeShop.drinksOnly();
            foreach (string item in newList)
            {
                Console.WriteLine(item);
            }
        }
        public static void viewFoodMenu()
        {
            List<string> newList = CoffeeShop.foodOnly();
            foreach (string item in newList)
            {
                Console.WriteLine(item);
            }
        }
        public static void viewAmount()
        {
            Console.WriteLine(CoffeeShop.dueAmount());
        }
        public static void viewOrders()
        {
            List<string> newList = CoffeeShop.listOrder();
            foreach (string item in newList)
            {
                Console.WriteLine(item);
            }
        }
        public static void orderFulfill()
        {
            string status = CoffeeShop.fulfillOrder();
            Console.WriteLine(status);
        }

    }
}
