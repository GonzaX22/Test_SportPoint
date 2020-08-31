using Xamarin.Essentials;

namespace SportPoint.Framework {

    internal class ConnectivityService : IConnectivityService {
        public bool IsThereInternet => Connectivity.NetworkAccess == NetworkAccess.Internet;
    }
}
