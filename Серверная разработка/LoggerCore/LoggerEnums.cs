using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerCore
{
    public enum LogMessageSeverity
    {
        Debug, Info, Warning, Error
    }

    public enum LoggerLevel
    {
        All, Trace, Debug, Info, Warn, Error, Fatal, Off
    }
}
