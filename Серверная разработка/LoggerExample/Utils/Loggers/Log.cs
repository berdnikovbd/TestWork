using SmartLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExample.Utils.Loggers
{
    public static class Log
    {
        public static ISmartLogger SmartLogger { get; set; }

        public static void Debug<T>(string message)
        {
#if DEBUG
            SmartLogger.Debug<T>(message);
 #endif
        }

        public static void Error<T>(Exception exception)
        {
           SmartLogger.Error<T>(exception);
        }

        public static void Warn<T>(string message)
        {
            SmartLogger.Warn<T>(message);
        }

        public static void Info<T>(string message)
        {
            SmartLogger.Info<T>(message);
        }

        public static void Fatal<T>(Exception exception)
        {
            SmartLogger.Fatal<T>(exception);
        }

        public static void Exception<T>(Exception exception)
        {
            SmartLogger.Exception<T>(exception);
        }
    }
}
