using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using OperationResult;
using Plugin.XSnack;
using SportPoint.Features.Common;
using SportPoint.Features.Localization;
using SportPoint.Features.Logging;
using SportPoint.Features.LogIn;
using Xamarin.Forms;

namespace SportPoint.Framework {

    public abstract class BaseViewModel : INotifyPropertyChanged {

        protected static readonly IAuthenticationService AuthenticationService;
        protected static readonly ILoggingService LoggingService;
        protected static readonly IRestPoolService RestPoolService;
        protected static readonly IXSnack XSnackService;
        protected static readonly IConnectivityService IConnectivityService;

        private bool isBusy;

        public event PropertyChangedEventHandler PropertyChanged;
        public static event PropertyChangedEventHandler PropertyChangedStatic;

        public bool IsBusy {
            get => isBusy;
            set => SetAndRaisePropertyChanged(ref isBusy, value);
        }

        public ICommand FeatureNotAvailableCommand { get; } = new AsyncCommand(ShowFeatureNotAvailableAsync);

        static BaseViewModel() {
            AuthenticationService = DependencyService.Get<IAuthenticationService>();
            LoggingService = DependencyService.Get<ILoggingService>();
            RestPoolService = DependencyService.Get<IRestPoolService>();
            XSnackService = DependencyService.Get<IXSnack>();
            IConnectivityService = DependencyService.Get<IConnectivityService>();
        }

        public virtual Task InitializeAsync() => Task.CompletedTask;

        public virtual Task UninitializeAsync() => Task.CompletedTask;

        protected static async Task ShowFeatureNotAvailableAsync() {
            await Application.Current.MainPage.DisplayAlert(
                Resources.Alert_Title_FeatureNotAvailable,
                Resources.Alert_Message_BetaApp,
                Resources.Alert_OK);
        }

        protected async Task<Status> TryExecuteWithLoadingIndicatorsAsync(
            Task operation,
            Func<Exception, Task<bool>> onError = null) =>
            await TaskHelper.Create()
                .WhenStarting(() => IsBusy = true)
                .WhenFinished(() => IsBusy = false)
                .TryWithErrorHandlingAsync(operation, onError);

        protected async Task<Result<T>> TryExecuteWithLoadingIndicatorsAsync<T>(
            Task<T> operation,
            Func<Exception, Task<bool>> onError = null) =>
            await TaskHelper.Create()
                .WhenStarting(() => IsBusy = true)
                .WhenFinished(() => IsBusy = false)
                .TryWithErrorHandlingAsync(operation, onError);

        protected void SetAndRaisePropertyChanged<TRef>(
            ref TRef field, TRef value, [CallerMemberName] string propertyName = null) {

            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        protected void SetAndRaisePropertyChangedIfDifferentValues<TRef>(
            ref TRef field, TRef value, [CallerMemberName] string propertyName = null)
            where TRef : class {

            if (field == null || !field.Equals(value)) {
                SetAndRaisePropertyChanged(ref field, value, propertyName);
            }
        }

    }
}
