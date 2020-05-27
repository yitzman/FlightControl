using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FlightControlWeb.FlightObjects;
using FlightControlWeb.Models;

namespace FlightControlWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightPlanController : ControllerBase
    {
        private static AllFlightPlans all_flight_plans;

        public FlightPlanController(AllFlightPlans allFlightPlans)
        {
            all_flight_plans = allFlightPlans;
        }
        // GET: api/FlightPlan
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/FlightPlan/5
        [HttpGet("{id}", Name = "Get")]
        public JsonFlightPlan Get(int id)
        {
            //var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(all_flight_plans.GetFlightPlanById(id));
            return all_flight_plans.GetFlightPlanById(id);
        }

        // POST: api/FlightPlan
        [HttpPost]
        public string Post([FromBody] JsonFlightPlan json_flight_plan)
        {
            all_flight_plans.AddFlightPlan(json_flight_plan);
            
            Console.WriteLine("");
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(all_flight_plans.GetFlightPlanById(1));
            return jsonString;
        }

        // PUT: api/FlightPlan/5
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
