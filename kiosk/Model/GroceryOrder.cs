using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kiosk.Model.Offer;

namespace kiosk.Model
{
    public class GroceryOrder : kiosk.Entity.IGroceryOrder
    {
        public event EventHandler OrderProcessStartEvent;
        public event EventHandler OrderProcessCompleteEvent;

        private DateTime _orderDate = DateTime.Now;
        private ProductCollection _customerOrder = null;
        private Catalog _catalog = null;
        private PromotionCollection _promotions = null;
        private OrderLineItemCollection _lineItems = null;

        public Entity.IOrderLineItemCollection LineItems
        {
            get
            {
                if (_lineItems == null)
                    _lineItems = new OrderLineItemCollection(this);

                return _lineItems;
            }
        }

        public decimal Total
        {
            get
            {
                decimal result = decimal.Zero;

                result = ((OrderLineItemCollection)LineItems).AsEnumerable().Sum(o => o.NetPrice);

                if (result < decimal.Zero) result = decimal.Zero;

                return result;
            }
        }

        public GroceryOrder() { }

        public GroceryOrder(ProductCollection customerOrder) : this(customerOrder, DateTime.Now) { }
        
        public GroceryOrder(ProductCollection customerOrder, DateTime orderDate)
        {
            _customerOrder = customerOrder;
            _orderDate = orderDate;
        }

        public GroceryOrder(ProductCollection customerOrder, DateTime orderDate, Catalog catalog, PromotionCollection promotions) : this(customerOrder, orderDate)
        {
            _catalog = catalog;
            _promotions = promotions;
        }

        public DateTime OrderDate {  get { return _orderDate; } }
        public ProductCollection CustomerOrder { get { return _customerOrder; } }
        public void Process()
        {
            try
            {
                Start();
                try
                {
                    LineItems.AddItems(_catalog.Price(_customerOrder, _orderDate));
                }
                catch(Exception ex) //TODO: catch
                {
                    throw;
                }

                _promotions.Apply(this);

                Complete();
            }
            catch(Exception ex)
            {
                //Incomplete processing With Errors
                throw;
            }
        }

        private void Start()
        {
            if (OrderProcessStartEvent != null)
                OrderProcessStartEvent(this, new EventArgs());
        }

        private void Complete()
        {
            if (OrderProcessCompleteEvent != null)
                OrderProcessCompleteEvent(this, new EventArgs());
        }
    }
}
