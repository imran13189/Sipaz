using Newtonsoft.Json;
using Sipaz.Core.Entities;
using Sipaz.Core.Interfaces;
using Sipaz.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Sipaz.MapLocation
{
    class Program
    {
        static void Main(string[] args)
        {
            IGeoRepository _dal = new GeoRepository();
            var districts = _dal.GetDistricts();
            string url = "https://nominatim.openstreetmap.org/search?q={0}&limit=5&format=json&addressdetails=1";
            string pingUrl;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.UserAgent.Clear();
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("f1ana.Nominatim.API", Assembly.GetExecutingAssembly().GetName().Version.ToString()));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            foreach (var dis in districts)
            {
                try
                {
                  
                    pingUrl = string.Format(url, dis.Name).ToString();
                    HttpResponseMessage response = client.GetAsync(pingUrl).Result;
                    string data = response.Content.ReadAsStringAsync().Result;
                    List<GeoLocations> result = JsonConvert.DeserializeObject<List<GeoLocations>>(data);
                    foreach (var item in result)
                    {
                        Locations loc = new Locations();
                        loc.PlaceId = item.place_id;
                        loc.Lon = item.lon;
                        loc.Lat = item.lat;
                        loc.DisplayName = item.display_name;
                        loc.DistrictId = dis.Id;
                        _dal.SaveLocation(loc);
                    }
                    System.Threading.Thread.Sleep(1000);
                }
                catch
                {
                    continue;
                }
            }
        }
    }
}
