using System;
using System.Collections.Generic;
using System.Text;

namespace Sipaz.Core.Entities
{
    public class Locations
    {
        public int Id { get; set; }
        public long PlaceId { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public string DisplayName { get; set; }

        public int DistrictId { get; set; }
    }
}
