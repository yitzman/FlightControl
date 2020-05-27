using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightControlWeb.FlightObjects
{
    public class JsonServer
    {
        private string backup_ServerId;
        public string ServerId
        {
            get
            {
                return backup_ServerId;
            }
            set
            {
                backup_ServerId = value;
            }
        }

        private string backup_ServerURL;
        public string ServerURL
        {
            get
            {
                return backup_ServerURL;
            }
            set
            {
                backup_ServerURL = value;
            }
        }
    }
}
