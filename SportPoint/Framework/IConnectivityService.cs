using System;
using System.Collections.Generic;
using System.Text;

namespace SportPoint.Framework
{
    public interface IConnectivityService {
        bool IsThereInternet { get; }
    }
}
