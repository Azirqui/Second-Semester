using Challenge_01.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Challenge_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();
            List<Student> sortedStudentList = new List<Student>();
            List<DegreeProgram> programList = new List<DegreeProgram>();            
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
                        addIntoStudentList(s, studentList);
                    }
                }
                else if (option == 2)
                {
                    DegreeProgram d = takeInputForDegree();
                    addIntoDegreeList(d, programList);
                }
                else if (option == 3)
                {
                    sortStudentsByMerit();
                    giveAdmission();
                    printStudents();
                }
                else if (option == 4)
                {
                    viewRegisteredStudents(sortedStudentList);
                }
                else if (option == 5)
                {
                    string degName;
                    Console.Write("Enter Degree Name: ");
                    degName = Console.ReadLine();
                    viewStudentInDegree(degName);
                }
                else if (option == 6)
                {
                    Console.Write("Enter the Student Name: ");
                    string name = Console.ReadLine();
                    Student s = StudentPresent(name, sortedStudentList);
                    if (s != null)
                    {
                        s.viewSubjects();
                        s.regStudentSubject(s);
                    }
                }
                else if (option == 7)
                {

                   calculateFee(sortedStudentList);
                }
                clearScreen();

            }
            while (option != 8);
            Console.ReadKey();

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
        static void clearScreen()
        {
            Console.Clear();
        }
        static Student takeInputForStudent()
        {          
            Console.WriteLine("Enter Student Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Student Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student Fsc Marks: ");
            double fscMarks = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter Student Ecat Marks: ");
            double ecatMarks = double.Parse(Console.ReadLine());
            Student s = new Student(name, age, fscMarks, ecatMarks,);
            return s;
        }
        static void addIntoStudentList(Student s, List<Student> studentList)
        {
            studentList.Add(s);
        }
        static DegreeProgram takeInputForDegree()
        {
            Console.WriteLine("Enter Degree Name: ");
            string degree_name = Console.ReadLine();
            Console.WriteLine("Enter Degree Duration: ");
            float degree_duration = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter Seats for Degree: ");
            int degree_seats = int.Parse(Console.ReadLine());
            DegreeProgram d =new DegreeProgram(degree_name, degree_duration, degree_seats);
            return d;           
        }
        static void addIntoDegreeList(DegreeProgram d, List<DegreeProgram> programList)
        {
            programList.Add(d);
        }
        static Subject AddSubject()
        {
            Console.WriteLine("Enter How many Subjects to Enter: ");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter Subject Code: ");
                string subject_code = Console.ReadLine();
                Console.WriteLine("Enter Subject Type: ");
                string subject_type = Console.ReadLine();
                Console.WriteLine("Enter Subject Credit Hours: ");
                int subject_creditHours = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Subject Fees: ");
                int subject_fees = int.Parse(Console.ReadLine());
                Subject subject = new Subject(subject_code, subject_type, subject_creditHours, subject_fees);
                return subject;
            }
        }
        static void viewRegisteredStudents(List<Student> sortedStudentList)
        {
            foreach (Student student in sortedStudentList)
            {
                Console.WriteLine(student.name);
            }
        }
        static void calculateFee(List<Student> sortedStudentList)
        {
            foreach(Student student in sortedStudentList)
            {
               Console.WriteLine (student.calculateFee());              
            }
        }
        static Student StudentPresent(string name, List<Student> sortedStudentList)
        {
            foreach (Student student in sortedStudentList)
            {
                if (student.name == name)
                {
                    return student;           
                }
            }
            
        }
        static void sortStudentsByMerit(List<Student> studentList, List<Student> sortedStudentList)
        {


            studentList.Sort();
            
        }
    }
}
