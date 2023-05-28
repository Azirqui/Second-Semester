using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM_03_2.BL
{
    internal class Student
    {
        public Student(string n) 
        {
            sname = n;
        }

        public string sname;
        public float matricMarks;
        public float fscMarks;
        public float ecatMarks;
        public float aggregate;
    }
}
