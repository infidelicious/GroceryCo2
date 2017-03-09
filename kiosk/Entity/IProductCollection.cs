using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk.Entity
{
    public interface IProductCollection : System.ComponentModel.IBindingList
    {
        IProduct AddNew(string name);
    }
}
