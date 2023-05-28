using Challenge_02.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> product_list_Admin = new List<Product>();

            List<MUser> users = new List<MUser>();
            string path = "G:\\Nextcloud\\C#\\OOP Lab\\Week 06\\Lab Work\\Challenge 02\\Credentials.txt";
            string admin_info_path = "G:\\Nextcloud\\C#\\OOP Lab\\Week 06\\Lab Work\\Challenge 02\\Info_admin.txt";
            int option;
            bool close = true;
            readadmin_info(product_list_Admin, admin_info_path);
            int choice = 0;
            bool check = readData(path, users);
            if (check)
            {
                Console.WriteLine("Data Loaded SuccessFully");
            }
            else
            {
                Console.WriteLine("Data Not Loaded");
                Console.ReadKey();
            }
            do
            {
                Console.Clear();
                option = menu();
                Console.Clear();
                if (option == 1)
                {
                    MUser user = takeInputWithoutRole();
                    if (user != null)
                    {
                        user = signIn(user, users);
                        if (user == null)
                        {
                            Console.WriteLine("Invalid User");
                        }
                        else if (user.isAdmin())
                        {
                            while (close)
                            {
                                Console.Clear();
                                choice = Admin_Menu();
                                if (choice == 1)
                                {
                                    add_Products(product_list_Admin);
                                }
                                else if (choice == 2)
                                {
                                    view_Products(product_list_Admin);
                                }
                                else if (choice == 3)
                                {
                                    highestPrice(product_list_Admin);
                                }
                                else if (choice == 4)
                                {
                                    Product.CalculateTax(product_list_Admin);
                                    Product.ViewTax(product_list_Admin);
                                }
                                else if (choice == 5)
                                {
                                    Product.Threshold(product_list_Admin);
                                }
                                else if (choice == 6)
                                {
                                    close = false;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Choice!");
                                }
                            }
                            storeadmin_info(product_list_Admin, admin_info_path);
                        }
                        else
                        {
                            while (close)
                            {
                                Console.Clear();
                                choice = User_Menu();
                                if (choice == 1)
                                {
                                    //add_Products(product_list_Admin);
                                }
                                else if (choice == 2)
                                {
                                    //view_Products(product_list_Admin);
                                }
                                else if (choice == 3)
                                {
                                    //highestPrice(product_list_Admin);
                                }
                                else if (choice == 4)
                                {
                                    close = false;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Choice!");
                                }
                            }
                        }
                    }
                }
                else if (option == 2)
                {
                    MUser user = takeInputWithRole(); if (user != null)
                    {
                        storeDataInFile(path, user);
                        storeDataInList(users, user);
                    }
                }
                Console.ReadKey();
            }
            while (option < 3);
        }
        /*-------------- Admin Menu --------------*/
        static int Admin_Menu()
        {
            int choice;
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. View All Products");
            Console.WriteLine("3. Find Product with Highest Unit Price");
            Console.WriteLine("4. View Sales Tax op All Products");
            Console.WriteLine("5. Products to be Ordered");
            Console.WriteLine("6. Exit");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        /*-------------- User Menu --------------*/
        static int User_Menu()
        {
            int choice;
            Console.WriteLine("1. View all the products");
            Console.WriteLine("2. Buy the products");
            Console.WriteLine("3. Generate invoice");
            Console.WriteLine("4. Exit");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        /*-------------- (Admin) Add Products--------------*/
        static void add_Products(List<Product> product_list_Admin)
        {
            bool input = true;
            string product_Name = "";
            string product_category = "";
            int product_price = 0;
            float stock_quantity = 0.0F;
            float min_stock_quantity = 0.0F;
            while (input != false)
            {
                Console.Clear();
                Console.Write("Enter Name of Product: ");
                product_Name = Console.ReadLine();
                Console.Write("Enter Category of Product (Grocery/Fruit/Another): ");
                product_category = Console.ReadLine();
                Console.Write("Enter Price of Product: ");
                product_price = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Stock Quantity: ");
                stock_quantity = float.Parse(Console.ReadLine());
                Console.WriteLine("Enter Minimum Stock Quantity: ");
                min_stock_quantity = float.Parse(Console.ReadLine());
                // ---------------- Making Product Object ----------------
                Product product = new Product(product_Name, product_category, product_price, stock_quantity, min_stock_quantity);
                product_list_Admin.Add(product);
                Console.Write("Do you want to add more products?(y/n)");
                char choice = char.Parse(Console.ReadLine());
                if (choice == 'y')
                {
                    input = true;
                }
                else
                {
                    input = false;
                }
            }
        }
        /*-------------- (Admin) View Products--------------*/
        static void view_Products(List<Product> product_list_Admin)
        {
            Console.Clear();
            int x = 1;
            int y = 1;
            Console.SetCursorPosition(x + 3, 0);
            Console.Write("Product");
            Console.SetCursorPosition(x + 23, 0);
            Console.Write("Category");
            Console.SetCursorPosition(x + 40, 0);
            Console.Write("Price");
            Console.SetCursorPosition(x + 50, 0);
            Console.Write("Stock Quantity");
            Console.SetCursorPosition(x + 70, 0);
            Console.Write("Min Stock Quantity");
            Console.WriteLine();
            for (int i = 0; i < product_list_Admin.Count; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(i + 1 + ". ");
                Console.SetCursorPosition(x + 3, y);
                Console.Write(product_list_Admin[i].name);
                Console.SetCursorPosition(x + 23, y);
                Console.Write(product_list_Admin[i].category);
                Console.SetCursorPosition(x + 40, y);
                Console.Write(product_list_Admin[i].price);
                Console.SetCursorPosition(x + 50, y);
                Console.Write(product_list_Admin[i].Stock_Quantity);
                Console.SetCursorPosition(x + 70, y);
                Console.Write(product_list_Admin[i].Min_Stock_Quantity);
                Console.WriteLine();
                y++;
            }
            Console.ReadLine();
        }
        /*------------------ (Admin) Highest Price Determining Function ---------------------*/
        static void highestPrice(List<Product> p)
        {
            Console.Clear();
            int index = 0;
            float start = p[0].price;
            for (int i = 0; i < p.Count; i++)
            {
                if (p[i].price > start)
                {
                    start = p[i].price;
                    index = i;
                }
            }
            Console.WriteLine("Product with Highest Price is: " + p[index].name);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        // <----------------------- (Admin) Read Admin Info  ---------------------->
        static void readadmin_info(List<Product> product_list_Admin, string admin_info_path)
        {
            if (File.Exists(admin_info_path))
            {
                StreamReader fileVariable = new StreamReader(admin_info_path, true);

                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string product_name = parseData(record, 1);
                    string category = parseData(record, 2);
                    int product_price = int.Parse(parseData(record, 3));
                    float stock_quantity = float.Parse(parseData(record, 4));
                    float min_stock_quantity = float.Parse(parseData(record, 5));
                    Product admin_data = new Product(product_name, category, product_price, stock_quantity, min_stock_quantity);
                    product_list_Admin.Add(admin_data);
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("File Not Exists");
            }
            // <----------------------- (Admin) Store Admin Info  ---------------------->
        }
        static void storeadmin_info(List<Product> product_list_Admin, string admin_info_path)
        {
            if (File.Exists(admin_info_path))
            {

                StreamWriter fileVariable = new StreamWriter(admin_info_path);
                for (int i = 0; i < product_list_Admin.Count; i++)
                {
                    fileVariable.WriteLine(product_list_Admin[i].name + "," + product_list_Admin[i].category + "," + product_list_Admin[i].price + "," + product_list_Admin[i].Stock_Quantity + "," + product_list_Admin[i].Min_Stock_Quantity);
                }
                fileVariable.Flush();
                fileVariable.Close();
            }
        }
        // <----------------------- (User) Buy Products  ---------------------->
        static void buy_Products(List<Product> product_list_Admin)
        {
            view_Products(product_list_Admin);            
        }
        static void take_input()
        {
            Console.WriteLine("Enter Product Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Product Quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Product Price: ");
            int price = int.Parse(Console.ReadLine());

        }

        /*-------------- Main Menu --------------*/
        static int menu()
        {
            int option;
            Console.WriteLine("1. SignIn");
            Console.WriteLine("2. SignUp");
            Console.WriteLine("Enter Option");
            option = int.Parse(Console.ReadLine());
            return option;
        }
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
        static bool readData(string path, List<MUser> users)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path); string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string name = parseData(record, 1);
                    string password = parseData(record, 2);
                    string role = parseData(record, 3);
                    MUser user = new MUser(name, password, role);
                    storeDataInList(users, user);
                }
                fileVariable.Close();
                return true;
            }
            return false;

        }
        static MUser takeInputWithoutRole()
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            if (name != null && password != null)
            {
                MUser user = new MUser(name, password);
                return user;
            }
            return null;

        }
        static MUser takeInputWithRole()
        {
            Console.WriteLine("Enter Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Role: ");
            string role = Console.ReadLine();
            if (name != null && password != null && role != null)
            {
                MUser user = new MUser(name, password, role);
                return user;
            }
            return null;
        }
        static void storeDataInList(List<MUser> users, MUser user)
        {
            users.Add(user);
        }
        static void storeDataInFile(string path, MUser user)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(user.username + "," + user.password + "," + user.role);
            file.Flush();
            file.Close();
        }
        static MUser signIn(MUser user, List<MUser> users)
        {
            foreach (MUser storedUser in users)
            {
                if (user.username == storedUser.username && user.password == storedUser.password)
                {
                    return storedUser;
                }
            }
            return null;
        }
    }


}
