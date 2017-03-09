using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kiosk.Entity;

namespace kiosk.Model.Offer
{
    public class BuyXGetNPercentPromotion : Promotion
    {
        public int PurchaseQuantity { get; set; }
        public int FollowingDiscountQuantity { get; set; }
        public int FollowingDiscountPercent { get; set; }

        protected override void ApplyImplementation(OrderLineItem lineItem, DateTime orderDate, IGroceryOrder groceryOrder)
        {
            if (lineItem.Quantity >= PurchaseQuantity)
            {
                lineItem.Promotion = this;
            }
        }
    }
}
