using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_01.BL
{
    internal class Student
    {
        /*-------------- Member Functions --------------*/
        public string Name;
        public int rollNumber;
        public float cGPA;
        public int matricMarks;
        public int fscMarks;
        public int ecatMarks;
        public string homeTown;
        public bool isHostelite;
        public bool isTakingScholarship;
        /*-------------- Parameterized Constructor --------------*/
        public Student(string name,int roll_number,float cgpa,int matric_marks,int fsc_marks,int ecat_marks,string home_town,bool is_hostelite,bool is_taking_scholarship)
        {
            this.Name = name;
            this.rollNumber = roll_number;
            this.cGPA= cgpa;
            this.matricMarks = matric_marks;
            this.fscMarks = fsc_marks;
            this.ecatMarks = ecat_marks;
            this.homeTown = home_town;
            this.isHostelite = is_hostelite;
            this.isTakingScholarship= is_taking_scholarship;
        }
        /*-------------- Calculate Merit Function --------------*/
        public float calculateMerit()
        {
            float merit;
            merit = (40 * ecatMarks)/400.0F + (60 * fscMarks)/1100.0F;
            return merit;
        }
        /*-------------- Scholarship Eligibility Check Function --------------*/
        public bool isEligibleforScholarship(float meritPercentage)
        {
            bool eligible_for_scholarship;
            if(meritPercentage > 80 && isHostelite == true)
            {
                eligible_for_scholarship = true;
            }
            else
            {
                eligible_for_scholarship = false;
            }
            return eligible_for_scholarship;
        }


    }
}
