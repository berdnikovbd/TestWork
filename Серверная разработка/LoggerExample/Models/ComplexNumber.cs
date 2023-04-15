using LoggerExample.Utils.Loggers;
using SmartLogging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerExample.Models
{
    public class ComplexNumber : IViewable
    {
        public ComplexNumber(double a, double b, int i)
        {
            A = new DoubleNumber(a);
            B = new DoubleNumber(b);
            this.i = new IntNumber(i);

            Log.Debug<ComplexNumber>($"ComplexNumber {a} + {b} * {i} created.");
        }

        public DoubleNumber A { get; set; }

        public DoubleNumber B { get; set; }   

        public IntNumber i { get; set; }

        public string ToView()
        {
            throw new NotImplementedException();
        }
    }
}
