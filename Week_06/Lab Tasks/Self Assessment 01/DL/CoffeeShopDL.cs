using Self_Assessment_01.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Assessment_01.DL
{
    internal class CoffeeShopDL
    {
        public static bool loadFromFile(string filePath, CoffeeShop Coffee)
        {
            StreamReader f = new StreamReader(filePath);
            string record;
            if (File.Exists(filePath))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string name = splittedRecord[0];
                    string[] splittedRecordSub = splittedRecord[1].Split(';');
                    Coffee.setName(name);
                    for (int i = 0; i < splittedRecordSub.Length; i++)
                    {
                        MenuItem M = CoffeeShop.isMenuItemExist(splittedRecordSub[i]);
                        if (M != null)
                        {
                            CoffeeShop.addOrder(M.getName());
                        }
                    }
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void storeIntoFile(string path, CoffeeShop C)
        {
            StreamWriter f = new StreamWriter(path, false);
            string orderListName = "";
            for (int i = 0; i < CoffeeShop.orders.Count; i++)
            {
                if (i != CoffeeShop.orders.Count - 1)
                {
                    orderListName += CoffeeShop.orders[i] + ";";
                }
                else
                {
                    orderListName += CoffeeShop.orders[i];
                }
            }
            f.WriteLine(C.getName() + "," + orderListName);
            f.Flush();
            f.Close();
        }
    }
}
