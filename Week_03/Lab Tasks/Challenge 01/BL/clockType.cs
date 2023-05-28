using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_01.BL
{
    internal class clockType
    {
        /*------------------ Data Members of Class ---------------------*/
        public int hours;
        public int minutes;
        public int seconds;
        /*------------------ Elapsed Time Constructor ---------------------*/
        public static clockType elapsedTime(clockType initial_time)
        {
            clockType Elapsed_Time = new clockType();
            int total_initial_time=initial_time.hours * 3600 + initial_time.minutes * 60 + initial_time.seconds;
            int elapsed_Time = total_initial_time-0;
            Elapsed_Time.hours = elapsed_Time / 3600;
            int remaining_sec = elapsed_Time % 3600;
            Elapsed_Time.minutes = remaining_sec / 60;
            Elapsed_Time.seconds = remaining_sec % 60;
            return Elapsed_Time;
        }
        /*------------------ Remaining Time Constructor ---------------------*/
        public static clockType remaining_time(clockType initial_time)
        {
            clockType Remaining_Time = new clockType();
            int total_initial_time = initial_time.hours * 3600 + initial_time.minutes * 60 + initial_time.seconds;
            int dayTime_sec = 24 * 3600;
            int remaining_Time = total_initial_time - dayTime_sec;
            Remaining_Time.hours = remaining_Time / 3600;
            int remaining_sec = remaining_Time % 3600;
            Remaining_Time.minutes = remaining_sec / 60;
            Remaining_Time.seconds = remaining_sec % 60;
            return Remaining_Time;
        }
    }
}
