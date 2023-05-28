using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02.BL
{
    internal class Product
    {
        /*-------------- Data Members --------------*/
        public string name;
        public string category;
        public int price;
        public float Stock_Quantity;
        public float Min_Stock_Quantity;
        public float Sales_tax;
        /*-------------- Parameterized Constructor --------------*/
        public Product(string name, string category, int price, float Stock_Quantity, float Min_Stock_Quantity)
        {
            this.name = name;
            this.category = category;
            this.price = price;
            this.Stock_Quantity = Stock_Quantity;
            this.Min_Stock_Quantity = Min_Stock_Quantity;
        }
        /*------------------ Calculate Tax Constructor ---------------------*/
        public static void CalculateTax(List<Product> product)
        {           
            for (int i = 0; i < product.Count; i++)
            {
                if (product[i].category == "Grocery")
                {
                    product[i].Sales_tax = (product[i].price * 10) / 100;
                }
                else if (product[i].category == "Fruit")
                {
                    product[i].Sales_tax = (product[i].price * 5) / 100;
                }
                else
                {
                    product[i].Sales_tax = (product[i].price * 15) / 100;
                }
            }
        }
        /*------------------ View Tax Constructor ---------------------*/
        public static void ViewTax(List<Product> product)
        {
            Console.Clear();
            for (int i = 0; i < product.Count; i++)
            {
                Console.WriteLine(product[i].name + " " + product[i].Sales_tax);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
        /*------------------ Threshold Determining Constructor ---------------------*/
        public static void Threshold(List<Product> product)
        {
            Console.Clear();
            bool flag = false;
            for (int i = 0; i < product.Count; i++)
            {
                if (product[i].Stock_Quantity <= product[i].Min_Stock_Quantity)
                {
                    Console.WriteLine(product[i].name);
                }
                else { flag = true; }
                
            }
            if (flag == false)
            {                           
                    Console.WriteLine("Enough Stock!");              
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

    }
}
