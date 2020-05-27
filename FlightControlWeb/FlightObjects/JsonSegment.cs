using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightControlWeb.FlightObjects
{
    public class JsonSegment
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




        private int backup_timespan_seconds;
        public int timespan_seconds
        {
            get
            {
                return backup_timespan_seconds;
            }
            set
            {
                backup_timespan_seconds = value;
            }
        }
    }
}
