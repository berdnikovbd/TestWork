using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace LoggerExample.Views
{
    public class Response
    {
        public string Value { get; set; }
        public Response(string value) 
        {
            Value = value; 
        }
    }
}
