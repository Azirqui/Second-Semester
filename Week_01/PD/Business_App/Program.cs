using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Business_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "G:\\Nextcloud\\C#\\OOP Lab\\Week 01\\PD\\Business_App\\Credentails.txt";
            string admin_info_path = "G:\\Nextcloud\\C#\\OOP Lab\\Week 01\\PD\\Business_App\\Info_admin.txt";
            string[] names = new string[5];
            string[] passwords = new string[5];
            string[] movie_name = new string[20];
            float[] movie_price = new float[20];
            string[] release_date = new string[20];
            int index=0;
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
            readadmin_info(movie_name,movie_price,release_date, admin_info_path,ref index);
            bool flag = false;
            int choice=0;
            do
            {
                readData(path, names, passwords);
                Console.Clear();
                option = Menu(ch2);
                Console.Clear();
                if (option == 1)
                {
                    Console.WriteLine("Enter Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string p = Console.ReadLine();
                    flag = signIn(n, p, names, passwords);
                    if (flag == true)
                    {
                        while(close)
                        {
                        Console.Clear();
                        choice = admin_page();
                        if(choice==1)
                        {
                            addMovie(movie_name, movie_price, release_date,ref index);
                        }
                        if(choice==2)
                            {
                                removeMovie(movie_name,movie_price,release_date, ref index);
                            }
                        if(choice==3)
                            {
                                updatePrices(movie_name,movie_price,release_date, ref index);
                            }
                        if(choice==5)
                        {
                            Console.Clear();
                            ticketDetails(movie_name, movie_price, release_date, index);
                        }
                            Console.ReadKey();
                        }
                        if(choice==9)
                        {
                            close = false;
                        }
                        storeadmin_info(movie_name, movie_price, release_date, admin_info_path, ref index);
                    }

                }
                else if (option == 2)
                {
                    Console.WriteLine("Enter New Name: ");
                    string n = Console.ReadLine();
                    Console.WriteLine("Enter New Password: ");
                    string p = Console.ReadLine();
                    signUp(path, n, p);
                }
                Console.ReadKey();
            }
            while (option < 3);
            
            
            
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
        static void readData(string path, string[] names, string[] passwords)
        {
            int x = 0;
            if (File.Exists(path))
            {

                StreamReader fileVariable = new StreamReader(path, true);

                string record = fileVariable.ReadLine();
                while (record != null)
                {
                    names[x] = parseData(record, 1);
                    passwords[x] = parseData(record, 2);
                    x++;
                    if (x >= 5)
                    {
                        break;
                    }
                    fileVariable.Close();
                }
            }
            else
            {
                Console.WriteLine("File Not Exists");
            }
        }
        // <-----------------------  signUp Function  ---------------------->
        static void signUp(string path, string n, string p)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(n + "," + p);
            file.Flush();
            file.Close();
        }
        // <-----------------------  signIn Function  ---------------------->
        static bool signIn(string n, string p, string[] names, string[] passwords)
        {
            bool flag = false;
            for (int x = 0; x < 5; x++)
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
            return flag;
            Console.ReadKey();
        }
        static void readadmin_info(string[] movie_name,float[] movie_price,string[] release_date,string admin_info_path,ref int index)
        {
            if (File.Exists(admin_info_path))
            {

                StreamReader fileVariable = new StreamReader(admin_info_path, true);

                string movie_file = "";
                while (movie_file != null)
                {
                    movie_file=fileVariable.ReadLine();
                    string price_file= fileVariable.ReadLine();
                    string date_file = fileVariable.ReadLine();
                    if(price_file != null)
                    {
                    movie_name[index] = movie_file;
                    movie_price[index] = float.Parse(price_file);
                    release_date[index] = date_file;
                    index++;  

                    }
                }
            }
            else
            {
                Console.WriteLine("File Not Exists");
            }
        }
        static void storeadmin_info(string[] movie_name, float[] movie_price, string[] release_date, string admin_info_path, ref int index)
        {
            if (File.Exists(admin_info_path))
            {

                StreamWriter fileVariable = new StreamWriter(admin_info_path);
                for (int i = 0; i < index; i++)
                {
                    Console.WriteLine(movie_name[i]);
                    Console.WriteLine();
                    Console.WriteLine(movie_price[i]);
                    Console.WriteLine();
                    Console.WriteLine(release_date[i]);
                    Console.WriteLine();
                }
                fileVariable.Flush();
                fileVariable.Close();
            }
        }
        static void ticketDetails(string[] movie_name, float[] movie_price, string[] release_date,int index)
        {
            int x = 1;
            int y = 12;
            Console.Write("Movie\t\tPrice\t\tDate\t\t");
            Console.WriteLine();
            for (int i = 0; i < index; i++)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(i + 1+ ". ");
                Console.SetCursorPosition(x + 3, y);
                Console.Write(movie_name[i]);
                Console.SetCursorPosition(x + 23, y);
                Console.Write(movie_price[i]);
                Console.SetCursorPosition(x + 40, y);
                Console.Write(release_date[i]);
                Console.WriteLine();
                y++;
            }
        }
        static void addMovie(string[] movie_name, float[] movie_price, string[] release_date, ref int index)
        {
            Console.WriteLine(" Enter Movie Name: ");
            movie_name[index] = Console.ReadLine();
            Console.WriteLine(" Enter Price: ");
            movie_price[index]=float.Parse(Console.ReadLine());
            Console.WriteLine(" Enter Releasing Date(dd/mm/yy): ");
            release_date[index]=Console.ReadLine();
            index++;
        }
        static void removeMovie(string[] movie_name, float[] movie_price, string[] release_date, ref int index)
        {
            string remove_movie;
            bool flag;
            Console.WriteLine("Enter name of movie to be removed: ");
            remove_movie=Console.ReadLine();
            for (int s = 0; s < index; s++)
            {
                if (movie_name[s] == remove_movie)
                {
                    for (int t = s; t < index - 1; t++)
                    {
                        flag = true;
                        movie_name[t] = movie_name[t + 1];
                        movie_price[t] = movie_price[t + 1];
                        release_date[t] = release_date[t + 1];
                    }
                    index--;
                    break;
                }
            }
            if (flag = false)
            {
               Console.WriteLine("No information...");
            }
        }
        static void updatePrices(string[] movie_name, float[] movie_price, string[] release_date, ref int index)
        {
            string search_movie;
            Console.WriteLine("Enter Movie Name: ");
            search_movie=Console.ReadLine();
            for (int s = 0; s < index; s++)
            {
                if (movie_name[s] == search_movie)
                {
                    Console.WriteLine("Enter Price: ");
                    movie_price[s]=float.Parse(Console.ReadLine());
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

       
        

