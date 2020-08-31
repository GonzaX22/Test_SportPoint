using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace SportPoint.Features.LogIn.Models {

    public class TokenReq {

        public string Username { get; set; }

        public SecureString Password { get; set; }

        [JsonProperty(PropertyName = "grant_type")]
        public string GrantType { get; set; } = "password";

    }
}
