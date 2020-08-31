using System;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {

        public static string Token = null;

        static void Main(string[] args)
        {
            try
            {
                GetAccessTokenAsync().GetAwaiter().GetResult();

                //Console.WriteLine("Token: " + Token);
                //Console.WriteLine("Please any key to terminate the program");
                //Console.ReadKey();
            }
            catch (Exception ex)
            {
                //Console.ForegroundColor = ConsoleColor.Red;
                //Console.WriteLine(ex.Message);
                //Console.ResetColor();
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static async Task GetAccessTokenAsync() {

            var client = new RestSharp.RestClient("https://login.windows.net/common/oauth2/token");
            client.Timeout = -1;
            var internalRequest = new RestSharp.RestRequest(RestSharp.Method.POST);
            internalRequest.AddHeader("Cookie", "x-ms-gateway-slice=prod; stsservicecookie=ests; fpc=AgHuTQ6BuTdPsqX9wzbtm_AqP8ELAQAAADqYsdYOAAAA");
            internalRequest.AlwaysMultipartFormData = true;
            internalRequest.AddParameter("grant_type", "password");
            internalRequest.AddParameter("username", "cloudadmin@sportpointb2c.onmicrosoft.com");
            internalRequest.AddParameter("password", "Micheal30");
            internalRequest.AddParameter("client_id", "b68f7dee-4098-4f3f-a9db-36a8b71305aa");
            internalRequest.AddParameter("resource", "https://graph.microsoft.com");
            RestSharp.IRestResponse response = await client.ExecuteAsync(internalRequest);


            var jsonresult = Newtonsoft.Json.Linq.JObject.Parse(response.Content);
            Token = (string)jsonresult["access_token"];
        }




        //string hardcodedUsername = "rodrigolabarile@sportpointb2c.onmicrosoft.com";
        //string hardcodedPassword = "Micheal30";

        //string tenant = "sportpointb2c.b2clogin.com";
        //string clientId = "4b3M2JH8.g_n~rLn7Dlbn.mg28U~-Um03H";
        //string resourceHostUri = "https://management.azure.com/";
        //string aadInstance = "https://login.microsoftonline.com/{0}";

        //string authority = String.Format(CultureInfo.InvariantCulture, aadInstance, tenant);


        //var authContext = new AuthenticationContext(authority);

        //AuthenticationResult result = null;
        //try {
        //    result = await authContext.AcquireTokenAsync(resourceHostUri, clientId, new UserPasswordCredential(hardcodedUsername, hardcodedPassword));
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.StackTrace);
        //    System.Diagnostics.Debug.WriteLine(ex.Message);
        //}

        //return result;

    }
}
