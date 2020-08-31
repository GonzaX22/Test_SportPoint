using System;

namespace SportPoint.Features.Logging {

    public interface ILoggingService {

        void Debug(string message);

        void Warning(string message);

        void Error(Exception exception);
    }
}
