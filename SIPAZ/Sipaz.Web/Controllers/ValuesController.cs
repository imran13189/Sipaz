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

namespace Sipaz.Web.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public IUser _user;
        public ValuesController(IUser user)
        {
            _user = user;
        }

        [Route("api/GetUser")]
        public IEnumerable<UserModel> GetUsers()
        {
          return  _user.GetUser("imran13189@gmail.com");
        }
    }
}
