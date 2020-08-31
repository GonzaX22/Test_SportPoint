using System.Threading.Tasks;
using RestSharp;
using SportPoint.Authentication.Helpers;
using SportPoint.Authentication.Models;

namespace SportPoint.Authentication
{
    public class Authentication
    {
        public static async Task<AzureLogIn_Response> ForceAuthentication() {
            var client = new RestClient("https://login.windows.net/common/oauth2/token");
            client.Timeout = -1;
            var internalRequest = new RestRequest(RestSharp.Method.POST);
            internalRequest.AddHeader("Cookie", "x-ms-gateway-slice=prod; stsservicecookie=ests; fpc=AgHuTQ6BuTdPsqX9wzbtm_AqP8ELAQAAADqYsdYOAAAA");
            internalRequest.AlwaysMultipartFormData = true;
            internalRequest.AddParameter("grant_type", "password");
            internalRequest.AddParameter("username", "cloudadmin@sportpointb2c.onmicrosoft.com");
            internalRequest.AddParameter("password", "Micheal30");
            internalRequest.AddParameter("client_id", "b68f7dee-4098-4f3f-a9db-36a8b71305aa");
            internalRequest.AddParameter("resource", "https://graph.microsoft.com");
            RestSharp.IRestResponse response = await client.ExecuteAsync(internalRequest);
            return JsonHelper.ToClass<AzureLogIn_Response>(response.Content);
        }
    }
}
