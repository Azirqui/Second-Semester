using Self_Assessment_01.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Assessment_01.DL
{
    internal class MenuItemDL
    {
        public static void storeIntoFile(string path, MenuItem newMenuItem)
        {
            StreamWriter f = new StreamWriter(path, true);
            f.WriteLine(newMenuItem.getName() + "," + newMenuItem.getType() + "," + newMenuItem.getPrice());
            f.Flush();
            f.Close();
        }
        public static bool loadFromFile(string path, CoffeeShop C)
        {
            StreamReader f = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name = splittedRecord[0];
                    string type = splittedRecord[1];
                    int price = int.Parse(splittedRecord[2]);
                    MenuItem newMenuItem = new MenuItem(name, type, price);
                    C.addMenuItem(newMenuItem);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
