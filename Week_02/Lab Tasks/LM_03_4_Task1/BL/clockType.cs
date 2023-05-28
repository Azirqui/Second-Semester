using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LM_03_4_Task1.BL
{
    internal class clockType
    {
        //Create a class with these three data members.
        public int hours;
        public int minutes;
        public int seconds;
        //Define a default constructor
        public clockType()
        {
            hours = 0;
            minutes = 0;
            seconds = 0;
        }
        //Define parameterized constructors with one, two, and three parameters individually
        public clockType(int h)
        {
            hours = h;
        }
        public clockType(int h,int m)
        {
            hours = h;
            minutes = m;
        }
        public clockType(int h,int m,int s)
        {
            hours = h;
            minutes = m;
            seconds = s;
        }
        //Define member functions for incrementing minutes, hours, and seconds individually.
        public void incrementSecond()
        {
            seconds++;
        }
        public void incrementHours()
        {
            hours++;
        }
        public void incrementMinutes()
        {
            minutes++;
        }
        //Define member function for printing time on screen.
        public void printTime()
        {
            Console.WriteLine(hours + " " + minutes+ " " + seconds);
        }
        //Define isEqual() member function for comparing time with provided manual time.
        public bool isEqual(int h, int m, int s)
        {
            if (hours == h && minutes == m && seconds == s)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Define isEqual() member function for comparing time with provided object’s time.
        public bool isEqual(clockType temp)
        {
            if (hours == temp.hours  && minutes == temp.minutes && seconds == temp.seconds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
