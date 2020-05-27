using FlightControlWeb.FlightObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightControlWeb.Models
{
    public class AllServers
    {
        private List<JsonServer> list_json_server = new List<JsonServer>();
        private List<ServerConnection> list_server_connection = new List<ServerConnection>();
        public void AddJsonServer(JsonServer arg_json_server)
        {
            list_json_server.Add(arg_json_server);
            ServerConnection server_connection = new ServerConnection(arg_json_server.ServerURL, arg_json_server.ServerId);
            list_server_connection.Add(server_connection);
        }

        public IEnumerable<JsonServer> GetAllServers()
        {
            return list_json_server;
        }

        public async  Task<List<SingelFlight>> GetFlightsWithDate(string arg_time)
        {
            List<SingelFlight> list_singel_flights = new List<SingelFlight>();
            foreach(ServerConnection server_connection in list_server_connection)
            {
                List<SingelFlight> temp_list_singel_flights = await server_connection.GetFlightsWithDate(arg_time);
                if(temp_list_singel_flights != null)
                {
                    list_singel_flights.AddRange(temp_list_singel_flights);
                }
            }
            return null;
        }

        public void DeleteServerById(int arg_id)
        {

        }
    }
}
