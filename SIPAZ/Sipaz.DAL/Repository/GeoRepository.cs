using Sipaz.Core.Entities;
using Sipaz.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Sipaz.DAL.Repository
{
    public class GeoRepository:BaseRepository, IGeoRepository
    {
        public GeoRepository()
        {
            this.ConnectionString = "Data Source=localhost;User ID=sa;password=data@123;Initial Catalog=SipazDev;";
        }
        public IEnumerable<Districts> GetDistricts()
        {
            return Query<Districts>("SP_GetDistricts", CommandType.StoredProcedure);
        }

        public void SaveLocation(Locations model)
        {
            var obj = new
            {
                PlaceId = model.PlaceId,
                Lat = model.Lat,
                Lon = model.Lon,
                DisplayName = model.DisplayName,
                DistrictId = model.DistrictId
            };
            Locations data= QueryFirst<Locations>("SP_InsertLocation", obj, CommandType.StoredProcedure);
        }
    }
}
