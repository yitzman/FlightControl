using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightControlWeb.FlightObjects
{
    public class JsonInitialLocation
    {
        private double backup_longitude;
        public double longitude
        {
            get
            {
                return backup_longitude;
            }
            set
            {
                backup_longitude = value;
            }
        }


        private double backup_latitude;
        public double latitude
        {
            get
            {
                return backup_latitude;
            }
            set
            {
                backup_latitude = value;
            }
        }





        private string backup_date_time;
        public string date_time
        {
            get
            {
                return backup_date_time;
            }
            set
            {
                backup_date_time = value;
            }
        }
    }
}
