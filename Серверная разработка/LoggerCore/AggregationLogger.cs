using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace LoggerCore
{
    public class AggregationLogger : ILogger
    {
        public List<ILogger> Loggers { get; init; }

        public AggregationLogger(params ILogger[] loggers)
        {
            Loggers = new List<ILogger>(loggers);
        }

        public void LogMessage(string source, string text, LogMessageSeverity severity)
        {
            foreach (var logger in Loggers)
            {
                logger.LogMessage(source, text, severity);
            }
        }

        public void LogException(string source, Exception exception, bool isCritical)
        {
            foreach (var logger in Loggers)
            {
                logger.LogException(source, exception, isCritical);
            }
        }
    }
}
