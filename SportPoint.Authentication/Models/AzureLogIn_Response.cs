using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SportPoint.Authentication.Models {

    public class AzureLogIn_Response {

        [JsonProperty("token_type")]
        public string token_type { get; set; }

        [JsonProperty("scope")]
        public string scope { get; set; }

        [JsonProperty("expires_in")]
        public string expires_in { get; set; }

        [JsonProperty("ext_expires_in")]
        public string ext_expires_in { get; set; }

        [JsonProperty("expires_on")]
        public string expires_on { get; set; }

        [JsonProperty("not_before")]
        public string not_before { get; set; }

        [JsonProperty("resource")]
        public string resource { get; set; }

        [JsonProperty("access_token")]
        public string access_token { get; set; }

        [JsonProperty("refresh_token")]
        public string refresh_token { get; set; }
    }
}
