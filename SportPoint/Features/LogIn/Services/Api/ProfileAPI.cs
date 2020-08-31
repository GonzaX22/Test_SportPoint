using RestSharp;
using SportPoint.Features.LogIn.Models;
using SportPoint.Features.Settings;
using SportPoint.Helpers;
using System.Threading.Tasks;

namespace SportPoint.Features.LogIn
{
    public class ProfileAPI : IProfilesAPI {


        /// <summary>
        /// Get list of users using a valid access token.
        /// </summary>
        /// <returns>Returns a list of users details.</returns>
        public async Task<ProfilesResp> GetUsersAsync() {
            var client = new RestClient("https://graph.microsoft.com/v1.0/users");
            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer "+ GlobalSettings.AccessToken);
            IRestResponse response = await client.ExecuteAsync(request);

            var loginResponse = JsonHelper.ToClass<ProfilesResp>(response.Content);
            return loginResponse;
        }


        /// <summary>
        /// Get a users using a valid access token.
        /// </summary>
        /// <returns>Returns the user detail</returns>
        public async Task<ProfileResp> GetUserAsync() {
            var client = new RestClient("https://graph.microsoft.com/v1.0/me");
            client.Timeout = -1;

            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "Bearer " + GlobalSettings.AccessToken);
            IRestResponse response = await client.ExecuteAsync(request);

            var loginResponse = JsonHelper.ToClass<ProfileResp>(response.Content);
            return loginResponse;
        }


        /// <summary>
        /// Creates a user using a <paramref name="profile"/> as parameter.
        /// </summary>
        /// <param name="profile"></param>
        /// <returns></returns>
        public async Task<ProfileResp> CreateUserAsync(ProfileReq profile) {
            var client = new RestClient("https://graph.microsoft.com/v1.0/users/");
            client.Timeout = -1;
            var jsonData = JsonHelper.FromClass(profile);
            
            var request = new RestRequest(Method.POST);
            request
                .AddHeader("Authorization", "Bearer " + GlobalSettings.AccessToken)
                .AddHeader("Content", "application/json")
                .AddHeader("Content-Type", "application/json")
                .AddParameter("application/json", jsonData, ParameterType.RequestBody);
            IRestResponse response = await client.ExecuteAsync(request);

            var profileResponse = JsonHelper.ToClass<ProfileResp>(response.Content);
            return profileResponse;
        }
        
    }
}
