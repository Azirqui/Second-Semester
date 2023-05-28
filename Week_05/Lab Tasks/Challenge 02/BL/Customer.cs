using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02.BL
{
    internal class Customer
    {
        /*-------------- Data Members --------------*/
        public string CustomerName;
        public string CustomerAddress;
        public string CustomerContact;
        public List<Product> products = new List<Product>();

        /*-------------- Parameterized Constructor --------------*/
        public Customer(string customerName, string customerAddress, string customerContact)
        {
            this.CustomerName = customerName;
            this.CustomerAddress = customerAddress;
            this.CustomerContact = customerContact;
        }
        /*-------------- Products Returning Function --------------*/
        public List<Product> getAllProducts()
        {
            return products;
        }
        /*-------------- Add Product Function --------------*/
        public void addProduct(Product p)
        {
            products.Add(p);
        }
    }
}
