using System;
using System.Collections.Generic;
using System.Text;

namespace Sipaz.Core.PropertyEntities
{
    public class BasicDetails
    {
        public long PropertyId { get; set; }
        public string Locality { get; set; }
        public int PropertyTypeId { get; set; }
        public Nullable<decimal> Area { get; set; }
        public int AU { get; set; }
        public Nullable<int> ADType { get; set; }
        public Nullable<int> AvailableStatus { get; set; }
        public Nullable<System.DateTime> AvailableDate { get; set; }
        public decimal ExpectedPrice { get; set; }
        public Nullable<decimal> SecurityAmount { get; set; }
        public Nullable<decimal> MaintenanceCharges { get; set; }
        public Nullable<int> BathroomNum { get; set; }
        public Nullable<int> TotalFloor { get; set; }
        public Nullable<int> FloorNum { get; set; }
        public int FurnishedType { get; set; }
        public string Address { get; set; }
        public string ProjectSociety { get; set; }
        public bool CarParking { get; set; }
        public int FacingId { get; set; }
        public int CityId { get; set; }
        public string Description { get; set; }
        public string Mobile { get; set; }
        public string PropertyName { get; set; }
        public bool BikeParking { get; set; }
        public bool Lift { get; set; }
        public bool Water { get; set; }
        public string[] Photos { get; set; }
        public long UserId { get; set; }
        public int BedRooms { get; set; }
        public int StateID { get; set; }
    }
}
