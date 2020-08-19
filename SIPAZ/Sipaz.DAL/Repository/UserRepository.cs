using Sipaz.Core.Entities;
using Sipaz.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;

namespace Sipaz.DAL.Repository
{
    public class UserRepository :BaseRepository,IUser
    {
        public ConnectionString connectionString;
        public readonly AppSettings _appSettings;
        public UserRepository(ConnectionString connectionString, AppSettings appSettings)
        {
            ConnectionString = connectionString.Value;
            _appSettings = appSettings;
        }

        public IEnumerable<UserModel> GetUser(string Email)
        {
          return  Query<UserModel>("SP_GetUser", new { Email = Email }, CommandType.StoredProcedure);
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = GetUser(model.Username).FirstOrDefault();

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        private string generateJwtToken(UserModel user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Result Register(UserModel model)
        {
            object Params = new {
            Email=model.Email,
            Name=model.Name,
            Password=model.Password,
            Mobile=model.Mobile
            };
            return QueryFirst<Result>("SP_REGISTER", Params, CommandType.StoredProcedure);
        }
    }
}
