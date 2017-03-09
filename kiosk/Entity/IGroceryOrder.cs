using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk.Entity
{
    public interface IGroceryOrder
    {
        event EventHandler OrderProcessStartEvent;
        event EventHandler OrderProcessCompleteEvent;

        DateTime OrderDate { get; }
        Entity.IOrderLineItemCollection LineItems { get; }
        decimal Total { get; }
    }
}
