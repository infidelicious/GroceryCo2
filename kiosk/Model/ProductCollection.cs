using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using kiosk.Entity;

namespace kiosk.Model
{
    public class ProductCollection : System.ComponentModel.BindingList<Product>, IProductCollection
    {
        public IProduct AddNew(string name)
        {
            IProduct item = AddNew();
            item.Name = name;
            return (IProduct)item;
        }
    }
}
