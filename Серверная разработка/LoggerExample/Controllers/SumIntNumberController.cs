using LoggerExample.Models;
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
    public class SumIntNumberController
    {
        public SumIntNumberController()
        {
            
        }

        public Response Get(int x, int y, SumIntNumberService service, DataService dataService)
        {
            Log.Info<SumIntNumberController>($"Получен запрос id = id_запроса на получение суммы {x} и {y}");

            var xN = dataService.GetIntNumber(x);
            var yN = dataService.GetIntNumber(y);

            var result = service.SumIntNumber(xN, yN);

            return new IntNumberView().View(result);
        }
    }
}
