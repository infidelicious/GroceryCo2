using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk.Data.Exceptions
{
    public class FileNotFoundException : BaseDataException
    {
        public FileNotFoundException() : base() { }
        public FileNotFoundException(string message) : base(message) { }
        public FileNotFoundException(string message, System.Exception innerException) : base(message, innerException) { }
    }
}
