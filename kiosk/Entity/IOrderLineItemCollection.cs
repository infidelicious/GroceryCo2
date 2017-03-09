using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk.Entity
{
    public interface IOrderLineItemCollection : System.ComponentModel.IBindingList//, IEnumerator<IOrderLineItem>
    {
        void AddItems(IOrderLineItemCollection newItems);
    }
}
