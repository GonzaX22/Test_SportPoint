using Microsoft.Graph;
using SportPoint.Features.Home;
using SportPoint.Features.Localization;
using SportPoint.Features.LogIn.Models;
using SportPoint.Features.Settings;
using SportPoint.Features.Shell;
using SportPoint.Framework;
using SportPoint.Helpers;
using System;
using System.Linq;
using System.Net;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportPoint.Features.LogIn
{
    public class LogInViewModel : BaseViewModel {

        #region Properties

        public const string LogInFinishedMessage = nameof(LogInFinishedMessage);

        private string username;
        private string password;
        private string displayName;

        public string Username {
            get => username;
            set => SetAndRaisePropertyChangedIfDifferentValues(ref username, value);
        }

        public string Password {
            get => password;
            set => SetAndRaisePropertyChangedIfDifferentValues(ref password, value);
        }

        public string DisplayName {
            get => displayName;
            set => SetAndRaisePropertyChangedIfDifferentValues(ref displayName, value);
        }

        #endregion

        #region Commands
        public ICommand LogInCommand => new AsyncCommand(LogInAsync);
        #endregion

        #region Private Methods

        //        public override async Task InitializeAsync() {
//            if (DefaultSettings.ForceAutomaticLogin) {
//                IsBusy = true;

//                // We simulate someone typing her credentials
//                await Task.Delay(TimeSpan.FromSeconds(0.5f));
//                Email = "test@sportpoint.onmicrosoft.com";
//                Password = "123";
//                LogInCommand.Execute(null);
//            }
//            await base.InitializeAsync();
//        }

        //public override async Task UninitializeAsync() {
        //    await base.UninitializeAsync();
        //    MessagingCenter.Send(this, LogInFinishedMessage);
        //}

        private async Task LogInAsync() {
            // set some harcoded values for testing purposes
            //this.Email = "cloudadmin@sportpointb2c.onmicrosoft.com";
            //this.Password = "Micheal30";
          /*
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) {
                XSnackService.ShowMessage(Resources.Snack_Message_InvalidUsernameOrPassword);
                return;
            }
            */
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                
                await App.Current.MainPage.DisplayAlert("¡Atención!", Resources.Snack_Message_InvalidUsernameOrPassword, "OK");
            }

            //var result = await TryExecuteWithLoadingIndicatorsAsync(
            //    AuthenticationService.LogInAsync(
            //        username.ToLower() + GlobalSettings.AzureDomainName,
            //        new NetworkCredential(string.Empty, password).SecurePassword));

            //if (result) {
            //    App.Current.MainPage = new TheShell();
            //    await App.NavigateModallyBackAsync();
            //}

            try { 
            var userLoggedIn = await AuthenticationService.LogInAsync(
                username.ToLower() + GlobalSettings.AzureDomainName,
                new NetworkCredential(string.Empty, password).SecurePassword);

                // map user's details
                DisplayName = userLoggedIn.displayName;
               
                //Go to Main Page 
                App.Current.MainPage = new TheShell();
                await App.NavigateModallyBackAsync();

                
                }
            /*
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            */    
            
            catch (System.InvalidOperationException ex) {
                Console.WriteLine(ex.Message.ToString());

                await App.Current.MainPage.DisplayAlert("¡Atención!", Resources.Snack_Message_Login_UserAndPasswordValuesNotMatches, "OK");
                
              }  

            
             

            





            

        }

        #endregion
    }
}
