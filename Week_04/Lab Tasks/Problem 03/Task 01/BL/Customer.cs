using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_03.BL
{
    internal class Customer
    {
        /*-------------- Data Members --------------*/
        public string CustomerName;
        public string CustomerAddress;
        public string CustomerContact;
        public List<Products> products = new List<Products>();

        /*-------------- Parameterized Constructor --------------*/
        public Customer(string customerName,string customerAddress,string customerContact) 
        {
          this.CustomerName = customerName;
          this.CustomerAddress = customerAddress;
          this.CustomerContact= customerContact;
        }
        /*-------------- Function for Returning Products --------------*/
        public List<Products> getAllProducts()
        {
            return products;
        }
        /*-------------- Add Product Function --------------*/
        public void addProduct(Products p) 
        {
            products.Add(p);
        }
    }
}
