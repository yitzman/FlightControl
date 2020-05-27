using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightControlWeb.Models
{
    public class FlightDateAndTime
    {
        private int year, month, day, hour, minute, seconds;
        private DateTime date_time;


        public FlightDateAndTime(string time)
        {
            year =int.Parse(time.Substring(0, 4));
            month =int.Parse(time.Substring(5, 2));
            day =int.Parse(time.Substring(8, 2));
            hour =int.Parse(time.Substring(11, 2));
            minute =int.Parse(time.Substring(14, 2));
            seconds =int.Parse(time.Substring(17, 2));
            date_time = new DateTime(year, month, day, hour, minute, seconds);
        }

        private DateTime CreateDateTimeFromString(string time)
        {
            year = int.Parse(time.Substring(0, 4));
            month = int.Parse(time.Substring(5, 2));
            day = int.Parse(time.Substring(8, 2));
            hour = int.Parse(time.Substring(11, 2));
            minute = int.Parse(time.Substring(14, 2));
            seconds = int.Parse(time.Substring(17, 2));
            DateTime temp_date_time = new DateTime(year, month, day, hour, minute, seconds);
            return temp_date_time;
        }

        public void AddTimeInSeconds(int arg_seconds)
        {
            date_time = date_time.AddSeconds(arg_seconds);
        }
        override
        public string ToString()
        {
            
            string temp = date_time.ToString("yyyy-MM-dd");
            temp = temp + "T" + date_time.ToString("HH:mm:ss") + "Z";
            return temp;
        }
        public bool IsThisTimeEqual(string time)
        {
            
            DateTime arg_date_time = CreateDateTimeFromString(time);
            if (date_time == arg_date_time)
            {
                return true;
            }
            return false;
        }
        public bool IsThisTimeBigger(string time)
        {
            
            DateTime arg_date_time = CreateDateTimeFromString(time);
            if (date_time > arg_date_time)
            {
                return true;
            }
            return false;
        }
        public bool IsThisTimeSmaller(string time)
        {
            
            DateTime arg_date_time = CreateDateTimeFromString(time);
            if(date_time < arg_date_time)
            {
                return true;
            }
            return false;
           
        }

        public TimeSpan SubtractDateAndTime(string time)
        {
            DateTime arg_date_time = CreateDateTimeFromString(time);
            return this.date_time.Subtract(arg_date_time);
        }
    }
}
