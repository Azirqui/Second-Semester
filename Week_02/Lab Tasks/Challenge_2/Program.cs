using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    internal class Program
    {
      
        // <-----------------------  Menu Function  ---------------------->
        static int Menu()
        {
            int option;
            Console.WriteLine("1. Sign In");
            Console.WriteLine("2. Sign UP");
            Console.WriteLine("Enter Option");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        // <-----------------------  parseData Function  ---------------------->
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        // <-----------------------  readData Function  ---------------------->
        static void readData(string path, Credential[] ID,ref int x)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    Credential id = new Credential();
                    id.username = parseData(record, 1);
                    id.password = parseData(record, 2);
                   
                    //if (x >= 5)
                    //{
                    //    break;
                    //}
                ID[x] = id;
                x++;
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("File Not Exists");
            }
        }
        // <-----------------------  signUp Function  ---------------------->
        static void signUp(string path, Credential[] ID)
        {
            
            Credential id = new Credential();
            StreamWriter file = new StreamWriter(path, true);
            Console.WriteLine("Enter Username: ");
            id.username = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            id.password = Console.ReadLine();
            file.WriteLine(id.username + "," + id.password);
            file.Flush();
            file.Close();
        }
        // <-----------------------  signIn Function  ---------------------->
        static void signIn(string n, string p, Credential[] ID)
        {
            bool flag = false;
            for (int x = 0; x < 5; x++)
            {
                if (n == ID[x].username && p == ID[x].password)
                {
                    Console.WriteLine("Valid User"); 
                    flag = true;
                    break;
                }                   
            }
            if (flag == false)
            {
                Console.WriteLine("InValid User");
            }
            Console.ReadKey();
        }
        // <-----------------------  Main Function  ---------------------->
       
        static void Main(string[] args)
        {
            int x = 0;
            string path = "G:\\Nextcloud\\C#\\OOP Lab\\Week 02\\Lab Work\\Challenge_2\\File.txt";
            Credential[] ID = new Credential[10];
            int option;
            do
            {
                readData(path,ID,ref x);
                Console.Clear();
                option = Menu();
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string p = Console.ReadLine();
                    signIn(n, p,ID);
                }
                else if (option == 2)
                {
                    signUp(path,ID);
                }
            }
            while (option < 3);
            {
                Console.ReadKey();
            }
        }
    }
}
