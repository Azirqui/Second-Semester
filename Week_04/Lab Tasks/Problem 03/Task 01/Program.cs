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
            /*-------------- Taking Input for Customer --------------*/
            Console.Write("Enter Customer's Name: ");
            string customerName = Console.ReadLine();
            Console.Write("Enter Customer's Address: ");
            string customerAddress = Console.ReadLine();
            Console.Write("Enter Customer's Contact: ");
            string customerContact = Console.ReadLine();

            Customer customer = new Customer(customerName, customerAddress,customerContact);
            bool input = true;

            /*-------------- Taking Input for Products --------------*/
            while (input!=false)
            {
                Console.Clear();
                Console.Write("Enter Name of Product: ");
                string product_Name = Console.ReadLine();
                Console.Write("Enter Category of Product: ");
                string product_category = Console.ReadLine();
                Console.Write("Enter Price of Product: ");
                int product_price = int.Parse(Console.ReadLine());

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
            /*-------------- Printing Products --------------*/

            List<Products> all_Products = new List<Products>();
            all_Products=customer.getAllProducts();
            foreach (Products product in all_Products)
            {

                Console.WriteLine(product.name);
            }           
            Console.ReadKey();
        }
    }
}
