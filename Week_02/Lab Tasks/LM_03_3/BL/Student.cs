using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM_03_3.BL
{
    internal class Student
    {
        public Student()
        {
            Console.WriteLine("Default Constructor");
        }
        public Student(Student s)
        {
            sname = s.sname;
            matricMarks = s.matricMarks;
            fscMarks = s.fscMarks;
            ecatMarks = s.ecatMarks;
            aggregate = s.aggregate;
        }

        public string sname;
        public float matricMarks;
        public float fscMarks;
        public float ecatMarks;
        public float aggregate;
    }
}
