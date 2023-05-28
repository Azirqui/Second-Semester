using Problem_03.BL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Problem_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ---------------- Taking Customer Details ----------------
            Console.Write("Enter Customer's Name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter Customer's Address: ");
            string customerAddress = Console.ReadLine();
            Console.Write("Enter Customer's Contact: ");
            string customerContact = Console.ReadLine();
            // ---------------- Making Customer Object ----------------
            Customer customer = new Customer(customerName, customerAddress, customerContact);
            // ---------------- Initializing Variables ----------------
            bool input = true;
            string product_Name ="";
            string product_category = "";
            int product_price=0;
            float tax;
            // ---------------- Taking Customer Details ----------------
            while (input!=false)
            {
                Console.Clear();
                Console.Write("Enter Name of Product: ");
                product_Name = Console.ReadLine();
                Console.Write("Enter Category of Product: ");
                product_category = Console.ReadLine();
                Console.Write("Enter Price of Product: ");
                product_price = int.Parse(Console.ReadLine());
                // ---------------- Making Product Object ----------------
                Products product = new Products(product_Name, product_category, product_price);
                customer.addProduct(product);
                Console.Write("Do you want to add more products?(y/n)");
                char choice = char.Parse(Console.ReadLine());
                if(choice == 'y')
                {
                    input = true;
                }
                else 
                {
                    input= false;
                }
            }

            List<Products> all_Products = new List<Products>();
            all_Products = customer.getAllProducts();

            foreach (Products product in all_Products)
            {

                Console.WriteLine(product.name);
            }
            Console.Write("Enter Percentage Tax: ");
            tax = float.Parse(Console.ReadLine());
            Products p1 = new Products(product_Name,product_category,product_price);
            float calculated_tax= p1.calculateTax(tax, all_Products);
            Console.Write("Tax on All Products is:" + calculated_tax);
            Console.ReadKey();


        }
    }
}
