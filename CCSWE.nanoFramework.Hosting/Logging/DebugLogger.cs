﻿using System;
using System.Reflection;
using Microsoft.Extensions.Logging;

namespace CCSWE.nanoFramework.Hosting.Logging
{
    // TODO: Move to a CCSWE.nanoFramework.Logging library
    /// <summary>
    /// A logger that prints to the debug console
    /// </summary>
    public class DebugLogger : ILogger
    {
        /// <summary>
        /// Creates a new instance of the <see cref="DebugLogger"/>
        /// </summary>
        /// <param name="loggerOptions">The logger options</param>
        public DebugLogger(LoggerOptions? loggerOptions) : this(string.Empty, loggerOptions is not null ? loggerOptions.MinLogLevel : LogLevel.Debug)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DebugLogger"/>
        /// </summary>
        /// <param name="loggerName">The logger name</param>
        /// <param name="loggerOptions">The logger options</param>
        private DebugLogger(string loggerName, LoggerOptions? loggerOptions): this(loggerName, loggerOptions is not null ? loggerOptions.MinLogLevel : LogLevel.Debug)
        {
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DebugLogger"/>
        /// </summary>
        /// <param name="loggerName">The logger name</param>
        /// <param name="minLogLevel">The minimum <see cref="LogLevel"/></param>
        private DebugLogger(string loggerName, LogLevel minLogLevel = LogLevel.Debug)
        {
            LoggerName = loggerName;
            MinLogLevel = minLogLevel;
        }

        /// <summary>
        /// Name of the logger
        /// </summary>
        public string LoggerName { get; }

        /// <summary>
        /// Sets the minimum log level
        /// </summary>
        public LogLevel MinLogLevel { get; set; }

        /// <inheritdoc />
        public bool IsEnabled(LogLevel logLevel) => logLevel >= MinLogLevel;

        /// <inheritdoc />
        public void Log(LogLevel logLevel, EventId eventId, string state, Exception? exception, MethodInfo? format)
        {
            if (!IsEnabled(logLevel))
            {
                return;
            }

            string msg;
            if (format == null)
            {
                msg = exception is null ? state : $"{state} {exception}";
            }
            else
            {
                msg = (string)format.Invoke(null, new object?[] { LoggerName, logLevel, eventId, state, exception });
            }

            Console.WriteLine(msg);
        }

        public static ILogger Create(string loggerName) => new DebugLogger(loggerName);
        public static ILogger Create(string loggerName, LoggerOptions loggerOptions) => new DebugLogger(loggerName, loggerOptions);
    }
}
