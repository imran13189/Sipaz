using Newtonsoft.Json;
using Sipaz.Core.Entities;
using Sipaz.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Text.Json.Serialization;

namespace Sipaz.DAL.Repository
{
    public class PropertyRentRepo:BaseRepository, IPropertyRent
    {
        public ConnectionString connectionString;
        public readonly AppSettings _appSettings;
        public DataSet ds;
        public PropertyRentRepo(ConnectionString connectionString, AppSettings appSettings)
        {
            ConnectionString = connectionString.Value;
            _appSettings = appSettings;
        }
        public PropertyRentModel GetMasterData()
        {
             ds= GetMultipleResult("SP_GetMasterData", null, CommandType.StoredProcedure);
           
            string jsonProperty = JsonConvert.SerializeObject(ds.Tables[0]);
            string jsonAU = JsonConvert.SerializeObject(ds.Tables[1]);
            string jsonCity = JsonConvert.SerializeObject(ds.Tables[2]);
            IEnumerable<PropertyTypeModel> pTypeList = JsonConvert.DeserializeObject<IEnumerable<PropertyTypeModel>>(jsonProperty);
            IEnumerable<AUModel> AuList = JsonConvert.DeserializeObject<IEnumerable<AUModel>>(jsonAU);
            IEnumerable<CityModel> CityList = JsonConvert.DeserializeObject<IEnumerable<CityModel>>(jsonCity);
            return new PropertyRentModel (){ propertyType = pTypeList, AuList = AuList,Cities= CityList };
        }

        public Result SaveBasicDetails(PropertyRentModel model)
        {
            object Params = new
            {
                   Locality   =model.Locality,
                   PropertyTypeId   = model.PropertyTypeId,
                   Area   =model.Area,
                   AU   =model.AU,
                   ADType   =model.ADType,
                   AvailableStatus   =model.AvailableStatus,
                   AvailableDate   =model.AvailableDate,
                   BathroomNum   =model.BathroomNum,
                   TotalFloor   =model.TotalFloor,
                   FloorNum   =model.FloorNum,
                   FurnishedType  =model.FurnishedType,
                   CityId   =model.CityId,
                   Mobile =model.Mobile,
                   PropertyName   =model.PropertyName,
                   BedRooms   =model.BedRooms,
                   UserId  =model.UserId
            };
            return QueryFirst<Result>("SP_SaveBasicDetails", Params, CommandType.StoredProcedure);
        }
        public Result SavePropertyFeatures(PropertyRentModel model)
        {
            object Params = new
            {
                 BikeParking   =model.BikeParking,
                 Lift   =model.Lift,
                 Water   =model.Water,
                 CarParking   =model.CarParking,
                 FacingId  =model.FacingId,
                 PropertyId = model.PropertyId,
            };

            return QueryFirst<Result>("SP_SavePropertyFeature", Params, CommandType.StoredProcedure);
        }
        public Result SavePriceDetails(PropertyRentModel model)
        {
            object Params = new
            {
                ExpectedPrice = model.ExpectedPrice,
                SecurityAmount = model.SecurityAmount,
                MaintenanceCharges = model.MaintenanceCharges,
                PropertyId = model.PropertyId

            };
            return QueryFirst<Result>("SP_SavePriceDetails", Params, CommandType.StoredProcedure);
        }
    }
}
