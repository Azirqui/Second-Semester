using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using UAMS.DL;

namespace UAMS.UI
{
    internal class DegreeProgramUI
    {
        public static DegreeProgram takeInputForDegree()
        {
            string degree_name;
            float degree_duration;
            int degree_seats;
            Console.WriteLine("Enter Degree Name: ");
            degree_name = Console.ReadLine();
            Console.WriteLine("Enter Degree Duration: ");
            degree_duration = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Seats for Degree: ");
            degree_seats = int.Parse(Console.ReadLine());
            DegreeProgram degProg = new DegreeProgram(degree_name, degree_duration, degree_seats);
            Console.WriteLine("Enter How many Subjects to Enter: ");
            int count = int.Parse(Console.ReadLine());
            for (int x = 0; x < count; x++)
            {
                Subject s = SubjectUI.takeInputForSubject();
                if (degProg.AddSubject(s))
                {
                    // These are done here because we did not add a separate option to add only the Subjects.
                    if (!(SubjectDL.subjectList.Contains(s)))
                    {
                        SubjectDL.addSubjectIntoList(s);
                        SubjectDL.storeintoFile("subject.txt", s);
                    }
                    Console.WriteLine("Subject Added");
                }
                else
                {
                    Console.WriteLine("Suject not Added");
                    Console.WriteLine("20 credit hour limit exceeded");
                    x--;
                }
            }
            return degProg;
        }
        public static void viewDegreePrograms()
        {
            foreach (DegreeProgram dp in DegreeProgramDL.programList)
            {
                Console.WriteLine(dp.degreeName);
            }
        }
    }
}
