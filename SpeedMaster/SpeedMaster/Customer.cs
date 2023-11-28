using SpeedMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpeedMaster
{
    public class Customer
    {

        public int ID { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string nif { get; set; }
        public string active { get; set; }
    }
}
