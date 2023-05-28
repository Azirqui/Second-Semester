using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01.BL
{
    internal class DegreeProgram
    {
        public string degreeName;
        public float degreeDuration;
        public List<Subject> subjects = new List<Subject>();
        public int seats;
        public DegreeProgram(string degreeName, float degreeDuration, int seats)
        {
            this.degreeName = degreeName;
            this.degreeDuration = degreeDuration;
            this.seats = seats;
            //subjects = new List<Subject>();
        }
        public int calculateCreditHours()
        {
            int credit_hours = 0;
            foreach (Subject subject in subjects)
            {
                credit_hours = credit_hours + subject.creditHours;
            }
            return credit_hours;
        }
        public bool isSubjectExists(Subject sub)
        {
            bool condition = false;
            if (sub.code != null)
            {
                foreach (Subject subject in subjects)
                {
                    if (subject.code == sub.code)
                    {
                        condition = true;
                        break;
                    }                   
                }
            }
            return condition;
        }
        public void AddSubject(Subject s)
        {
            int creditHours =
            calculateCreditHours();
            if (creditHours + s.creditHours <= 20)
            {
                subjects.Add(s);
            }
            else
            {
                Console.WriteLine("20 credit hour limit exceeded");
            }
        }
    }
}

