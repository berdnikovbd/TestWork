using LoggerExample.Utils.Loggers;
using SmartLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExample.Models
{
    public class DoubleNumber : IViewable
    {
        public DoubleNumber(double number)
        {
            Value = number;
            Log.Debug<DoubleNumber>(string.Format("DoubleNumber {0} создано.", Value));
        }

        public double Value { get; set; }

        public string ToView()
        {
            return Value.ToString();
        }
    }
}
