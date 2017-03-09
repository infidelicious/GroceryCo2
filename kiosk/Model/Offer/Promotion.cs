using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk.Model.Offer
{
    // These awful Attributes are needed for the .net xml serializer in order to handle subclasses
    // Having these here prevents separating Promotions into their own assembly which would be
    // handy for dynamically adding promotion types without changing/rebuilding/releasing the core Model assembly
    // A better serialization library would be able to handle this without the incestuous cross referencing.
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(kiosk.Model.Offer.SimplePricePromotion))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(kiosk.Model.Offer.GroupFixedPricePromotion))]
    public abstract class Promotion : kiosk.Entity.Offer.IPromotion
    {
        public Promotion()
        {
            Period = new EffectiveDate(DateTime.MinValue, null);
        }
        public string Product { get; set; }
        public EffectiveDate Period { get; set; }

        public void Apply(OrderLineItem lineItem, DateTime orderDate, Entity.IGroceryOrder groceryOrder)
        {
            if (IsApplicable(lineItem, orderDate, groceryOrder))
            {
                ApplyImplementation(lineItem, orderDate, groceryOrder);
            }
        }

        protected abstract void ApplyImplementation(OrderLineItem lineItem, DateTime orderDate, Entity.IGroceryOrder groceryOrder);

        protected bool IsApplicable(OrderLineItem lineItem, DateTime orderDate, Entity.IGroceryOrder groceryOrder)
        {
        bool result = false;
            result = (Product == lineItem.Product
                && orderDate >= Period.From
                && (Period.To == null || orderDate <= Period.To));

            return result;
        }
    }
}
