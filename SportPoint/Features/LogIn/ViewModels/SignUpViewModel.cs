using SportPoint.Features.Localization;
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
    public class SignUpViewModel : BaseViewModel {

        #region Properties

        public const string SignUpFinishedMessage = nameof(SignUpFinishedMessage);

        private string givenName;
        private string surname;
        private string username;
        private string password;
        private string repeatedPassword;
        private string displayName;

        public string GivenName 
        {
            get => givenName;
            set => SetAndRaisePropertyChangedIfDifferentValues(ref givenName, value);
        }
        
        public string Surname 
        {
            get => surname;
            set => SetAndRaisePropertyChangedIfDifferentValues(ref surname, value);
        }
    
        public string Username
        {
            get => username;
            set => SetAndRaisePropertyChangedIfDifferentValues(ref username, value);

        }

        public string Password 
        {
            get => password;
            set => SetAndRaisePropertyChangedIfDifferentValues(ref password, value);
        }

        public string RepeatedPassword
        {
            get => repeatedPassword;
            set => SetAndRaisePropertyChangedIfDifferentValues(ref repeatedPassword, value);
        }

        public string DisplayName 
        {
            get => displayName;
            set => SetAndRaisePropertyChangedIfDifferentValues(ref displayName, value);
        }

        #endregion

        #region Commands
        public ICommand SignUpCommand => new AsyncCommand(SignUpAsync);
        #endregion

        #region Methods

        //public override async Task UninitializeAsync() {
        //    await base.UninitializeAsync();x  
        //    MessagingCenter.Send(this, SignUpFinishedMessage);
        //}

        private async Task SignUpAsync() {
            // set some harcoded values for testing purposes
            //this.GivenName = "Rodrigo";
            //this.Surname = "Labarile";
            //this.Username = "rlabarile";
            //this.Password = "Micheal30";
            //this.RepeatedPassword = "Micheal30";

            // run some validations
            if (
                    string.IsNullOrWhiteSpace(givenName) ||
                    string.IsNullOrWhiteSpace(surname) ||
                    string.IsNullOrWhiteSpace(username) ||
                    password is null ||
                    repeatedPassword is null)
            {
                //XSnackService.ShowMessage(Resources.Snack_Message_SignUp_EmptyValues);
                //return;

                await App.Current.MainPage.DisplayAlert("¡Atención!", Resources.Snack_Message_SignUp_EmptyValues, "OK");
            }
            if (password != repeatedPassword) {
                //XSnackService.ShowMessage(Resources.Snack_Message_SignUp_PasswordValuesNotMatches);
                //return;

                await App.Current.MainPage.DisplayAlert("¡Atención!", Resources.Snack_Message_SignUp_PasswordValuesNotMatches, "OK");
            }

            /*
            var result = await TryExecuteWithLoadingIndicatorsAsync(
                AuthenticationService.SignUpAsync(
                    StringExtensions.FirstCharToUpper(givenName),
                    StringExtensions.FirstCharToUpper(surname),
                    username.ToLower() + GlobalSettings.AzureDomainName,
                    new NetworkCredential(string.Empty, password).SecurePassword)
                );

            if (result) {
                // setting up some user settings
                //UserDetails.Username = StringExtensions.FirstCharToUpper(givenName) + " " + StringExtensions.FirstCharToUpper(surname);

                App.Current.MainPage = new TheShell();
                await App.NavigateModallyBackAsync();
            }
            */
            try
            {
                var userCreated = await AuthenticationService.SignUpAsync( 
                        StringExtensions.FirstCharToUpper(givenName),
                        StringExtensions.FirstCharToUpper(surname),
                        username.ToLower() + GlobalSettings.AzureDomainName,
                        new NetworkCredential(string.Empty, password).SecurePassword);

                // map user's details
                DisplayName = userCreated.displayName;
                //App.Current.MainPage = new TheShell();
                await App.NavigateModallyBackAsync();
            }
            catch (Exception ex) {
               // Console.WriteLine(ex.Message);

                await App.Current.MainPage.DisplayAlert("¡Atención!", ex.ToString(), "OK");
            }
           
        }

        #endregion

    }
}
