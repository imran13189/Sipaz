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
        public PropertyRentRepo(ConnectionString connectionString, AppSettings appSettings)
        {
            ConnectionString = connectionString.Value;
            _appSettings = appSettings;
        }
        public object GetMasterData()
        {
           DataSet ds= GetMultipleResult("SP_GetMasterData", null, CommandType.StoredProcedure);
           
            string jsonProperty = JsonConvert.SerializeObject(ds.Tables[0]);
            string jsonAU = JsonConvert.SerializeObject(ds.Tables[1]);
            string jsonCity = JsonConvert.SerializeObject(ds.Tables[1]);
            IEnumerable<PropertyTypeModel> pTypeList = JsonConvert.DeserializeObject<IEnumerable<PropertyTypeModel>>(jsonProperty);
            IEnumerable<AUModel> AuList = JsonConvert.DeserializeObject<IEnumerable<AUModel>>(jsonAU);
            IEnumerable<CityModel> CityList = JsonConvert.DeserializeObject<IEnumerable<CityModel>>(jsonCity);
            return new { PropertyType = pTypeList, AuList = AuList,Cities= CityList };
        }


    }
}
