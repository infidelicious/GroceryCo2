using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk.Model
{
    public class OrderLineItemCollection : System.ComponentModel.BindingList<OrderLineItem>, Entity.IOrderLineItemCollection
    {
        private GroceryOrder _groceryOrder = null;

        public OrderLineItemCollection() { }

        public OrderLineItemCollection(GroceryOrder groceryOrder)
        {
            _groceryOrder = groceryOrder;
        }

        public void AddItems(Entity.IOrderLineItemCollection newItems)
        {
            try
            {
                foreach (OrderLineItem item in newItems)
                    Add(item);
            }
            catch(Exception ex)
            {
                //TODO: add logging
            }
        }
    }
}
