using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk.Entity
{
    public interface IOrderLineItem
    {
        string Product { get; set; }
        int Quantity { get; set; }
        decimal ListPrice { get; set; }
        decimal OrderPrice { get; set; }
        decimal NetPrice { get; }
        Offer.IPromotion Promotion { get; set; }
    }
}
