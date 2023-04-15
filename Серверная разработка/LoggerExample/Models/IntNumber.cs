using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerExample.Utils.Loggers;
using SmartLogging;

namespace LoggerExample.Models
{
    public class IntNumber : IViewable
    {
        public IntNumber(int number)
        {
            Value = number;
            Log.Debug<IntNumber>(string.Format("IntNumber {0} создано.", Value));
        }

        public int Value { get; set; }

        public string ToView()
        {
            return Value.ToString();
        }
    }
}
