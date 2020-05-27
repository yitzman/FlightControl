using FlightControlWeb.FlightObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightControlWeb.Models
{
    public class FlightPlanModel
    {
        private  List<SingelFlight> flights_list = new List<SingelFlight>();
        private  JsonSegment last_point;
        private  bool is_parsed = false;
        private  JsonFlightPlan json_flight_plan;
        private  string id_flight_plan;

        public FlightPlanModel(JsonFlightPlan flight_plan, string arg_id_flight_plan)
        {
            json_flight_plan = flight_plan;
            id_flight_plan = arg_id_flight_plan;
        }

        public void ParseTheFlightPlan()
        {
            if (is_parsed)
            {
                return;
            }

            
            SingelFlight first_flight = new SingelFlight();
            first_flight.flight_id = id_flight_plan;
            first_flight.longitude = json_flight_plan.initial_location.longitude;
            first_flight.latitude = json_flight_plan.initial_location.latitude;
            first_flight.date_time = json_flight_plan.initial_location.date_time;
            first_flight.passengers = json_flight_plan.passengers;
            first_flight.company_name = json_flight_plan.company_name;
            first_flight.is_external = false;
            flights_list.Add(first_flight);
            foreach (JsonSegment seg in json_flight_plan.segments)
            {
                flights_list.Add(CreateSingelFlight(first_flight, seg));
            }

            is_parsed = true;

        }

        public SingelFlight CreateSingelFlight(SingelFlight arg_singel_flight, JsonSegment segment)
        {
            SingelFlight singel_flight = new SingelFlight();
            singel_flight.flight_id = id_flight_plan;
            singel_flight.longitude = segment.longitude;
            singel_flight.latitude = segment.latitude;
            FlightDateAndTime temp = new FlightDateAndTime(arg_singel_flight.date_time);
            temp.AddTimeInSeconds(segment.timespan_seconds);
            singel_flight.date_time = temp.ToString();

            singel_flight.passengers = json_flight_plan.passengers;
            singel_flight.company_name = json_flight_plan.company_name;
            singel_flight.is_external = false;

            return singel_flight;
        }


       
        public IEnumerable<SingelFlight> GetAllFlights()
        {
            return flights_list;
        }

        public SingelFlight GetAllCurrentFlightsWithDate(string date_time)
        {
            
            IEnumerable<FlightBetweenTwoSegments> list_flights_two_segments = CreateAnArrayOfFlightBetweenTwoSegments();
            foreach (var two_flights in list_flights_two_segments)
            {
                if(two_flights.IsTimeBetweenTheTwoFlights(date_time))
                {
                    return two_flights.CreateSingelFlightBetweenTwoFlights(date_time);
                }
            }
            return null;
        }

        private IEnumerable<FlightBetweenTwoSegments> CreateAnArrayOfFlightBetweenTwoSegments()
        {
            List<FlightBetweenTwoSegments> list_flights_two_segments = new List<FlightBetweenTwoSegments>();
            SingelFlight first_flight = flights_list.First();
            bool is_first_flight = true;
            foreach(SingelFlight sec_flight in flights_list)
            {
                if(is_first_flight)
                {
                    is_first_flight = false;
                    continue;
                }
                FlightBetweenTwoSegments fbts = new FlightBetweenTwoSegments(first_flight, sec_flight);
                list_flights_two_segments.Add(fbts);
                first_flight = sec_flight;

            }
            
            
            return list_flights_two_segments;
        }

        public string GetId()
        {
            return this.id_flight_plan;
        }

        public bool Equals(FlightPlanModel other)
        {
            if (this.id_flight_plan.Equals(other.GetId()))
            {
                return true;
            }
            return false;
        }

    }
}
