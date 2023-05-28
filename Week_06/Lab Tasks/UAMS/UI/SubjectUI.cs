using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;

namespace UAMS.UI
{
    internal class SubjectUI
    {
        public static Subject takeInputForSubject()
        {
            string subject_code;
            string subject_type;
            int subject_creditHours;
            int subject_fees;
            Console.WriteLine("Enter Subject Code: ");
            subject_code = Console.ReadLine();
            Console.WriteLine("Enter Subject Type: ");
            subject_type = Console.ReadLine();
            Console.WriteLine("Enter Subject Credit Hours: ");
            subject_creditHours = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Subject Fees: ");
            subject_fees = int.Parse(Console.ReadLine());
            Subject subject = new Subject(subject_code, subject_type, subject_creditHours, subject_fees);
            return subject;
        }
        public static void viewSubjects(Student s)
        {
            if (s.regDegree != null)
            {
                Console.WriteLine("Sub Code\tSub Type");
                foreach (Subject sub in s.regDegree.subjects)
                {
                    Console.WriteLine(sub.code + "\t\t" + sub.type);
                }
            }
        }
        public static void registerSubjects(Student s)
        {
            Console.WriteLine("Enter how many subjects you want to register");
            int count = int.Parse(Console.ReadLine());
            for (int x = 0; x < count; x++)
            {
                Console.WriteLine("Enter the subject Code");
                string code = Console.ReadLine();
                bool Flag = false;
                foreach (Subject sub in s.regDegree.subjects)
                {
                    if (code == sub.code && !(s.regSubject.Contains(sub)))
                    {
                        if (s.regStudentSubject(sub))
                        {
                            Flag = true;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("A student cannot have more than 9 CH");
                        Flag = true;
                        break;
                    }
                }
                if (Flag == false)
                {
                    Console.WriteLine("Enter Valid Course");
                    x--;
                }
            }
        }
    }
}
