using RestSharp;
using SportPoint.Features.LogIn.Models;
using SportPoint.Features.Settings;
using SportPoint.Helpers;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SportPoint.Features.LogIn
{
    public class IdentityAPI : IIdentityAPI {

        /// <summary>
        /// Get a valid access token using credentials.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<TokenResp> GetTokenAsync(TokenReq request) {
            var client = new RestSharp.RestClient(GlobalSettings.AzureLoginEndpoint);
            client.Timeout = -1;

            var internalRequest = new RestSharp.RestRequest(RestSharp.Method.POST);
            internalRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            internalRequest.AddHeader("Cookie", "x-ms-gateway-slice=prod; stsservicecookie=ests; fpc=AhfW_FJrHCJGl1Lr3XFEqOjhvS2OAQAAAPhsttYOAAAA");
            internalRequest
                .AddParameter("grant_type", request.GrantType)
                .AddParameter("username", request.Username)
                .AddParameter("password", new System.Net.NetworkCredential(string.Empty, request.Password).Password)
                .AddParameter("client_id", GlobalSettings.ClientId)
                .AddParameter("resource", GlobalSettings.MsGraphResourceEndpoint);

            RestSharp.IRestResponse response = await client.ExecuteAsync(internalRequest);
            return JsonHelper.ToClass<TokenResp>(response.Content);
        }

      
        /// <summary>
        /// Get a valid access token using application credentials.
        /// </summary>
        /// <returns></returns>
        public async Task<TokenResp> GetTokenAsync() {
            var client = new RestSharp.RestClient(GlobalSettings.AzureLoginMsOnlineEndpoint);
            client.Timeout = -1;

            var internalRequest = new RestSharp.RestRequest(RestSharp.Method.POST);
            internalRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            internalRequest.AddHeader("Cookie", "stsservicecookie=ests; x-ms-gateway-slice=estsfd; fpc=Ar8LiulPgZ5CpGJ2VSD-M7ldt19hAQAAAMKFttYOAAAA");
            internalRequest
                .AddParameter("client_id", GlobalSettings.ClientId)
                .AddParameter("state", "12345")
                .AddParameter("client_secret", GlobalSettings.ClientSecretId)
                .AddParameter("grant_type", "client_credentials")
                .AddParameter("scope", "https://graph.microsoft.com/.default");

            RestSharp.IRestResponse response = await client.ExecuteAsync(internalRequest);
            return JsonHelper.ToClass<TokenResp>(response.Content);
        }
        
    }
}
