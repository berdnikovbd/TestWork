using LoggerExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExample.Views
{
    public class DoubleNumberView
    {
        public DoubleNumberView()
        {
        }

        public Response View(DoubleNumber number)
        {
            var result = '?' + number.ToView() + '?';

            return new Response(result);
        }
    }
}
