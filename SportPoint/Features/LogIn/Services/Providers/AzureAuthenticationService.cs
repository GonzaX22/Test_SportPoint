using System;
using System.Linq;
using System.Net;
using System.Security;
using System.Threading.Tasks;
using SportPoint.Features.Common;
using SportPoint.Features.LogIn.Models;
using SportPoint.Features.Settings;
using Xamarin.Forms;

namespace SportPoint.Features.LogIn.Services {

    public class AzureAuthenticationService : IAuthenticationService {

        #region Properties
        private readonly IRestPoolService restPoolService;
        private string authenticatedUser;

        public string AuthorizationHeader => $"Bearer " + GlobalSettings.AccessToken; 
        
        public bool IsAnyOneLoggedIn => authenticatedUser != null;
        #endregion

        #region Constructor
        public AzureAuthenticationService() {
            restPoolService = DependencyService.Get<IRestPoolService>();
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Logs in a user using <paramref name="username"/> and <paramref name="password"/> as parameters.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>Returns the user details that logged in.</returns>
        public async Task<ProfileResp> LogInAsync(string username, SecureString password) {
            // get token
            var token = await GetTokenWithUsernameAndPasswordAsync(username, password);
            GlobalSettings.AccessToken = token.access_token;

            // get profile
            var request = new TokenReq { Username = username };
            var userProfile = await restPoolService.ProfilesAPI.GetUserAsync();
            if (userProfile.id == null) {
                throw new InvalidOperationException(Localization.Resources.Snack_Message_Profile_NoProfileAvailable);
            }
            authenticatedUser = userProfile.displayName;
            return userProfile;
        }


        /// <summary>
        /// Signs in a user with some parameters such as <paramref name="userName"/>, <paramref name="password"/>, <paramref name="name"/> and <paramref name="surname"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<ProfileResp> SignUpAsync(string name, string surname, string userName, SecureString password) {
            // get token using an admin user
            var token = await GetToken();
            GlobalSettings.AccessToken = token.access_token;

            // create new user
            var user = new ProfileReq {
                accountEnabled = true,
                givenName = name,
                surname = surname,
                displayName = name +" "+ surname,
                mailNickname = name,
                userPrincipalName = userName,
                passwordProfile = new Models.PasswordProfile { forceChangePasswordNextSignIn = false, password = new NetworkCredential(string.Empty, password).Password }
            };
            var newUser = await restPoolService.ProfilesAPI.CreateUserAsync(user);

            if (newUser.userPrincipalName == null) {
                throw new InvalidOperationException(Localization.Resources.Snack_Message_Profile_NoProfileCreated);
            }
            authenticatedUser = newUser.displayName;
            return newUser;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Get a valid access token using credentials.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="securePassword"></param>
        /// <returns></returns>
        private async Task<TokenResp> GetTokenWithUsernameAndPasswordAsync(string email, SecureString securePassword) {
            var tokenReq = new TokenReq {
                Username = email,
                Password = securePassword,
                GrantType = "password"
            };

            var login = await restPoolService.IdentityAPI.GetTokenAsync(tokenReq);
            if (login.access_token == null) {
                throw new InvalidOperationException(Localization.Resources.Snack_Message_LogIn_NoTokenAvailable);
            }
            return login;
        }


        /// <summary>
        /// Get a valid access token using application credentials.
        /// </summary>
        /// <returns></returns>
        private async Task<TokenResp> GetToken() {
            var login = await restPoolService.IdentityAPI.GetTokenAsync();
            
            

            if (login.access_token == null){
                //throw new InvalidOperationException(Localization.Resources.Snack_Message_LogIn_NoTokenAvailable);
                throw new InvalidOperationException("EL token no está");
            }
            
            return login;
        }

        #endregion

    }
}
