using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using kiosk.Entity;

namespace kiosk.Model
{
    public class CatalogItem : Product//, ICatalogItem
    {
        private decimal? _price;

        public EffectiveDate Effective { get; set; }

        public decimal? Price
        {
            get { return _price; }
            set
            {
                //TODO: use entlib or something else to handl the simple validation.
                // If no time to do so, at least create ValidationArgumentOutOfRangeException : ArgumentOutOfRangeException
                // to distinguish this as a business rule exception rather than a technically impossible exception.
                if (value != null && ((decimal)value) < 0)
                    throw new ArgumentOutOfRangeException("\"Price\" must be greater than zero or equal to.");

                _price = value;
            }
        }

        public void PriceItem(OrderLineItem lineItem, int quantity)
        {
            lineItem.Product = Name;
            lineItem.Quantity = quantity;
            lineItem.ListPrice = (decimal)Price;
            lineItem.OrderPrice = lineItem.ListPrice;
        }
    }
}
