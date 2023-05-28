using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM_03_1.BL
{
    /*Task: Write a program that creates a new class of students and try printing the values of
             attributes without assigning them any values.*/

    //internal class Student
    //{
    //    public string sname;
    //    public float matricMarks;
    //    public float fscMarks;
    //    public float ecatMarks;
    //    public float aggregate;
    //}

    /*Task: Write the code to create a default constructor that prints “Default Constructor
            Called”.*/

    //internal class Student
    //{
    //    public Student()       
    //    {
    //        Console.WriteLine("Default Constructor Called");
    //    }

    //    public string sname;
    //    public float matricMarks;
    //    public float fscMarks;
    //    public float ecatMarks;
    //    public float aggregate;
    //}

    /*Task: Write the code to create a default constructor that assigns a default value to one of
            the attributes.*/

    internal class Student
    {
        public Student()
        {
            sname = "Jill";
        }

        public string sname;
        public float matricMarks;
        public float fscMarks;
        public float ecatMarks;
        public float aggregate;
    }
}
