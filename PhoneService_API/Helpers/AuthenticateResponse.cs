using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using PhoneService_API.Models;

namespace PhoneService_API.Helpers
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

        [JsonIgnore]
        public string RefreshToken { get; set; }

        public AuthenticateResponse(User user, string token, string refreshToken)
        {
            Id = user.Id;
            Username = user.Username;
            Token = token;
            RefreshToken = refreshToken;
        }
    }
}
