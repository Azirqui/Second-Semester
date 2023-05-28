using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_Tasks
{
    internal class Program
    {
        //1-Write a program that creates a new class of students.
        //class students
        //{
        //    public string name;
        //    public int roll_no;
        //    public float cgpa;

        //}
        //static void Main(string[] args)
        //{
        //    Console.Read();
        //}

        //2-Write the code that creates an object and assign values to a class object.
        //class students
        //{
        //    public string name;
        //    public int roll_no;
        //    public float cgpa;

        //}
        //static void Main(string[] args)
        //{
        //    students s1 = new students();
        //    s1.name = "Noman";
        //    s1.roll_no = 91;
        //    s1.cgpa = 3.25F;
        //    Console.WriteLine("Name: {0} Roll No: {1} CGPA: {2}",s1.name,s1.roll_no,s1.cgpa);
        //    Console.Read();
        //}


        //3-Write the code to create multiple class objects and assign values to all of them.
        //class students
        //{
        //    public string name;
        //    public int roll_no;
        //    public float cgpa;

        //}
        //static void Main(string[] args)
        //{
        //    // First Object
        //    students s1 = new students();
        //    s1.name = "Noman";
        //    s1.roll_no = 91;
        //    s1.cgpa = 3.25F;
        //    Console.WriteLine("Name: {0} Roll No: {1} CGPA: {2}", s1.name, s1.roll_no, s1.cgpa);
        //    // Second Object
        //    students s2 = new students();
        //    s2.name = "Ali";
        //    s2.roll_no = 99;
        //    s2.cgpa = 3.34F;
        //    Console.WriteLine("Name: {0} Roll No: {1} CGPA: {2}", s2.name, s2.roll_no, s2.cgpa);
        //    Console.Read();
        //}

        //4-Write the code to create a class object and take user name, roll number, and CGPA
        //  from the user and store them in the class object.
        class students
        {
            public string name;
            public int roll_no;
            public float cgpa;

        }
        static void Main(string[] args)
        {
            // First Object
           students s1 = new students();
            Console.WriteLine("Enter Name: ");
            s1.name = Console.ReadLine();
            Console.WriteLine("Enter Roll No: ");
            s1.roll_no = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter CGPA: ");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Name: {0} Roll No: {1} CGPA: {2}", s1.name, s1.roll_no, s1.cgpa);      
            Console.Read();
        }
    }
}
