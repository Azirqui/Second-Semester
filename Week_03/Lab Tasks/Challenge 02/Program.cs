using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Challenge_02.BL;


namespace Challenge_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*------------------ List ---------------------*/
            List<Store> product = new List<Store>();
            /*------------------ Object ---------------------*/
            Store temp = new Store();

            int option;
            do
            {
                option = menu();
                if (option == 1)
                {
                    temp = addProducts();
                    product.Add(temp);
                }
                else if (option == 2)
                {
                    viewProducts(product);
                }
                else if (option == 3)
                {
                    highestPrice(product);
                }
                else if (option == 4)
                {
                    Store.CalculateTax(product);
                    Store.ViewTax(product);
                }
                else if (option == 5)
                {
                    Store.Threshold(product);
                }
                else if (option == 6)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice!");
                }
            }
            while (option != 6);
            Console.WriteLine("Press Enter to Exit!");
            Console.Read();
        }
        /*------------------ Menu Function ---------------------*/
        static int menu()
        {
            Console.Clear();
            int choice;
            Console.WriteLine("Enter Your Choice!");
            Console.WriteLine("1- For Add a Product.");
            Console.WriteLine("2- View All Product.");
            Console.WriteLine("3- Find Product with the Highest Unit Price.");
            Console.WriteLine("4- View Sales Tax of All Products.");
            Console.WriteLine("5- Products to be Ordered. (less than the threshold).");
            Console.WriteLine("6- Exit.");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        /*------------------ Add Products Function ---------------------*/
        static Store addProducts()
        {
            Console.Clear();
            Store p1 = new Store();
            Console.WriteLine("Enter Product Type (Grocery/Fruit): ");
            p1.ProductType = Console.ReadLine();
            Console.WriteLine("Enter Product Name: ");
            p1.ProductName = Console.ReadLine();
            Console.WriteLine("Enter Product Category: ");
            p1.Product_Category = Console.ReadLine();
            Console.WriteLine("Enter Product Price: ");
            p1.Product_Price = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Stock Quantity: ");
            p1.Stock_Quantity = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Minimum Stock Quantity: ");
            p1.Min_Stock_Quantity = float.Parse(Console.ReadLine());
            return p1;
        }
        /*------------------ View Products Function ---------------------*/
        static void viewProducts(List<Store> p)
        {
            Console.Clear();
            for (int i = 0; i < p.Count; i++)
            {
                Console.WriteLine("Product Type: " + p[i].ProductType);
                Console.WriteLine("Product Name: " + p[i].ProductName);
                Console.WriteLine("Product Category: " + p[i].Product_Category);
                Console.WriteLine("Product Price: " + p[i].Product_Price);
                Console.WriteLine("Stock Quantity: " + p[i].Stock_Quantity);
                Console.WriteLine("Minimum Stock Quantity: " + p[i].Min_Stock_Quantity);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        /*------------------ Highest Price Determining Function ---------------------*/
        static void highestPrice(List<Store> p)
        {
            Console.Clear();
            int index = 0;
            float start = p[0].Product_Price;
            for (int i = 0; i < p.Count; i++)
            {
                if (p[i].Product_Price > start)
                {
                    start = p[i].Product_Price;
                    index = i;
                }
            }
            Console.WriteLine("Product with Highest Price is: " + p[index].ProductName);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        } 

    }
}
