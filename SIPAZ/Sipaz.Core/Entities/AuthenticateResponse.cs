using System;
using System.Collections.Generic;
using System.Text;

namespace Sipaz.Core.Entities
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticateResponse(UserModel user, string token)
        {
            FirstName = user.Name;
            Username = user.Email;
            Token = token;
        }
    }
}
