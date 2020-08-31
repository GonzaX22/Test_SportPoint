using SportPoint.Features.LogIn;
using SportPoint.Framework;
using System.Windows.Input;

namespace SportPoint.Features.Shell
{
    internal class TheShellViewModel : BaseViewModel {

        //public ICommand PhotoCommand => new AsyncCommand(
        //    _ => App.NavigateModallyToAsync(new CameraPreviewTakePhotoPage(), animated: false));

        //public ICommand ARCommand => new AsyncCommand(
        //    _ => App.NavigateToAsync(new CameraPreviewPage(), closeFlyout: true));

        public ICommand LogOutCommand => new AsyncCommand(_ => App.NavigateModallyToAsync(new HomePage()));

        //public ICommand ProductTypeCommand => new AsyncCommand(
        //    typeId => App.GoToProductCategoryAsync(typeId as string));

        public ICommand ProfileCommand => FeatureNotAvailableCommand;

        //public ICommand SettingsCommand => new AsyncCommand(
        //    _ => App.NavigateToAsync(new SettingsPage(), closeFlyout: true));
    }
}
