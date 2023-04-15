using LoggerExample.Models;
using LoggerExample.Utils.Loggers;
using SmartLogging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExample.Services
{
    public class SumIntNumberService
    {
        public SumIntNumberService() { }

        public IntNumber SumIntNumber(IntNumber x, IntNumber y) 
        {
            var result = new IntNumber(x.Value + y.Value);

            if (result.Value >= int.MaxValue - 1000)
                Log.Warn<SumIntNumberService>($"Сумма близка к переполнению");

            Log.Info<SumIntNumberService>($"Суммирование {x.Value} и {y.Value} прошло успешно");

            return result;
        }
    }
}
