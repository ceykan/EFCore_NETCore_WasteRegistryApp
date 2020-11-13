using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WasteRegistry.API.Token.Model
{
    public class AuthenticationOptions
    {
            public string SecureKey { get; set; }
            public string Issuer { get; set; }
            public string Audience { get; set; }
            public int ExpiresInMinutes { get; set; }
    }
}
