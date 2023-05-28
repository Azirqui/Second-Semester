using Self_Assessment_01.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Assessment_01.UI
{
    internal class MenuItemUI
    {
        public static MenuItem takeInput()
        {
            Console.WriteLine("Enter Item Name: ");
            string itemName = Console.ReadLine();
            Console.WriteLine("Enter Item Type: ");
            string itemType = Console.ReadLine();
            Console.WriteLine("Enter Item Price: ");
            float itemPrice = float.Parse(Console.ReadLine());
            MenuItem newItem = new MenuItem(itemName, itemType, itemPrice);
            return newItem;
        }
    }
}
