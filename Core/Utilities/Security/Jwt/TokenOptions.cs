using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string  Ussuer { get; set; }
        public string AccessTokenExpiiration { get; set; }
        public string SecurityKey { get; set; }

    }
}
