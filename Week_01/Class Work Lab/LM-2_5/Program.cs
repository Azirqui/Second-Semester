using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace LM_2_5
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
        static string parseData(string record,int field)
        {
            int comma = 1;
            string item ="";
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
        static void readData(string path, string[] names, string[] passwords)
        {
            int x = 0;
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    names[x] = parseData(record, 1);
                    passwords[x] = parseData(record, 2);
                    x++;
                    if(x>=5)
                    {
                        break;
                    }            
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("File Not Exists");
            }
        }
        // <-----------------------  signUp Function  ---------------------->
        static void signUp(string path,string n,string p)
        {
            StreamWriter file = new StreamWriter(path,true);
            file.WriteLine(n + "," + p);
            file.Flush();
            file.Close();
        }
        // <-----------------------  signIn Function  ---------------------->
        static void signIn(string n,string p, string[] names, string[] passwords)
        {
            bool flag = false;
            for (int x = 0 ; x < 5; x++)
            {
                if (n == names[x] && p == passwords[x])
                {
                    Console.WriteLine("Valid User");
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                Console.WriteLine("Invalid User");
            }
            Console.ReadKey();
        }
        // <-----------------------  Main Function  ---------------------->
        static void Main(string[] args)
        {
            string path = "G:\\Nextcloud\\C#\\OOP Lab\\Week 01\\Class Work Lab\\LM-2_5\\File.txt";
            string[] names = new string[5];
            string[] passwords = new string[5];
            int option;
            do
            {
                readData(path, names, passwords);
                Console.Clear();
                option = Menu();
                Console.Clear();
                if(option == 1)
                {
                    Console.WriteLine("Enter Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string p = Console.ReadLine();
                    signIn(n, p, names, passwords);
                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter New Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter New Password: ");
                    string p = Console.ReadLine();
                    signUp(path, n, p);
                }
            }
            while (option < 3);
            {
                Console.ReadKey();
            }
        }
    }
}
