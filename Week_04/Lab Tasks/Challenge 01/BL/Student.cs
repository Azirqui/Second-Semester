using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Challenge_01.BL
{
    internal class Student
    {      
            public string name;
            public int age;
            public double fscMarks;
            public double ecatMarks;
            public double merit;
            public List<DegreeProgram> preferences;
            public List<Subject> regSubject;
            public DegreeProgram regDegree;
        public Student(string name, int age, double fscMarks, double ecatMarks,List<DegreeProgram> preferences)
        {
            this.name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            this.ecatMarks = ecatMarks;

        }
        public void viewSubjects()
        {
            foreach (Subject members in regSubject)
            {
            Console.WriteLine(members.code,members.type,members.creditHours,members.subjectFees);

            }
        }
        public void calculateMerit()
        {
            merit = (40 * ecatMarks) / 400.0F + (60 * fscMarks) / 1100.0F;
        } 
        public int getCreditHours()
        {
            int sum =0 ;
            foreach (Subject regsubject  in regSubject)
            {
                sum = sum+ regsubject.creditHours;
            }
            return sum;
        }
        public float calculateFee()
        {
            int fee = 0;
            foreach (Subject regsubject in regSubject)
            {
                fee = fee + regsubject.subjectFees;
            }
            return fee;
        }
        public void regStudentSubject(Subject s)
        {
            int stCH = getCreditHours();
            if (regDegree != null && regDegree.isSubjectExists(s) && stCH + s.creditHours <= 9)
            {
                regSubject.Add(s);
            }
            else
            {
                Console.WriteLine("A student cannot have more than 9 CH or Wrong Subject");
            }
        }
    }
}
