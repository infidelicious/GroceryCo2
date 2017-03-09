using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk.Model.Exceptions.Validation
{
    public class InvalidDateTimeCastException : BaseValidationException
    {
        public InvalidDateTimeCastException() : base() { }
        public InvalidDateTimeCastException(string message) : base(message) { }
        public InvalidDateTimeCastException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
