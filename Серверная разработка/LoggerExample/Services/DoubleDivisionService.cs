using LoggerExample.Models;
using LoggerExample.Utils.Loggers;
using SmartLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExample.Services
{
    public class DoubleDivisionService
    {
        public DoubleDivisionService() { }

        public DoubleNumber Divide(DoubleNumber x, DoubleNumber y) 
        {
            if (y.Value == 0.0)
                throw new DivideByZeroException();

            double result;

            result = x.Value / y.Value;

            return new DoubleNumber(x.Value / y.Value);
        }
    }
}
