using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sipaz.Core.Entities;
using Sipaz.Core.Interfaces;

namespace Sipaz.Web.MobileAPI
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class PropertyAPIController : ControllerBase
    {
        public IPropertyRent _property;
        public PropertyAPIController(IPropertyRent property)
        {
            _property = property;
        }

        [HttpGet]
        public string GetDate()
        {
            return "Hello";

        }

        [HttpPost]
        public Result Test(UserModel model)
        {
            //return _property.SaveBasicDetails(model);
            return null;
        }


        [HttpPost]
        public Result SaveBasicDetails(PropertyRentModel model)
        {
           return _property.SaveBasicDetails(model);

        }

        [HttpPost]
        public Result SavePropertyFeatures(PropertyRentModel model)
        {
            return _property.SavePropertyFeatures(model);

        }

        [HttpPost]
        public Result SavePriceDetails(PropertyRentModel model)
        {
            return _property.SavePriceDetails(model);

        }
    }
}
