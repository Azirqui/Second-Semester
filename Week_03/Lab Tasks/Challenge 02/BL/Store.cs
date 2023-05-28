using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Challenge_02.BL
{
    internal class Store
    {
        /*------------------ Data Members of Class ---------------------*/
        public string ProductType;
        public string ProductName;
        public string Product_Category;
        public float Product_Price;
        public float Stock_Quantity;
        public float Min_Stock_Quantity;
        public float Sales_tax;
        /*------------------ Calculate Tax Constructor ---------------------*/
        public static void CalculateTax(List<Store> product)
        {           
            for (int i = 0; i < product.Count; i++)
            {
                if (product[i].ProductType == "Grocery")
                {
                    product[i].Sales_tax=(product[i].Product_Price * 10)/ 100;
                }
                else if (product[i].ProductType == "Fruit")
                {
                    product[i].Sales_tax = (product[i].Product_Price * 5) / 100;
                }                          
            }      
        }
        /*------------------ View Tax Constructor ---------------------*/
        public static void ViewTax(List<Store> product)
        {
            Console.Clear();
            for (int i = 0; i < product.Count; i++)
            {
                Console.WriteLine(product[i].ProductName + " " + product[i].Sales_tax);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        /*------------------ Threshold Determining Constructor ---------------------*/
        public static void Threshold(List<Store> product)
        {
            Console.Clear();
            for (int i = 0; i < product.Count; i++)
            {
                if (product[i].Stock_Quantity >= product[i].Min_Stock_Quantity)
                {
                    Console.WriteLine(product[i].ProductName);
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
