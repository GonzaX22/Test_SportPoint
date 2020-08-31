using SportPoint.Framework;
using SportPoint.Features.LogIn;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportPoint.Features.Home
{
    public class HomeViewModel : BaseStateAwareViewModel<HomeViewModel.State> {
        
        public enum State {
            EverythingOK,
            Error,
        }

        public HomeViewModel() {
            IsBusy = true;

            // subscribe any domain here
            MessagingCenter.Subscribe<LogInViewModel>(
                this,
                LogInViewModel.LogInFinishedMessage,
                _ => LoadCommand.Execute(null));

            MessagingCenter.Subscribe<SignUpViewModel>(
                this,
                SignUpViewModel.SignUpFinishedMessage,
                _ => LoadCommand.Execute(null));

            
        }

        public bool IsNoOneLoggedIn => !AuthenticationService.IsAnyOneLoggedIn;

        public ICommand LoadCommand => new AsyncCommand(_ => LoadDataAsync());

        public override async Task InitializeAsync() {
            await base.InitializeAsync();

            if (IsNoOneLoggedIn) {
                await App.NavigateModallyToAsync(new LogIn.HomePage());
                IsBusy = false;
            }
        }

        public override async Task UninitializeAsync() {
            await base.UninitializeAsync();
        }

        private async Task LoadDataAsync() {
            await base.UninitializeAsync();
        }
    }
}
