using System.Threading.Tasks;
using SportPoint.Features.Common;
using SportPoint.Features.Logging;
using SportPoint.Features.LogIn;
using SportPoint.Features.LogIn.Services;
using SportPoint.Features.Shell;
using SportPoint.Framework;
using Xamarin.Forms;

namespace SportPoint
{
    public partial class App
    {
        #region Constructor
        public App() {
            InitializeComponent();
            RegisterServicesAndProviders();
            MainPage = new TheShell();
            MainPage.Navigation.PushAsync(new HomePage());
        }
        #endregion

        #region Properties
        private static NavigableElement navigationRoot;
        public static NavigableElement NavigationRoot
        {
            get => GetShellSection(navigationRoot) ?? navigationRoot;
            set => navigationRoot = value;
        }

        public static TheShell Shell => Current.MainPage as TheShell;
        #endregion

        #region Methods
        protected override void OnStart() { 
            base.OnStart();
        }
        #endregion

        #region Nagivation Methods        
        // It provides a navigatable section for elements which aren't explicitly defined within the Shell. For example,
        // ProductCategoryPage: it's accessed from the fly-out through a MenuItem but it doesn't belong to any section
        internal static ShellSection GetShellSection(Element element) {
            if (element == null) {
                return null;
            }

            var parent = element;
            var parentSection = parent as ShellSection;

            while (parentSection == null && parent != null) {
                parent = parent.Parent;
                parentSection = parent as ShellSection;
            }
            return parentSection;
        }

        internal static async Task NavigateBackAsync() => await Shell.Navigation.PopAsync();

        internal static async Task NavigateModallyBackAsync() => await Shell.Navigation.PopModalAsync();

        internal static async Task NavigateToAsync(Page page, bool closeFlyout = false) {
            if (closeFlyout) {
                await Shell.CloseFlyoutAsync();
            }
            await Shell.Navigation.PushAsync(page).ConfigureAwait(false);
        }

        internal static async Task NavigateModallyToAsync(Page page, bool animated = true) {
            await Shell.CloseFlyoutAsync();
            await Shell.Navigation.PushModalAsync(page, animated).ConfigureAwait(false);
        }
        #endregion

        #region Services and Providers
        private void RegisterServicesAndProviders()
        {
            DependencyService.Register<ConnectivityService>();
            DependencyService.Register<DebugLoggingService>();
            DependencyService.Register<RestPoolService>();
            DependencyService.Register<AzureAuthenticationService>();
        }
        #endregion

    }
}
