using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CCSWE.nanoFramework.Hosting.Logging
{
    // TODO: Move to a CCSWE.nanoFramework.Logging library
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLogging(this IServiceCollection services, LoggerOptions? options = null)
        {
            if (options is null)
            {
#if DEBUG
                options = new LoggerOptions(LogLevel.Trace);
#else
                options = new LoggerOptions(LogLevel.Warning);
#endif
            }

            services.AddSingleton(typeof(ILogger), typeof(DebugLogger));
            //services.AddSingleton(typeof(ILoggerFactory), typeof(DebugLoggerFactory));
            services.AddSingleton(typeof(LoggerOptions), options);

            LoggerFormatter.Initialize();

            return services;
        }
    }
}
