using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk.Data.Exceptions
{
    /// <summary>
    /// Base class for Data layer exceptions
    /// </summary>
    public class BaseDataException : System.Exception
    {
        public BaseDataException() : base() { }
        public BaseDataException(string message) : base(message) { }
        public BaseDataException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
