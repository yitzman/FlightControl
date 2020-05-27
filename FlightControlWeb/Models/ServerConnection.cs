using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FlightControlWeb.Models
{
    public class ServerConnection
    {
        private string id;
        private string ip;

        public ServerConnection(string arg_ip, string arg_id)
        {
            this.id = arg_id;
            this.ip = arg_ip;
        }

        public string GetId()
        {
            return id;
        }

        public async Task<List<SingelFlight>>  GetFlightsWithDate(string arg_time)
        {
            /*
            using var client = new HttpClient();

            client.BaseAddress = new Uri("https://api.github.com");
            client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

            var url = "repos/symfony/symfony/contributors";
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();

            List<Contributor> contributors = JsonConvert.DeserializeObject<List<Contributor>>(resp);
            contributors.ForEach(Console.WriteLine);
            */
            string path_and_quary = $"\\api\\Flights?relative_to={arg_time}";
            using var client = new HttpClient();

            client.BaseAddress = new Uri(ip);
            //client.DefaultRequestHeaders.Add("User-Agent", "C# console program");
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

            
            HttpResponseMessage response = await client.GetAsync(path_and_quary);
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();

            List<SingelFlight> list_singel_flights = JsonConvert.DeserializeObject<List<SingelFlight>>(resp);
            foreach(SingelFlight singel_flight in list_singel_flights)
            {
                singel_flight.is_external = true;
            }
            return list_singel_flights;


        }

    }
}
