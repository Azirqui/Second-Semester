using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem_01.BL;

namespace Problem_01
{
    internal class Program
    {
        /*------------------ Main Function ----------------*/
        static void Main(string[] args)
        {
            List<Ship> shipList = new List<Ship>();
            bool running = true;
            int option;
            while (running)
            {
                Console.Clear();
                option = Menu();
                if (option == 1)
                {
                    Console.Clear();
                    addShip(shipList);
                }
                if (option == 2)
                {
                    Console.Clear();
                    Console.WriteLine("Enter Ship Serial Number to find its position: ");
                    string serial_number = Console.ReadLine();
                    viewShip_Position(shipList, serial_number);
                }
                if (option == 3)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the ship latitude_degree: ");
                    int latitude_degree = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the ship latitude_minute: ");
                    float latitude_minute = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the ship latitude_direction: ");
                    char latitude_direction = char.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the ship longitude_degree: ");
                    int longitude_degree = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the ship longitude_minute: ");
                    float longitude_minute = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the ship longitude_direction: ");
                    char longitude_direction = char.Parse(Console.ReadLine());

                    viewShip_serialNumber(shipList, latitude_degree, latitude_minute, latitude_direction, longitude_degree, longitude_minute, longitude_direction);
                }
                if (option == 4)
                {
                    Console.Clear();
                    Console.WriteLine("Enter Ship’s serial number whose position you want to change: ");
                    string serial_number = Console.ReadLine();
                    Console.WriteLine("Enter the ship latitude_degree: ");
                    int latitude_degree = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the ship latitude_minute: ");
                    float latitude_minute = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the ship latitude_direction: ");
                    char latitude_direction = char.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the ship longitude_degree: ");
                    int longitude_degree = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the ship longitude_minute: ");
                    float longitude_minute = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the ship longitude_direction: ");
                    char longitude_direction = char.Parse(Console.ReadLine());
                    changeShip_Position(serial_number, shipList, latitude_degree, latitude_minute, latitude_direction, longitude_degree, longitude_minute, longitude_direction);
                }
                if (option == 5)
                {
                    running = false;
                }
            }
        }
        /*------------------ Menu Function ----------------*/
        static int Menu()
        {
            int choice;
            Console.WriteLine("1. Add Ship");
            Console.WriteLine("2. View Ship Position");
            Console.WriteLine("3. View Ship Serial Number");
            Console.WriteLine("4. Change Ship Position");
            Console.WriteLine("5. Exit");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        /*------------------ Add Ship Function ----------------*/
        static void addShip(List<Ship> shipList)
        {
            Console.WriteLine("Enter Ship Number: ");
            string shipNumber = Console.ReadLine();
            Console.WriteLine("Enter Latitude’s Degree: ");
            int latitude_degree = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Latitude’s Minute: ");
            float latitude_minute = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Latitude’s Direction: ");
            char latitude_direction = char.Parse(Console.ReadLine());
            Console.WriteLine("Enter Longitude’s Degree: ");
            int longitude_degree = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Longitude’s Minute: ");
            float longitude_minute = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Longitude’s Direction: ");
            char longitude_direction = char.Parse(Console.ReadLine());
            Angle latitude = new Angle(latitude_degree, latitude_minute, latitude_direction);
            Angle longitude = new Angle(longitude_degree, longitude_minute, longitude_direction);
            Ship ship = new Ship(shipNumber, latitude, longitude);
            shipList.Add(ship);
        }
        /*------------------ View Ship Position Function ----------------*/
        static void viewShip_Position(List<Ship> shipList, string serial_number)
        {
            foreach (Ship ship in shipList)
            {
                if (ship.shipNumber == serial_number)
                {
                    ship.longitude.print_angle();
                    Console.WriteLine();
                    ship.latitude.print_angle();
                    Console.ReadKey();
                }
            }
        }
        /*------------------ View Ship Serial Number Function ----------------*/
        static void viewShip_serialNumber(List<Ship> shipList, int latitude_degree, float latitude_minute, char latitude_direction, int longitude_degree, float longitude_minute, char longitude_direction)
        {
            foreach (Ship ship in shipList)
            {
                if (ship.latitude.degrees == latitude_degree && ship.latitude.minutes == latitude_minute && ship.latitude.direction == latitude_direction && ship.longitude.degrees == longitude_degree && ship.longitude.minutes == longitude_minute && ship.longitude.direction == longitude_direction)
                {
                    Console.WriteLine("Ship's Serial Number is: " + ship.shipNumber);
                }
            }
            Console.ReadKey();
        }
        /*------------------ Change Ship Position Function ----------------*/
        static void changeShip_Position(string serial_number, List<Ship> shipList, int latitude_degree, float latitude_minute, char latitude_direction, int longitude_degree, float longitude_minute, char longitude_direction)
        {
            foreach (Ship ship in shipList)
            {
                if (ship.shipNumber == serial_number)
                {
                    ship.latitude.degrees = latitude_degree;
                    ship.latitude.minutes = latitude_minute;
                    ship.latitude.direction = latitude_direction;
                    ship.longitude.degrees = longitude_degree;
                    ship.longitude.minutes = longitude_minute;
                    ship.longitude.direction = longitude_direction;
                }
            }
        }
    }
}
