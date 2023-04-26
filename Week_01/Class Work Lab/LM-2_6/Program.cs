using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM_2_6
{
    internal class Program
    {
        static void readData(string path, string[] names, int[] orders_num, string[] orders, int[] spaces, string[] data_array)
        {
            int x = 0;
            int y = 0;
            if (File.Exists(path))
            {
                StreamReader filevariable = new StreamReader(path);
                string record;
                while ((record = filevariable.ReadLine()) != null)
                {
                    data_array = record.Split(' ');
                    for (int i = 0; i < data_array.Length; i++)
                    {
                        if (i == 0)
                        {
                            names[x] = data_array[i];
                        }

                        if (i == 1)
                        {
                            orders_num[x] = int.Parse(data_array[i]);
                        }
                        if (i == 2)
                        {
                            orders[x] = data_array[i];
                        }

                    }
                    x++;
                }
            }
            else
            {
                Console.WriteLine("File Does Not Exists!!!");
            }          
        }
        static void Main(string[] args)
        {
            string path = "G:\\Nextcloud\\C#\\OOP Lab\\Week 01\\Class Work Lab\\LM-2_6\\File.txt";
            string[] names = new string[100];
            int[] orders_num = new int[5];
            string[] orders = new string[20];
            int[] spaces = new int[5];
            string[] data_array = new string[10];
            int Minimum_orders;
            int Order_price;
            string[] order_1=new string[8];
            string[] order_2=new string[10];
            readData(path, names, orders_num, orders, spaces, data_array);
            split_orders(orders,ref order_1, ref order_2);
            Console.WriteLine("Enter Minimum Number of Orders: ");
            Minimum_orders = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Minimum Order Price: ");
            Order_price = int.Parse(Console.ReadLine());          
            eligibal_for_pizza(ref Order_price, ref Minimum_orders, ref order_1,ref order_2, names);
            Console.ReadKey();
        }
        static void split_orders(string[] orders,ref string[] order_1,ref string[] order_2)
        {
            string temp1 = "";
            string temp2 = "";
            string temp3 = "";
            string temp4 = "";
            for (int i = 0; i < orders.Length; i++)
            {
                if (i == 0)
                {
                    temp1 = orders[i];
                }
                if (i == 1)
                {
                    temp2 = orders[i];
                }
            }
            temp3 = temp1.Substring(1, 23);
            temp4 = temp2.Substring(1, 28);
            order_1 = temp3.Split(',');
            order_2 = temp4.Split(',');
           
        }
        static void eligibal_for_pizza(ref int Order_price, ref int Minimum_orders, ref string[] order_1,ref  string[] order_2, string[] names)
        {
            int count1 = 0;
            int count2 = 0;          
            for (int i = 0; i < 8; i++)
            {
                if (Order_price < int.Parse(order_1[i]))
                {
                    count1++;
                }
            }
            for (int i = 0; i < 10; i++)
            {                
                if (Order_price < int.Parse(order_2[i]))
                {                   
                    count2++;
                }
            }                    
            if (count1 >= Minimum_orders)
            {
                Console.WriteLine(names[0]);
            }
            if (count2 >= Minimum_orders)
            {
                Console.WriteLine(names[1]);
            }         
        }
    }
}
