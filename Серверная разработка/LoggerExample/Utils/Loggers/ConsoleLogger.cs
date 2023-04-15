using LoggerCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExample.Utils.Loggers
{
    // Сделал только для наглядности смены ядра логгирования.
    internal class ConsoleLogger : ILogger
    { 
        public void LogException(string source, Exception exception, bool isCritical)
        {
            var critial = isCritical ? "FATAL" : "ERROR";

            Console.WriteLine($"{DateTime.UtcNow} {critial} FROM {source} TRACE {exception.StackTrace} MESSAGE {exception.Message}");
        }

        public void LogMessage(string source, string text, LogMessageSeverity severity)
        {
            var severityMassage = string.Empty;

            if (severity == LogMessageSeverity.Info)
                severityMassage = "INFO";
            else if (severity == LogMessageSeverity.Warning)
                severityMassage = "WARNING";
            else if (severity == LogMessageSeverity.Debug)
                severityMassage = "DEBUG";
            else return;

            Console.WriteLine($"{DateTime.UtcNow} {severityMassage} FROM {source} TEXT {text}");
        }
    }
}
