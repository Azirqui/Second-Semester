using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM_2_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "E:\\Nextcloud\\C#\\OOP Lab\\Week 01\\Class Work\\LM-2_4\\File.txt";
            StreamWriter fileVariable=new StreamWriter(path,true);
            fileVariable.WriteLine("Hello!!!");
            fileVariable.Flush();
            fileVariable.Close();
        }
    }
}