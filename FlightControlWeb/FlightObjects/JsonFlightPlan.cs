using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightControlWeb.FlightObjects
{
    public class JsonFlightPlan
    {
        private int back_up_passengers;
        public int passengers
        {
            get
            {
                return back_up_passengers;
            }
            set
            {
                back_up_passengers = value;
            }
        }
        private string back_up_company_name;
        public string company_name
        {
            get
            {
                return back_up_company_name;
            }
            set
            {
                back_up_company_name = value;
            }
        }
        private JsonInitialLocation backup_initial_location;
        public JsonInitialLocation initial_location
        {
            get
            {
                return backup_initial_location;
            }
            set
            {
                backup_initial_location = value;
            }
        }
        private IEnumerable<JsonSegment> backup_segments = new List<JsonSegment>();
        public IEnumerable<JsonSegment> segments
        {
            get
            {
                return backup_segments;
            }

            set
            {
                backup_segments = value;
            }
        }
    }
}
