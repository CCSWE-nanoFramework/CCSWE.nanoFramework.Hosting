using Microsoft.Extensions.Logging;

namespace CCSWE.nanoFramework.Hosting.Logging
{
    // TODO: Move to a CCSWE.nanoFramework.Logging library
    // TODO: Add option to register factory?
    public class LoggerOptions
    {
        public LogLevel MinLogLevel { get; }

        public LoggerOptions(LogLevel minLogLevel)
        {
            MinLogLevel = minLogLevel;
        }
    }
}
