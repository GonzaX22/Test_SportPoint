using SportPoint.Framework;
using System.Windows.Input;

namespace SportPoint.Features.LogIn
{
    public class HomeViewModel : BaseViewModel {
        
        public const string RedirectMessage = nameof(RedirectMessage);

        //public ICommand OnPressSignInCommand => new AsyncCommand(_ => App.NavigateModallyToAsync(new LogInPage()));
        public ICommand OnPressSignInCommand => new AsyncCommand(_ => App.NavigateModallyToAsync(new LogInPage(), true));
        public ICommand OnPressSignUpCommand => new AsyncCommand(_ => App.NavigateModallyToAsync(new SignUpPage(), true));

        //public override async Task InitializeAsync() {
        //    await base.InitializeAsync();
        //}

        //public override async Task UninitializeAsync() {
        //    await base.UninitializeAsync();
        //    MessagingCenter.Send(this, RedirectMessage);
        //}
    }
}
