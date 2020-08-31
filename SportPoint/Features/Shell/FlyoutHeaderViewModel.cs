using SportPoint.Features.Settings;
using SportPoint.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportPoint.Features.Shell
{
    public class FlyoutHeaderViewModel : BaseViewModel {

        public string Username
        {
            get => UserSettings.UserName;
            set => SetAndRaisePropertyChangedIfDifferentValues(ref UserSettings.UserName, value);
        }

        public string DisplayName
        {
            get => UserSettings.DisplayName;
            set => SetAndRaisePropertyChangedIfDifferentValues(ref UserSettings.DisplayName, value);
        }

    }
}
