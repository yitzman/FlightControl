using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightControlWeb.Models
{
    public class SingelFlight
    {
        private string backup_flight_id;
        public string flight_id
        {
            get
            {
                return backup_flight_id;
            }
            set
            {
                backup_flight_id = value;
            }
        }

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


        private int backup_passengers;
        public int passengers
        {
            get
            {
                return backup_passengers;
            }
            set
            {
                backup_passengers = value;
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


        private string backup_company_name;
        public string company_name
        {
            get
            {
                return backup_company_name;
            }
            set
            {
                backup_company_name = value;
            }
        }


        private bool backup_is_external;
        public bool is_external
        {
            get
            {
                return backup_is_external;
            }
            set
            {
                backup_is_external = value;
            }
        }

    }
}
