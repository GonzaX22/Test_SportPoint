using Xamarin.Essentials;
using Xamarin.Forms;

namespace SportPoint.Features.LogIn {

    public partial class LogInPage {

        public LogInPage() {
            //NavigationPage.SetHasNavigationBar(this, true);
            InitializeComponent();
            BindingContext = new LogInViewModel();
        }

        //protected override bool OnBackButtonPressed() {
        //    return true;
        //}

    }
}