
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SportPoint.Features.LogIn.Models {

    public class Value
    {

        [JsonProperty("businessPhones")]
        public IList<object> businessPhones { get; set; }

        [JsonProperty("displayName")]
        public string displayName { get; set; }

        [JsonProperty("givenName")]
        public string givenName { get; set; }

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
        public string surname { get; set; }

        [JsonProperty("userPrincipalName")]
        public string userPrincipalName { get; set; }

        [JsonProperty("id")]
        public string id { get; set; }
    }

    public class ProfilesResp
    {

        [JsonProperty("@odata.context")]
        public string odataContext { get; set; }

        [JsonProperty("value")]
        public IList<Value> value { get; set; }
    }


}
