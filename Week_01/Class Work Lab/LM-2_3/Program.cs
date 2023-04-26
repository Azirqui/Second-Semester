using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM_2_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "E:\\Nextcloud\\C#\\OOP Lab\\Week 01\\Class Work\\LM-2_3\\File.txt";
            if(File.Exists(path))
            {
                StreamReader fileVariable= new StreamReader(path);
                string record;
                while((record=fileVariable.ReadLine()) != null)
                {
                    Console.WriteLine(record);
                }
                fileVariable.Close();   
            }
            else
            {
                Console.WriteLine("Not Exists!!!");
            }
            Console.ReadKey();
        }
    }
}
