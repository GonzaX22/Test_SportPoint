using Xamarin.Forms;

namespace SportPoint.Features.LogIn {

    public partial class HomePage {

        public HomePage() {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }

        protected override bool OnBackButtonPressed() {
            return true;
        }
    }
}