using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerCore
{
    public class LoggerService : ILoggerService
    {
        public string Source { get; init; } = String.Empty;
        public LoggerLevel LoggerLevel { get; init; } = LoggerLevel.All;

        public ILogger Logger { get; init; } = null!;

        public virtual void Error(Exception exception)
        {
            if (LoggerLevel <= LoggerLevel.Error)
            {
                var isCritical = false;

                Logger.LogException(Source, exception, isCritical);
            }
        }

        public virtual void Debug(string message)
        {
            #if DEBUG
                if (LoggerLevel <= LoggerLevel.Debug)
                Logger.LogMessage(Source, message, LogMessageSeverity.Debug);
            #endif
        }

        public virtual void Info(string message)
        {
            if (LoggerLevel <= LoggerLevel.Info)
                Logger.LogMessage(Source, message, LogMessageSeverity.Info);
        }

        public virtual void Warn(string message)
        {
            if (LoggerLevel <= LoggerLevel.Warn)
                Logger.LogMessage(Source, message, LogMessageSeverity.Warning);
        }

        public void Fatal(Exception exception)
        {
            if (LoggerLevel <= LoggerLevel.Fatal)
            {
                var isCritical = true;

                Logger.LogException(Source, exception, isCritical);
            }
        }

        public virtual void Exception(Exception exception)
        {
            if (LoggerLevel == LoggerLevel.Off)
                return;

            if (LoggerLevel == LoggerLevel.Fatal)
            {
                Fatal(exception);
            }
            else
            {
                Error(exception);
            }
        }

        public LoggerService(string source, LoggerLevel loggerLevel, ILogger logger)
        {
            Source = source;
            LoggerLevel = loggerLevel;
            Logger = logger;
        }

    }
}
