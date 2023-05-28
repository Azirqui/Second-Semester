using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Self_Assessment_01.BL
{
    internal class CoffeeShop
    {
        public string name;
        public static List<MenuItem> list_items = new List<MenuItem>();
        public static List<String> orders = new List<String>();
        public CoffeeShop(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }
        public void addMenuItem(MenuItem item)
        {
            list_items.Add(item);
        }
        public static bool addOrder(string name)
        {
            bool flag = false;
            foreach (MenuItem item in list_items)
            {
                if (item.name == name)
                {
                    orders.Add(name);
                    flag = true;
                    return flag;
                }
            }
            return flag;
        }
        public static MenuItem isMenuItemExist(string name)
        {
            foreach (MenuItem item in list_items)
            {
                if (item.getName() == name)
                {
                    return item;
                }
            }
            return null;
        }
        public static string fulfillOrder()
        {
            if (orders.Count != 0)
            {
                orders.Clear();
                string statement = "The {item} is ready!";
                return statement;
            }
            if (orders.Count == 0)
            {
                string statement = "The {item} is ready!";
                return statement;
            }
            return null;
        }
        public static List<string> listOrder()
        {
            if (orders.Count != 0)
            {
                return orders;
            }
            else
            {
                return null;
            }
        }
        public static string cheapestItem()
        {
            string cheapest_item_name = "";
            float cheapest_item = 0.0F;
            foreach (MenuItem item in list_items)
            {
                if (cheapest_item < item.price)
                {
                    cheapest_item = item.price;
                    cheapest_item_name = item.name;
                }
            }
            return cheapest_item_name;
        }
        public static List<String> drinksOnly()
        {
            List<MenuItem> drinksList = list_items.Where(item => item.getType() == "drink").ToList();
            List<string> drinks = drinksList.Select(items => items.getName()).ToList();
            return drinks;
        }
        public static List<String> foodOnly()
        {
            List<MenuItem> foodList = list_items.Where(item => item.getType() == "food").ToList();
            List<string> food = foodList.Select(items => items.getName()).ToList();
            return food;
        }
        public static double dueAmount()
        {
            double price = 0;
            foreach (string name in orders)
            {
                foreach (MenuItem item in list_items)
                {
                    if (item.getName() == name)
                    {
                        float p = item.getPrice();
                        price += p;
                    }
                }
            }
            return price;
        }

    }

}
