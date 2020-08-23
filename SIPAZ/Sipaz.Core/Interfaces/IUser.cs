using Sipaz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sipaz.Core.Interfaces
{
    public interface IUser
    {
        public IEnumerable<UserModel> GetUser(string Email);
        public AuthenticateResponse Authenticate(AuthenticateRequest model);
        public Result Register(UserModel model);

        public string generateJwtToken(UserModel user);
    }
}
