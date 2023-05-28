using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LM_03_2_SAT1_a_.BL
{
    internal class Student
    {
        public Student(string n, float m, float p, float o, float q)
        {
            sname = n;
            matricMarks = m;
            fscMarks = p;
            ecatMarks = o;
            aggregate = q;
        }

        public string sname;
        public float matricMarks;
        public float fscMarks;
        public float ecatMarks;
        public float aggregate;
    }
}
