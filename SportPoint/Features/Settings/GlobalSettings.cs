using Microsoft.IdentityModel.Clients.ActiveDirectory;
using SportPoint.Features.LogIn.Models;

namespace SportPoint.Features.Settings
{
    public static class GlobalSettings {

        public const string ApiAuthorizationHeader = "Authorization";
        public static string AccessToken = string.Empty;
        //public static AzureResponse LogInAzureResponse { get; set; }

        public const string AppCenterAndroidSecret = "__ENTER_YOUR_ANDROID_APPCENTER_SECRET_HERE__";
        public const string AppCenteriOSSecret = "__ENTER_YOUR_IOS_APPCENTER_SECRET_HERE__";
        
        // Azure settings
        public const string ClientId = "b68f7dee-4098-4f3f-a9db-36a8b71305aa";
        public const string ClientSecretId = "0~i65niOs.I2_UySbT98~3FFpqqX-AadVHOv";
        public const string AzureLoginEndpoint = "https://login.windows.net/common/oauth2/token";
        public const string AzureLoginMsOnlineEndpoint = "https://login.microsoftonline.com/sportpointb2c.onmicrosoft.com/oauth2/v2.0/token";
        public const string MsGraphResourceEndpoint = "https://graph.microsoft.com";
        public const string SignUpSignInPolicy = "B2C_1_SignUpSignIn";
        public const string PasswordResetPolicy = "B2C_1_PasswordReset";
        public const string EditProfilePolicy = "B2C_1_EditProfile";
        public const string AzureDomainName = "@sportpointb2c.onmicrosoft.com";

        public const bool UseFakeAPIs = UITestMode || DebugMode;
        public const bool UseFakeAuthentication = UITestMode || DebugMode;

        //public const bool ForceAutomaticLogin = !UITestMode && DebugMode;
        public const bool ForceAutomaticLogin = false;
        public const bool BreakNetworkRandomly = !UITestMode && DebugMode;
        public const bool AndroidDebuggable = DebugMode;
        public const bool UseDebugLogging = UITestMode || DebugMode;
        public const bool EnableARDiagnostics = DebugMode;        

        #region DebugMode
        public const bool DebugMode =
#if DEBUG 
            true;
#else
            false;
#endif
        #endregion

        #region UITestMode
        public const bool UITestMode =
#if IS_UI_TEST
            true;
#else
            false;
#endif
        #endregion

        public static string RootApiUrl { get; set; } = "__ENTER_YOUR_HTTPS_ROOT_API_URL_HERE__";

        public static string RootWebApiUrl { get; set; } = "__ENTER_YOUR_HTTPS_WEBBFF_ROOT_API_URL_HERE__";

        
    }
}
