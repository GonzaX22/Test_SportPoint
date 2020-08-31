using Xamarin.Forms;

namespace SportPoint.Features.LogIn {

    public partial class SignUpPage {

        public SignUpPage() {
            NavigationPage.SetHasNavigationBar(this, true);
            InitializeComponent();
            BindingContext = new SignUpViewModel();
        }

        protected override bool OnBackButtonPressed() {
            return true;
        }
    }
}