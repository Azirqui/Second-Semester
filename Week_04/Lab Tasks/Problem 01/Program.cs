using Problem_01.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // --------------- Taking Input -----------------
            Console.Write("Enter Name: ");
            string name=Console.ReadLine();
            Console.Write("Enter Roll Number: ");
            int roll_number=int.Parse(Console.ReadLine());
            Console.Write("Enter CGPA: ");
            float cgpa=float.Parse(Console.ReadLine());
            Console.Write("Enter Matric Marks: ");
            int matric_marks=int.Parse(Console.ReadLine());
            Console.Write("Enter Inter Marks: ");
            int fsc_marks=int.Parse(Console.ReadLine());
            Console.Write("Enter Ecat Marks: ");
            int ecat_marks=int.Parse(Console.ReadLine());
            Console.Write("Enter Home Town: ");
            string home_town=Console.ReadLine();
            Console.Write("Enter Hostelize Status(true/false): ");
            bool is_hostelite=bool.Parse(Console.ReadLine());
            Console.Write("Enter Scholarship Status(true/false): ");
            bool is_taking_scholarship=bool.Parse(Console.ReadLine());
            // --------------- Creating Object -----------------
            Student s1 = new Student(name,roll_number,cgpa,matric_marks,fsc_marks,ecat_marks,home_town,is_hostelite,is_taking_scholarship);

            Console.Clear();
            float merit = s1.calculateMerit();
            Console.WriteLine("Merit is: " + merit);
            bool eligible_for_scholarship = s1.isEligibleforScholarship(merit);
            if(eligible_for_scholarship == true)
            {
                Console.WriteLine("Eligile For Scholarship!");
            }
            else
            {
                Console.WriteLine("Not Eligile For Scholarship!");
            }
            Console.ReadKey();
        }
    }
}
