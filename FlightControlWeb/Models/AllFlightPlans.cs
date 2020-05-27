using FlightControlWeb.FlightObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightControlWeb.Models
{
    public class AllFlightPlans
    {
        private static List<FlightPlanModel> list_flight_plans = new List<FlightPlanModel>();
        private static IDictionary<string, JsonFlightPlan> dict_of_json_flight_plan = new Dictionary<string, JsonFlightPlan>();
        private static AllServers all_servers = new AllServers();
        private static int num_of_flight_plan = 0;


        #region this server
        public void AddFlightPlan(JsonFlightPlan flight_plan)
        {
            num_of_flight_plan++;
            dict_of_json_flight_plan[GetId()] = flight_plan;

            FlightPlanModel flight_plan_model = new FlightPlanModel(flight_plan, GetId());
            flight_plan_model.ParseTheFlightPlan();
            list_flight_plans.Add(flight_plan_model);
            Console.WriteLine("");

        }

        public JsonFlightPlan GetFlightPlanById(int arg_id)
        {
            string id = arg_id.ToString();
            while(id.Length < 10)
            {
                id = "0" + id;
            }
            return dict_of_json_flight_plan[id];
        }

        public List<SingelFlight> GetFlightsWithTime(string date_time)
        {
            List<SingelFlight> list_singel_flights = new List<SingelFlight>();
            SingelFlight sf;
            foreach(FlightPlanModel flight_plan in list_flight_plans)
            {
                sf = flight_plan.GetAllCurrentFlightsWithDate(date_time);
                if (sf != null)
                {
                    list_singel_flights.Add(sf);
                }
            }

            return list_singel_flights;
        }

        public void DeleteFlightWithId(int arg_id)
        {
            string arg_id_string = arg_id.ToString();
            while (arg_id_string.Length < 10)
            {
                arg_id_string = "0" + arg_id_string;
            }
            
            foreach (FlightPlanModel flight_plan in list_flight_plans)
            {
                if (arg_id_string.Equals(flight_plan.GetId()))
                {
                    list_flight_plans.Remove(flight_plan);
                    break;
                }
            }
            dict_of_json_flight_plan.Remove(arg_id_string);
        }

        private string GetId()
        {
            string id = num_of_flight_plan.ToString();
            while(id.Length < 10)
            {
                id = "0" + id;
            }
            return id;
        }
        #endregion

        #region other servers

        public void AddServer(JsonServer arg_json_server)
        {
            all_servers.AddJsonServer(arg_json_server);
        }

        public IEnumerable<JsonServer> GetJsonServers()
        {
            return all_servers.GetAllServers();
        }

        public void DeleteServerById(int arg_id)
        {
            all_servers.DeleteServerById(arg_id);
        }

        public async Task<List<SingelFlight>> GetAllSingelFlightsWitheTimeAsync(string time)
        {
            List<SingelFlight> list_server_singel_flight = await all_servers.GetFlightsWithDate(time);
            List<SingelFlight> list_this_singel_flight = GetFlightsWithTime(time);
            list_server_singel_flight.AddRange(list_this_singel_flight);
            return list_server_singel_flight;
        }

        
        #endregion


    }
}
