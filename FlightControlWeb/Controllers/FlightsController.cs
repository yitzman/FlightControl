using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightControlWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightControlWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private static AllFlightPlans all_flight_plans;

        public FlightsController(AllFlightPlans allFlightPlans)
        {
            all_flight_plans = allFlightPlans;
        }
        // GET: api/Flights
        [HttpGet]
        public IEnumerable<SingelFlight> Get([FromQuery(Name = "relative_to")] string relative_to)
        {
            //var jsonString =  Newtonsoft.Json.JsonConvert.SerializeObject(all_flight_plans.GetFlightsWithTime(relative_to));
            IEnumerable<SingelFlight> list_temp = all_flight_plans.GetFlightsWithTime(relative_to);
            List<string> list_string = new List<string>();
            foreach(SingelFlight sf in list_temp)
            {
                list_string.Add(Newtonsoft.Json.JsonConvert.SerializeObject(sf));
            }
            
            return list_temp;
        }
        
        
        public async Task<string> Get([FromQuery(Name = "relative_to")] string relative_to, [FromQuery(Name = "sync_all")] string sync_all)
        {
            var temp = await all_flight_plans.GetAllSingelFlightsWitheTimeAsync(relative_to);
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(all_flight_plans.GetFlightsWithTime(relative_to));

            return jsonString;
        }
        
        // GET: api/Flights/5
        [HttpGet("{id}", Name = "GetFlightsById")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Flights
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Flights/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            all_flight_plans.DeleteFlightWithId(id);
        }
    }
}
