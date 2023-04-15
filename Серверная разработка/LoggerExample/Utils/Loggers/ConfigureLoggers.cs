using LoggerCore;
using LoggerExample.Services;
using SmartLogging;
using SmartLogging.Adapters;
using SmartLogging.Adapters.NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExample.Utils.Loggers
{
    public static class ConfigureLoggers
    {
        // Пример конфигурации для системы логирования.
        public static void Configure(ILoggerServiceCollection? loggerServiceCollection = null)
        {
            if (loggerServiceCollection == null)
            {
                loggerServiceCollection = new LoggerServiceCollection();
            }

            // Название логгера в конфиге NLog.
            const string NLogConfigName = "NLog";

            var NLogLogger = new NLogLogger(NLogConfigName);
            var consoleLogger = new ConsoleLogger();
            var agregationLogger = new AggregationLogger(NLogLogger, consoleLogger);

            // Только NLog.
            var defaultLoggerService = new LoggerService("unknown", LoggerLevel.All, NLogLogger);
            var dataReciverLoggerService = new LoggerService("Сервис БД", LoggerLevel.All, NLogLogger);

            // Только самописная консоль.
            var consoleLoggerService = new LoggerService("Я консоль", LoggerLevel.All, consoleLogger);

            // Nlog + самописная консоль.
            var modelLayerLoggerService = new LoggerService("Слой данных", LoggerLevel.Error, agregationLogger);
            var servicesLoggerService = new LoggerService("Обработчики данных", LoggerLevel.All, agregationLogger);
            
            // Для тестирования.
            var fatalErrorsLoggerService = new LoggerService("Категория для тестов: Log<T>.Exception дает fatal", LoggerLevel.Fatal, NLogLogger);
            var errorsLoggerService = new LoggerService("Категория для тестов: Log<T>.Exception дает просто error", LoggerLevel.Error, NLogLogger);
            var allLoggerService = new LoggerService("Категория с уровнем All", LoggerLevel.All, NLogLogger);
            var debugLoggerService = new LoggerService("Категория с уровнем Debug", LoggerLevel.Debug, NLogLogger);
            var infoLoggerService = new LoggerService("Категория с уровнем Info", LoggerLevel.Info, NLogLogger);
            var warnLoggerService = new LoggerService("Категория с уровнем Warn", LoggerLevel.Warn, NLogLogger);
            var errorLoggerService = new LoggerService("Категория при вызове Log<T>.Exception с уровнем error", LoggerLevel.Error, NLogLogger);
            var fatalLoggerService = new LoggerService("Категория при вызове Log<T>.Exception с уровнем fatal", LoggerLevel.Fatal, NLogLogger);
            var offLoggerService = new LoggerService("Категория с уровнем off", LoggerLevel.Off, NLogLogger);
            var aggregated = new LoggerService("Агрегация", LoggerLevel.All, agregationLogger);

            var smartLogger = new SmartLoggerBuilder()
                .SetLoggerServiceCollection(loggerServiceCollection)
                // Для примера использования.
                .AddLoggerService(string.Empty, defaultLoggerService)
                .AddLoggerService("LoggerExample.Models", modelLayerLoggerService)
                .AddLoggerService("LoggerExample.Services", servicesLoggerService)
                .AddLoggerService(typeof(Services.DataService).FullName!, dataReciverLoggerService)
                // Для тестирования.
                .AddLoggerService(typeof(ClassesForTesting.FatalErrorer).FullName!, fatalErrorsLoggerService)
                .AddLoggerService(typeof(ClassesForTesting.SimpleErrorer).FullName!, errorsLoggerService)
                .AddLoggerService(typeof(ClassesForTesting.DebugLevel).FullName!, debugLoggerService)
                .AddLoggerService(typeof(ClassesForTesting.InfoLevel).FullName!, infoLoggerService)
                .AddLoggerService(typeof(ClassesForTesting.WarnLevel).FullName!, warnLoggerService)
                .AddLoggerService(typeof(ClassesForTesting.ErrorLevel).FullName!, errorLoggerService)
                .AddLoggerService(typeof(ClassesForTesting.FatalLevel).FullName!, fatalLoggerService)
                .AddLoggerService(typeof(ClassesForTesting.OffLevel).FullName!, offLoggerService)
                .AddLoggerService(typeof(ClassesForTesting.Aggregated).FullName!, aggregated)
                .AddLoggerService(typeof(ClassesForTesting.ConsoleLogOnly).FullName!, consoleLoggerService)
                .Build();

            Log.SmartLogger = smartLogger;
        }
    }
}
