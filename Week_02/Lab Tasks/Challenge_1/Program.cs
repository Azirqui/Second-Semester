using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Challenge_1
{
    internal class Program
    {
        class Data
        {
            public string ID;
            public string Name;
            public float Price;
            public string Brandname;
            public string Country;
            public string Category;
        }
        static int menu()
        {
            Console.Clear();
            int choice;
            Console.WriteLine("Enter Your Choice!");
            Console.WriteLine("1- For Add a Product.");
            Console.WriteLine("2- For View a Product.");
            Console.WriteLine("3- Total Store Worth.");
            Console.WriteLine("4- Exit.");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        static Data addProducts()
        {
            Console.Clear();
            Data p1 = new Data();
            Console.WriteLine("Enter Product Id: ");
            p1.ID=Console.ReadLine();
            Console.WriteLine("Enter Product Name: ");
            p1.Name = Console.ReadLine();
            Console.WriteLine("Enter Product Price: ");
            p1.Price = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Product Brandname: ");
            p1.Brandname = Console.ReadLine();
            Console.WriteLine("Enter Product Country: ");
            p1.Country = Console.ReadLine();
            Console.WriteLine("Enter Product Category: ");
            p1.Category = Console.ReadLine();
            return p1;
        }
        static void viewProducts(Data[] p,int count)
        {
            Console.Clear();
            for(int i=0;i<count;i++)
            {
                Console.WriteLine("ID: {0} Name: {1} Price: {2} Brandname: {3} Country: {4} Category: {5}", p[i].ID, p[i].Name, p[i].Price, p[i].Brandname, p[i].Country, p[i].Category);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
       
        static void store_worth(Data[] p,int count)
        {
            Console.Clear();
            float sum =0;
            for(int i=0;i<count;i++)
            {
                sum = sum+p[i].Price;
            }
            Console.WriteLine("Total Store Worth: {0}", sum);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Data[] products = new Data [10];
            int option;
            int count = 0;
            do
            {
                option = menu();
                if (option == 1)
                {
                    products[count] = addProducts();
                    count++;
                }
                else if (option == 2)
                {
                    viewProducts(products, count);
                }
                else if (option == 3)
                {
                    store_worth(products, count);
                }
                else if (option == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Choice!");
                }
            }
            while (option != 4);
            Console.WriteLine("Press Enter to Exit!");
            Console.Read();
        }
    }
}
