using LoggerExample.Services;
using LoggerExample.Utils.Loggers;
using LoggerExample.Views;
using SmartLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExample.Controllers
{
    public class DoubleDivisionController
    {
        public DoubleDivisionController() 
        {
            
        }

        public Response Get(double x, double y, DoubleDivisionService service, DataService dataService)
        {
            Log.Info<DoubleDivisionController>($"Получен запрос id = id_запроса на получение результата деления {x} и {y}");

            var xN = dataService.GetDoubleNumber(x);
            var yN = dataService.GetDoubleNumber(y);

            var result = service.Divide(xN, yN);

            return new DoubleNumberView().View(result);
        }
    }
}
