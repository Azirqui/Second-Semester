using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Business_App.BL;

namespace Business_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Data> data = new List<Data>();
            string path = "G:\\Nextcloud\\C#\\OOP Lab\\Week 02\\Self Work\\Business_App\\Credentails.txt";
            string admin_info_path = "G:\\Nextcloud\\C#\\OOP Lab\\Week 02\\Self Work\\Business_App\\Info_admin.txt";
            int x = 0;
            Credential[] ID = new Credential[10];
            int option;
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
            bool flag = false;
            int choice = 0;
            do
            {
                readData(path,ID,ref x);
                Console.Clear();
                option = Menu(ch2);
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string p = Console.ReadLine();
                    flag = signIn(n, p,ID);
                    if (flag == true)
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
                            }
                        }
                        storeadmin_info(data, admin_info_path);
                    }

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
        static void readData(string path, Credential[] ID,ref int x)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record= fileVariable.ReadLine()) != null)
                {
                    Credential id = new Credential(); 
                    id.username = parseData(record, 1);
                    id.password = parseData(record, 2);
                    ID[x]= id;
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
        static bool signIn(string n, string p, Credential[] ID)
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
                Console.WriteLine("Invalid User");
            }
            return flag;
        }
        static void readadmin_info(List<Data> data, string admin_info_path)
        {
            if (File.Exists(admin_info_path))
            {
                StreamReader fileVariable = new StreamReader(admin_info_path, true);

                string record;
                while ((record= fileVariable.ReadLine()) != null)
                {
                    Data admin_data = new Data();
                    admin_data.movie_name = parseData(record, 1);
                    admin_data.movie_price = float.Parse(parseData(record, 2));
                    admin_data.release_date = parseData(record, 3);
                    data.Add(admin_data);
                }
                fileVariable.Close();
            }
            else
            {
                Console.WriteLine("File Not Exists");
            }
        }
        static void storeadmin_info(List<Data> data,string admin_info_path)
        {
            if (File.Exists(admin_info_path))
            {

                StreamWriter fileVariable = new StreamWriter(admin_info_path);
                for (int i = 0; i < data.Count; i++)
                {
                    fileVariable.WriteLine(data[i].movie_name);
                    fileVariable.WriteLine(data[i].movie_price);
                    fileVariable.Write(data[i].release_date);
                }
                fileVariable.Flush();
                fileVariable.Close();
            }
        }
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
        static void addMovie(List<Data> data)
        {
            Data add_data = new Data();
            Console.WriteLine(" Enter Movie Name: ");
            add_data.movie_name = Console.ReadLine();
            Console.WriteLine(" Enter Price: ");
            add_data.movie_price =float.Parse(Console.ReadLine());
            Console.WriteLine(" Enter Releasing Date(dd/mm/yy): ");
            add_data.release_date =Console.ReadLine();
            data.Add(add_data);
            //data[x].movie_name = "dahkkd"
        }
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

       
        

