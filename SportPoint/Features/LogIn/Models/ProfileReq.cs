
using Newtonsoft.Json;

namespace SportPoint.Features.LogIn.Models
{
    public class PasswordProfile
    {

        [JsonProperty("forceChangePasswordNextSignIn")]
        public bool forceChangePasswordNextSignIn { get; set; }

        [JsonProperty("password")]
        public string password { get; set; }
    }

    public class ProfileReq
    {

        [JsonProperty("accountEnabled")]
        public bool accountEnabled { get; set; }

        [JsonProperty("displayName")]
        public string displayName { get; set; }

        [JsonProperty("givenName")]
        public object givenName { get; set; }

        [JsonProperty("surname")]
        public object surname { get; set; }

        [JsonProperty("mailNickname")]
        public string mailNickname { get; set; }

        [JsonProperty("userPrincipalName")]
        public string userPrincipalName { get; set; }

        [JsonProperty("passwordProfile")]
        public PasswordProfile passwordProfile { get; set; }
    }

}
