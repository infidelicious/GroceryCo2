using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk.Data.Exceptions
{
    public class MalformedDataSourceFileException : BaseDataException
    {
        public MalformedDataSourceFileException() : base() { }
        public MalformedDataSourceFileException(string message) : base(message) { }
        public MalformedDataSourceFileException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
