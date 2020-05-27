using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightControlWeb.FlightObjects;
using FlightControlWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightControlWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class serversController : ControllerBase
    {
        private static AllFlightPlans all_flight_plans;

        public serversController(AllFlightPlans allFlightPlans)
        {
            all_flight_plans = allFlightPlans;
        }
        // GET: api/servers

        //public IEnumerable<string> Get()
        [HttpGet]
        public List<string> Get()
        {
            /*
             foreach(JsonServer json_server in all_flight_plans.GetJsonServers())
             {
                 list_string.Add(Newtonsoft.Json.JsonConvert.SerializeObject(json_server));
             }

             return list_string;
             string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(all_flight_plans.GetJsonServers());
             return jsonString;*/
            return null;
        }

        // GET: api/servers/5
        [HttpGet("{id}", Name = "GetServerById")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/servers
        [HttpPost]
        public String Post([FromBody] JsonServer json_server)
        {
            all_flight_plans.AddServer(json_server);
            return "Sdf";
        }

        // PUT: api/servers/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
