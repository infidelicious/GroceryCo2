using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kiosk.Entity;

namespace kiosk.Model.Offer
{
    public class SimplePricePromotion : kiosk.Model.Offer.Promotion
    {
        public SimplePricePromotion() : base() { }
        public decimal Price { get; set; }

        protected override void ApplyImplementation(OrderLineItem lineItem, DateTime orderDate, IGroceryOrder groceryOrder)
        {
            lineItem.Promotion = this;
            lineItem.OrderPrice = Price;
            lineItem.Promotion = this;
        }
    }
}
