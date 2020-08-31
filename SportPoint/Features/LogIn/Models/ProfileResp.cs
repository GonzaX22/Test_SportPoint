
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportPoint.Features.LogIn.Models
{
    public class ProfileResp {

        [JsonProperty("@odata.context")]
        public string odataContext { get; set; }

        [JsonProperty("businessPhones")]
        public IList<object> businessPhones { get; set; }

        [JsonProperty("displayName")]
        public string displayName { get; set; }

        [JsonProperty("givenName")]
        public object givenName { get; set; }

        [JsonProperty("jobTitle")]
        public object jobTitle { get; set; }

        [JsonProperty("mail")]
        public object mail { get; set; }

        [JsonProperty("mobilePhone")]
        public object mobilePhone { get; set; }

        [JsonProperty("officeLocation")]
        public object officeLocation { get; set; }

        [JsonProperty("preferredLanguage")]
        public object preferredLanguage { get; set; }

        [JsonProperty("surname")]
        public object surname { get; set; }

        [JsonProperty("userPrincipalName")]
        public string userPrincipalName { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }
    }

}