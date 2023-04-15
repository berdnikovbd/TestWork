using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerCore
{
    public interface ILoggerServiceCollection
    {
        public ILoggerService? GetLoggerService<T>();
        public ILoggerService? GetLoggerService(string loggerServiceName);
        public void AddLoggerService(string loggerServiceName, ILoggerService loggerService);
        public void AddLoggerService<T>(ILoggerService loggerService);
        public void RemoveLoggerService(string loggerServiceName);
        public void RemoveLoggerService<T>();
    }
}
