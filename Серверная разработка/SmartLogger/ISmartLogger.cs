using LoggerCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLogging
{
    public interface ISmartLogger
    {
        public void Debug<T>(string message);
        public void Info<T>(string message);
        public void Warn<T>(string message);
        public void Error<T>(Exception exception);
        public void Fatal<T>(Exception exception);
        public void Exception<T>(Exception exception);
    }
}
