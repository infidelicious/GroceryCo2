using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk.Model.Exceptions.Validation
{
    public class BaseValidationException : System.Exception
    {
        public BaseValidationException() : base() { }
        public BaseValidationException(string message) : base(message) { }
        public BaseValidationException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
