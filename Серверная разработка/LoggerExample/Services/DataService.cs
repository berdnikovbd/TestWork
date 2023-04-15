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
    public class DataService
    {
        public DataService()
        {
        }

        public IntNumber GetIntNumber(int x)
        {
            Log.Info<DataService>($"Отправлен запрос id = 777 на поиск {x}");
            Log.Info<DataService>("Запрос id = 777 успешно выполнен");
            return new IntNumber(x);
        }

        public DoubleNumber GetDoubleNumber(double x)
        {
            Log.Info<DataService>($"Отправлен запрос id = 888 на поиск {x}");
            Log.Info<DataService>("Запрос id = 888 успешно выполнен");
            return new DoubleNumber(x);
        }
    }
}
