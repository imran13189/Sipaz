using System;
using System.Collections.Generic;
using System.Text;

namespace Sipaz.MapLocation
{
   
    public class GeoLocations
    {
        public long place_id { get; set; }
        public string licence { get; set; }
        public string osm_type { get; set; }
        public long osm_id { get; set; }
        public string[] boundingbox { get; set; }
        public decimal lat { get; set; }
        public decimal lon { get; set; }
        public string display_name { get; set; }
        public string _class { get; set; }
        public string type { get; set; }
        public float importance { get; set; }
        public string icon { get; set; }
        public Address address { get; set; }
    }

    public class Address
    {
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
        public string state_district { get; set; }
    }


}
