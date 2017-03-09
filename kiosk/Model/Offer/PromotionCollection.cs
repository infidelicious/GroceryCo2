using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk.Model.Offer
{
    public class PromotionCollection : System.ComponentModel.BindingList<Promotion>
    {
        public void Apply(Entity.IGroceryOrder groceryOrder)
        {
            //foreach (OrderLineItem lineItem in groceryOrder.LineItems)
            for (int idx = 0; idx < groceryOrder.LineItems.Count; idx++)
            {
                OrderLineItem lineItem = groceryOrder.LineItems[idx] as OrderLineItem;
                Apply(lineItem, groceryOrder.OrderDate, groceryOrder);
            }
        }

        private void Apply(OrderLineItem lineItem, DateTime orderDate, Entity.IGroceryOrder groceryOrder)
        {
            //foreach(Promotion promotion in this)
            for(int idx = 0; idx < this.Count; idx++)
            {
                Promotion promotion = this[idx];

                if (promotion.Product == lineItem.Product
                    && orderDate >= promotion.Period.From
                    && (promotion.Period.To == null || orderDate <= promotion.Period.To))
                {
                    promotion.Apply(lineItem, orderDate, groceryOrder);
                }
            }
        }
    }
}
