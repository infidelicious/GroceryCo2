using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk.Model
{
    public class OrderLineItem : Entity.IOrderLineItem
    {
        private decimal _netPrice = decimal.Zero;
        private bool _overrideNetPrice = false;

        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal ListPrice { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal NetPrice
        {
            get
            {
                if (_overrideNetPrice)
                    return _netPrice;
                else
                    _netPrice = Quantity * OrderPrice;

                return _netPrice;
            }
        }
        public Entity.Offer.IPromotion Promotion { get; set; }
        internal void OverridePrice(bool overridePrice, decimal newNetPrice)
        {
            _overrideNetPrice = overridePrice;
            if (_overrideNetPrice)
                _netPrice = newNetPrice;
        }
    }
}
