using LoggerCore;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogging.Adapters.NLog
{
    public class NLogLogger : LoggerCore.ILogger
    {
        public string NLogConfigLoggerName { get; init; }

        public virtual void LogException(string source, Exception exception, bool isCritical)
        {
            var logger = LogManager.GetLogger(NLogConfigLoggerName);
            var messageBuilder = new LogEventBuilder(logger);
            var message = messageBuilder.Exception(exception).Property("source", source).Property("ex-stacktrace", exception.StackTrace).LogEvent;
            
            if (isCritical)
            {
                message.Level = LogLevel.Fatal;
                logger.Fatal(message);
            }
            else
            {
                message.Level = LogLevel.Error;
                logger.Error(message);
            }

            LogManager.Flush();
        }

        public virtual void LogMessage(string source, string text, LogMessageSeverity severity)
        {
            var logger = LogManager.GetLogger(NLogConfigLoggerName);
            var message = new LogEventInfo();
            message.Message = text;
            message.Properties.Add("source", source);

            if (severity == LogMessageSeverity.Warning)
            {
                message.Level = LogLevel.Warn;
                logger.Warn(message);
            }
            else if (severity == LogMessageSeverity.Info)
            {
                message.Level = LogLevel.Info;
                logger.Info(message);
            }
            else if (severity == LogMessageSeverity.Debug)
            {
#if DEBUG
                message.Level = LogLevel.Debug;
                logger.Debug(message);
#endif
            }

            LogManager.Flush();
        }

        public NLogLogger(string nLogConfigLoggerName)
        {
            NLogConfigLoggerName = nLogConfigLoggerName ?? throw new ArgumentNullException(nameof(nLogConfigLoggerName));
        }

        public NLogLogger()
        {
            NLogConfigLoggerName = string.Empty;
        }
    }
}
