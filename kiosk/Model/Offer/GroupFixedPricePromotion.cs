using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kiosk.Entity;

namespace kiosk.Model.Offer
{
    public class GroupFixedPricePromotion : Promotion
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        protected override void ApplyImplementation(OrderLineItem lineItem, DateTime orderDate, IGroceryOrder groceryOrder)
        {
            int groups = 0;
            if(lineItem.Quantity >= Quantity)
            {
                lineItem.Promotion = this;
                OrderLineItem workingItem = null;

                groups = lineItem.Quantity / Quantity;
                if (groups > 0)
                {
                    workingItem = groceryOrder.LineItems.AddNew() as OrderLineItem;
                    //TODO: re-use the catalog instead of re-coding this.  figure out a more elegant method.
                    workingItem.Product = Product;
                    workingItem.Quantity = groups * Quantity;
                    workingItem.ListPrice = lineItem.ListPrice;
                    workingItem.Promotion = this;

                    lineItem.Quantity -= workingItem.Quantity;

                    if (lineItem.Quantity == 0)
                        groceryOrder.LineItems.Remove(lineItem);
                }
                else
                    workingItem = lineItem;

                workingItem.OrderPrice = Price;
                workingItem.OverridePrice(true, Convert.ToDecimal(groups) * Price);
            }
        }
    }
}
