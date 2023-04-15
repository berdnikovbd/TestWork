using LoggerExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExample.Views
{
    public class IntNumberView
    {
        public IntNumberView()
        {
        }

        public Response View(IntNumber number)
        {
            var result = '#' + number.ToView() + '#';

            return new Response(result);
        }
    }
}
