using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightControlWeb.Models
{
    public class FlightBetweenTwoSegments
    {
        private SingelFlight first_flight, sec_flight;
        public FlightBetweenTwoSegments(SingelFlight first_flight, SingelFlight sec_flight)
        {
            this.first_flight = first_flight;
            this.sec_flight = sec_flight;
        }

        public bool IsTimeBetweenTheTwoFlights(string time)
        {
            FlightDateAndTime time_first_flight = new FlightDateAndTime(first_flight.date_time);
            FlightDateAndTime time_sec_flight = new FlightDateAndTime(sec_flight.date_time);
            FlightDateAndTime arg_time_date = new FlightDateAndTime(time);
            bool is_time_bigger_then_first_flight = (!time_first_flight.IsThisTimeSmaller(time));
            bool is_time_smaller_then_sec_flight = time_sec_flight.IsThisTimeSmaller(time);

            if((arg_time_date.IsThisTimeBigger(first_flight.date_time) || arg_time_date.IsThisTimeEqual(first_flight.date_time))
                && (arg_time_date.IsThisTimeSmaller(sec_flight.date_time) || arg_time_date.IsThisTimeEqual(sec_flight.date_time)))
            {
                return true;
            }
            return false;
        }

        public SingelFlight CreateSingelFlightBetweenTwoFlights(string arg_time)
        {
            FlightDateAndTime time_first_flight = new FlightDateAndTime(first_flight.date_time);
            FlightDateAndTime time_sec_flight = new FlightDateAndTime(sec_flight.date_time);
            FlightDateAndTime arg_time_date = new FlightDateAndTime(arg_time);

            TimeSpan sub_first_from_sec = time_sec_flight.SubtractDateAndTime(first_flight.date_time);
            TimeSpan sub_first_from_arg_time = arg_time_date.SubtractDateAndTime(first_flight.date_time);
            long ticks_total = sub_first_from_sec.Ticks;
            long ticks_mid = sub_first_from_arg_time.Ticks;

            decimal temp = ticks_mid / ticks_total;
            double remainder = ((double)ticks_mid )/ ticks_total;
            //long count = Math.DivRem(ticks_total, ticks_mid, out remainder);

            //TimeSpan remainderSpan = TimeSpan.FromTicks(remainder);
            double longitude;
            double latitude;
            if(first_flight.longitude > sec_flight.longitude)
            {
                longitude = first_flight.longitude - sec_flight.longitude;
                longitude = first_flight.longitude - longitude * remainder;
            } else if(first_flight.longitude == sec_flight.longitude)
            {
                longitude = first_flight.longitude;
            } else
            {
                longitude = sec_flight.longitude - first_flight.longitude;
                longitude = longitude * remainder + first_flight.longitude;
            }

            if (first_flight.latitude > sec_flight.latitude)
            {
                latitude = first_flight.latitude - sec_flight.latitude;
                latitude = first_flight.latitude - latitude * remainder;
            }
            else if (first_flight.latitude == sec_flight.latitude)
            {
                latitude = first_flight.latitude;
            }
            else
            {
                latitude = sec_flight.latitude - first_flight.latitude;
                latitude = latitude * remainder + first_flight.latitude;
            }
            
            SingelFlight singel_flight = new SingelFlight();
            singel_flight.flight_id = first_flight.flight_id;
            singel_flight.longitude = longitude;
            singel_flight.latitude = latitude;
            
            singel_flight.date_time = arg_time;

            singel_flight.passengers = first_flight.passengers;
            singel_flight.company_name = first_flight.company_name;
            singel_flight.is_external = false;
            return singel_flight;
        }

        public SingelFlight GetFirstFlight()
        {
            return first_flight;
        }
        public SingelFlight GetSecFlight()
        {
            return sec_flight;
        }


    }
}
