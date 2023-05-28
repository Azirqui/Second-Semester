using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;

namespace UAMS
{
    internal class Program
    {
        static List<Student> studentList = new List<Student>();
        static List<DegreeProgram> programList = new List<DegreeProgram>();

        static void Main(string[] args)
        {
            int option;
            do
            {
                option = Menu();
                clearScreen();
                if (option == 1)
                {
                    if (programList.Count > 0)
                    {
                        Student s = takeInputForStudent();
                        addIntoStudentList(s);
                    }
                }
                else if (option == 2)
                {
                    DegreeProgram d = takeInputForDegree();
                    addIntoDegreeList(d);
                }
                else if (option == 3)
                {
                    List<Student> sortedStudentList = new List<Student>();
                    sortedStudentList = sortStudentByMerit();
                    giveAdmission(sortedStudentList);
                    printStudent();
                }
                else if (option == 4)
                {
                    viewRegisteredStudents();
                }
                else if (option == 5)
                {
                    string degName;
                    Console.WriteLine("Enter Degree Name: ");
                    degName = Console.ReadLine();
                    viewStudentInDegree(degName);
                }
                else if (option == 6)
                {
                    Console.Write("Enter the Student Name: ");
                    string name = Console.ReadLine();
                    Student s = StudentPresent(name);
                    if (s != null)
                    {
                        viewSubjects(s);
                        registerSubjects(s);
                    }
                }
                else if (option == 7)
                {
                    calculateFeeForAll();
                }
                clearScreen();
            }
            while (option != 8);
            Console.ReadKey();
        }
        static Student StudentPresent(string name)
        {
            foreach (Student s in studentList)
            {
                if (name == s.name && s.regDegree != null)
                {
                    return s;
                }
            }
            return null;
        }
        static void calculateFeeForAll()
        {
            foreach (Student s in studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + "has" + s.calculateFee() + "fees");
                }
            }
        }
        static void registerSubjects(Student s)
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
                        s.regStudentSubject(sub);
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
        static List<Student> sortStudentByMerit()
        {
            List<Student> sortedStudentlist = new List<Student>();
            foreach (Student s in studentList)
            {
                s.calculateMerit();
            }
            sortedStudentlist = studentList.OrderByDescending(o => o.merit).ToList();
            return sortedStudentlist;
        }
        static void giveAdmission(List<Student> sortedStudentList)
        {
            foreach (Student s in sortedStudentList)
            {
                foreach (DegreeProgram d in s.preferences)
                {
                    if (d.seats > 0 && s.regDegree == null)
                    {
                        s.regDegree = d;
                        d.seats--;
                        break;
                    }
                }
            }
        }
        static void printStudent()
        {
            foreach (Student s in studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + " got Admission in " + s.regDegree.degreeName);
                }
                else
                {
                    Console.WriteLine(s.name + " did not get Admission");
                }
            }
        }
        static void clearScreen()
        {
            Console.WriteLine("Press any key to Continue..");
            Console.ReadKey();
            Console.Clear();
        }
        static void viewStudentInDegree(string degName)
        {
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            foreach (Student s in studentList)
            {
                if (s.regDegree != null)
                {
                    if (degName == s.regDegree.degreeName)
                    {
                        Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);
                    }
                }
            }
        }
        static void viewRegisteredStudents()
        {
            Console.WriteLine("Name\tFSC\tEcat\tAge");
            foreach (Student s in studentList)
            {
                if (s.regDegree != null)
                {
                    Console.WriteLine(s.name + "\t" + s.fscMarks + "\t" + s.ecatMarks + "\t" + s.age);
                }
            }
        }
        static void addIntoDegreeList(DegreeProgram d)
        {
            programList.Add(d);
        }
        static DegreeProgram takeInputForDegree()
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
                degProg.AddSubject(takeInputForSubject());
            }
            return degProg;
        }
        static Subject takeInputForSubject()
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
        static void addIntoStudentList(Student s)
        {
            studentList.Add(s);
        }
        static Student takeInputForStudent()
        {
            string name;
            int age;
            double fscMarks;
            double ecatMarks;
            List<DegreeProgram> preferences = new List<DegreeProgram>();
            Console.WriteLine("Enter Student Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter Student Age: ");
            age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student Fsc Marks: ");
            fscMarks = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student Ecat Marks: ");
            ecatMarks = double.Parse(Console.ReadLine());
            Console.WriteLine("Available Degree Programs: ");
            viewDegreePrograms();
            Console.WriteLine("Enter how many preferences to Enter: ");
            int Count = int.Parse(Console.ReadLine());
            for (int x = 0; x < Count; x++)
            {
                string degName = Console.ReadLine();
                bool flag = false;
                foreach (DegreeProgram dp in programList)
                {
                    if (degName == dp.degreeName && !(preferences.Contains(dp)))
                    {
                        preferences.Add(dp);
                        flag = true;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Enter Valid Degree Program Name");
                    x--;
                }
            }
            Student s = new Student(name, age, fscMarks, ecatMarks, preferences);
            return s;
        }
        static void viewDegreePrograms()
        {
            foreach (DegreeProgram dp in programList)
            {
                Console.WriteLine(dp.degreeName);
            }
        }
        static void header()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("                    UAMS                   ");
            Console.WriteLine("*******************************************");
        }
        static void viewSubjects(Student s)
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
        static int Menu()
        {
            int choice;
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Degree Program");
            Console.WriteLine("3. Generate Merit");
            Console.WriteLine("4. View Registered Students");
            Console.WriteLine("5. View Students of a Specific Student");
            Console.WriteLine("6. Register Subjects for a Specific Degree");
            Console.WriteLine("7. Calculate Fees for all Registered Students");
            Console.WriteLine("8. Exit");
            Console.Write("Enter Your Choice:");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
    }
}
