using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerCore
{
    public class LoggerServiceCollection : ILoggerServiceCollection
    {
        public Dictionary<string, ILoggerService> Loggers { get; private set; } = new();

        public virtual ILoggerService? GetLoggerService<T>()
       {
            var fullName = typeof(T).FullName!;

            ILoggerService? service = GetLoggerService(fullName);

            if (service != null)
            {
                return service;
            }

            var splittedName = fullName.Split('.').AsEnumerable();
            splittedName = splittedName.SkipLast(1);

            while (splittedName.Count() > 0)
            {
                // Если логгера нет - идем вверх по иерархии.
                var findingName = String.Join('.', splittedName);

                if (Loggers.TryGetValue(findingName, out service))
                {
                    return service;
                }

                splittedName = splittedName.SkipLast(1);
            }

            // Логгер по умолчанию.
            if (Loggers.TryGetValue(String.Empty, out service))
            {
                return service;
            }

            return null;
        }

        public virtual ILoggerService? GetLoggerService(string loggerServiceName)
        {
            ILoggerService? service;
            
            if (Loggers.TryGetValue(loggerServiceName, out service))
            {
                return service;
            }

            return null;
        }

        public virtual void AddLoggerService<T>(ILoggerService loggerService)
        {
            var fullName = typeof(T).FullName!;

            AddLoggerService(fullName, loggerService);
        }

        public virtual void AddLoggerService(string loggerServiceName, ILoggerService loggerService)
        {
            if (loggerService == null) 
            {
                throw new ArgumentNullException("logger");
            }

            Loggers.Add(loggerServiceName, loggerService);
        }

        public void RemoveLoggerService(string loggerServiceName)
        {
            if (loggerServiceName != null)
                Loggers.Remove(loggerServiceName);
        }

        public void RemoveLoggerService<T>()
        {
            var fullName = typeof(T).FullName!;

            RemoveLoggerService(fullName);
        }

        public LoggerServiceCollection()
        {
        }

    }
}
