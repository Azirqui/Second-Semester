using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Business_App.BL;

namespace Business_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Data> data = new List<Data>();
            string path = "G:\\Nextcloud\\C#\\OOP Lab\\Week 03\\PD\\Business_App\\Credentails.txt";
            string admin_info_path = "G:\\Nextcloud\\C#\\OOP Lab\\Week 03\\PD\\Business_App\\Info_admin.txt";
            List<MUser> users = new List<MUser>();
            int option;
            bool check = readData(path, users);
            //----------- Style Variables----------
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            //int ascii = 254;
            //int ascii2 = 219;
            //char ch2 = (char)ascii2;
            //char ch = (char)ascii;
            char ch2 = (char)254;
            char ch = (char)219;
            //Console.WriteLine(ch);
            //Console.ReadKey();
            bool close = true;
            readadmin_info(data, admin_info_path);
            int choice = 0;
            if (check)
            { Console.WriteLine("Data Loaded SuccessFully"); }
            else
            {
                Console.WriteLine("Data Not Loaded");
            }
            Console.ReadKey();
            do
            {
                Console.Clear();
                option = Menu(ch2);
                Console.Clear();
                if (option == 1)
                {
                    MUser user = takeInputWithoutRole();
                    if (user != null)
                    {
                        user = signIn(user, users);
                        if (user == null)
                        { Console.WriteLine("Invalid User"); }
                        else if (user.isAdmin())
                        {
                            while (close)
                            {
                                Console.Clear();
                                choice = admin_page();
                                if (choice == 1)
                                {
                                    addMovie(data);
                                }
                                if (choice == 2)
                                {
                                    removeMovie(data);
                                }
                                if (choice == 3)
                                {
                                    updatePrices(data);
                                }
                                if (choice == 5)
                                {
                                    Console.Clear();
                                    ticketDetails(data);
                                    Console.ReadKey();
                                }
                                Console.ReadKey();

                                if (choice == 9)
                                {
                                    close = false;
                                    break;
                                }
                            }
                        }
                        else
                        { Console.WriteLine("User Menu"); }

         
                       
                        
                        storeadmin_info(data, admin_info_path);
                    }

                }
                else if (option == 2)
                {
                    MUser user = takeInputWithRole();
                    if (user != null)
                    {
                        storeDataInFile(path, user);
                        storeDataInList(users, user);
                    }
                }
                Console.ReadKey();
            }
            while (option < 3);
            {
                Console.ReadKey();
            }

        }

        // <-----------------------  Admin Menu  ---------------------->
        static int admin_page()
        {
            int choice;
            Console.WriteLine("Enter Your Choice!");
            Console.WriteLine("1. Add Movie ");
            Console.WriteLine("2. Remove Movie");
            Console.WriteLine("3. Update Prices");
            Console.WriteLine("4. Add Discount");
            Console.WriteLine("5. Tickets Details");
            Console.WriteLine("6. Implement Tax");
            Console.WriteLine("7. Calculate Revenue");
            Console.WriteLine("8. Back TO Main Page...");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }

        // <-----------------------  Menu Function  ---------------------->
        static int Menu(char ch2)
        {
            int option;
            loadScreen(ch2);
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
        static bool readData(string path, List<MUser> users)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
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
        // <-----------------------  Take Input Without Role  ---------------------->
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
        // <-----------------------  Take Input With Role  ---------------------->
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
        // <-----------------------  Store data in list  ---------------------->
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
        // <-----------------------  signIn Function  ---------------------->
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
        // <-----------------------  Read Admin Info  ---------------------->
        static void readadmin_info(List<Data> data, string admin_info_path)
        {
            if (File.Exists(admin_info_path))
            {
                StreamReader fileVariable = new StreamReader(admin_info_path, true);

                string record;
                while ((record= fileVariable.ReadLine()) != null)
                {
                    string movie_name = parseData(record, 1);
                    float movie_price = float.Parse(parseData(record, 2));
                    string release_date = parseData(record, 3);
                    Data admin_data = new Data(movie_name, movie_price, release_date);
                    data.Add(admin_data);
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("File Not Exists");
            }
            // <-----------------------  Store Admin Info  ---------------------->
        }
        static void storeadmin_info(List<Data> data,string admin_info_path)
        {
            if (File.Exists(admin_info_path))
            {

                StreamWriter fileVariable = new StreamWriter(admin_info_path);
                for (int i = 0; i < data.Count; i++)
                {
                    fileVariable.WriteLine(data[i].movie_name + "," + data[i].movie_price + "," + data[i].release_date);
                }
                fileVariable.Flush();
                fileVariable.Close();
            }
        }
        // <-----------------------  Tickets Details  ---------------------->
        static void ticketDetails(List<Data> data)
        {
            int x = 1;
            int y = 12;
            Console.Write("Movie\t\tPrice\t\tDate\t\t");
            Console.WriteLine();
            for (int i = 0; i < data.Count; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(i + 1+ ". ");
                Console.SetCursorPosition(x + 3, y);
                Console.Write(data[i].movie_name);
                Console.SetCursorPosition(x + 23, y);
                Console.Write(data[i].movie_price);
                Console.SetCursorPosition(x + 40, y);
                Console.Write(data[i].release_date);
                Console.WriteLine();
                y++;
            }
        }
        // <-----------------------  Add Movie  ---------------------->
        static void addMovie(List<Data> data)
        {
            
            Console.WriteLine(" Enter Movie Name: ");
            string movie_name = Console.ReadLine();
            Console.WriteLine(" Enter Price: ");
            float movie_price =float.Parse(Console.ReadLine());
            Console.WriteLine(" Enter Releasing Date(dd/mm/yy): ");
            string release_date =Console.ReadLine();
            Data add_data = new Data(movie_name,movie_price,release_date);
            data.Add(add_data);
            //data[x].movie_name = "dahkkd"
        }
        // <-----------------------  Remove Movie  ---------------------->
        static void removeMovie(List<Data> data)
        {
            string remove_movie;
            bool flag;
            Console.WriteLine("Enter name of movie to be removed: ");
            remove_movie=Console.ReadLine();
            for (int s = 0; s < data.Count; s++)
            {
                if (data[s].movie_name == remove_movie)
                {
                    data.Remove(data[s]);
                    break;
                }
            }
            if (flag = false)
            {
               Console.WriteLine("No information...");
            }
        }
        // <-----------------------  Update Prices  ---------------------->
        static void updatePrices(List<Data> data)
        {
            string search_movie;
            Console.WriteLine("Enter Movie Name: ");
            search_movie = Console.ReadLine();
            for (int s = 0; s < data.Count; s++)
            {
                if (data[s].movie_name == search_movie)
                {
                    Console.WriteLine("Enter Price: ");
                    data[s].movie_price = float.Parse(Console.ReadLine());
                }
            }
        }

        //-------------------------Style Screen Function-----------------------
        static void loadScreen(char ch2)
        {
            Console.WriteLine("\x231A");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            //StyleLine(Q);
            Console.WriteLine();
            Console.WriteLine("\t" + ch2 + ch2 + "                                                                        " + ch2 + ch2);
            Console.WriteLine("\t" + ch2 + ch2 + "    H-H-H-H-H-H-H-H-H      BBBBBBBBBBBBBBBB              SSSSSSSS       " + ch2 + ch2);
            Console.WriteLine("\t" + ch2 + ch2 + "    H:::::::::::::::H      B::::::::::::::::B           S::SSSSS::S     " + ch2 + ch2);
            Console.WriteLine("\t" + ch2 + ch2 + "    H-H-H-H:::H-H_H_H      BB::::::BBBBB:::::B         S::S     SSSS    " + ch2 + ch2);
            Console.WriteLine("\t" + ch2 + ch2 + "          H:::H               B::::B    B:::::B         S::S            " + ch2 + ch2);
            Console.WriteLine("\t" + ch2 + ch2 + "          H:::H               B::::BBBBB:::::B           S::SSSSSSS     " + ch2 + ch2);
            Console.WriteLine("\t" + ch2 + ch2 + "          H:::H               B::::::::::::BB              SSSSSS::S    " + ch2 + ch2);
            Console.WriteLine("\t" + ch2 + ch2 + "          H:::H               B::::BBBBB:::::B                   S::S   " + ch2 + ch2);
            Console.WriteLine("\t" + ch2 + ch2 + "          H:::H               B::::B    B:::::B         SSSS     S::S   " + ch2 + ch2);
            Console.WriteLine("\t" + ch2 + ch2 + "          H:::H            BB::::::BBBBB:::::B          S::SSSSS::S     " + ch2 + ch2);
            Console.WriteLine("\t" + ch2 + ch2 + "          H:::H            B::::::::::::::::B            SSSSSSSS       " + ch2 + ch2);
            Console.WriteLine("\t" + ch2 + ch2 + "          HHHHH            BBBBBBBBBBBBBBBB                             " + ch2 + ch2);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

       
        

