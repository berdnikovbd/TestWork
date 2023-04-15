using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerCore
{
    public interface ILoggerService
    {
        public void Debug(string message);
        public void Error(Exception exception);
        public void Fatal(Exception exception);
        public void Exception(Exception exception);
        public void Warn(string message);
        public void Info(string message);
    }
}
