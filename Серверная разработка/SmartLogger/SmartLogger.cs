using LoggerCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogging
{
    public class SmartLogger : ISmartLogger
    {
        public ILoggerServiceCollection? LoggerServiceCollection { get; init; }

        public virtual void Debug<T>(string message)
        {
#if DEBUG
            var logger = GetLoggerService<T>();
            logger?.Debug(message);
#endif
        }

        public virtual void Exception<T>(Exception exception)
        {
            var logger = GetLoggerService<T>();
            logger?.Exception(exception);
        }

        public virtual void Fatal<T>(Exception exception)
        {
            var logger = GetLoggerService<T>();
            logger?.Fatal(exception);
        }

        public virtual void Error<T>(Exception exception)
        {
            var logger = GetLoggerService<T>();
            logger?.Error(exception);
        }

        public virtual void Warn<T>(string message)
        {
            var logger = GetLoggerService<T>();
            logger?.Warn(message);
        }

        public virtual void Info<T>(string message)
        {
            var logger = GetLoggerService<T>();
            logger?.Info(message);
        }

        private ILoggerService? GetLoggerService<T>()
        {
            return LoggerServiceCollection?.GetLoggerService<T>();
        }

        public SmartLogger(ILoggerServiceCollection loggerServiceCollection)
        {
            LoggerServiceCollection = loggerServiceCollection;
        }
    }
}
