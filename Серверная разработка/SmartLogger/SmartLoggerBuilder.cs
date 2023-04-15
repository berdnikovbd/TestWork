using LoggerCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogging
{
    public class SmartLoggerBuilder
    {
        public ILoggerServiceCollection LoggerServiceCollection { get; private set; }

        public SmartLoggerBuilder SetLoggerServiceCollection(ILoggerServiceCollection LoggerServiceCollection)
        {
            this.LoggerServiceCollection = LoggerServiceCollection;
            return this;
        }

        public SmartLoggerBuilder AddLoggerService(string loggerServiceName, ILoggerService loggerService)
        {
            LoggerServiceCollection.AddLoggerService(loggerServiceName, loggerService);
            return this;
        }

        public SmartLoggerBuilder AddLoggerService<T>(ILoggerService loggerService)
        {
            LoggerServiceCollection.AddLoggerService<T>(loggerService);
            return this;
        }

        public SmartLogger Build()
        {
            return new SmartLogger(LoggerServiceCollection);
        }

        public SmartLoggerBuilder()
        {
            LoggerServiceCollection = new LoggerServiceCollection();
        }
    }
}
