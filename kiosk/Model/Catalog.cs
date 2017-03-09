using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using kiosk.Entity;

namespace kiosk.Model
{
    public class Catalog : System.ComponentModel.BindingList<CatalogItem>//, ICatalog
    {
        public CatalogItem AddNew(IProduct product, decimal price, EffectiveDate effectiveDate)
        {
            CatalogItem item = new CatalogItem();
            item.Name = product.Name;
            item.Price = price;
            item.Effective = effectiveDate;
            Add((CatalogItem)item);
            return item;
        }

        public CatalogItem AddNew(string name, decimal price, DateTime effectiveFrom)
        {
            return AddNew(name, price, effectiveFrom, null);
        }

        public CatalogItem AddNew(string name, decimal price, DateTime effectiveFrom, DateTime? effectiveTo)
        {
            return AddNew(new Product(name), price, new EffectiveDate(effectiveFrom, effectiveTo));
        }

        public OrderLineItemCollection Price(ProductCollection shoppingList, DateTime orderDate)
        {
            OrderLineItemCollection items = new OrderLineItemCollection();

            //Group the products together and calculate quantities
            var result = shoppingList.GroupBy(x => x.Name)
                .Select(x => new { Name = x.Key, Count = x.Count() });

            foreach (var item in result)
            {
                try
                {
                    items.Add(Price(item.Name, item.Count, orderDate));
                }
                catch(KeyNotFoundException knfex)
                {
                    //TODO: Add to unpriced items list.
                }
                catch (Exception ex)
                {
                    throw;
                }
                Console.WriteLine("Pricing item: " + item.Name + " " + item.Count.ToString());
            }


            return items;
        }



        private OrderLineItem Price(string productName, int quantity, DateTime orderDate)
        {
            OrderLineItem item = new OrderLineItem();
            CatalogItem currentPrice = null;

            //CatalogItem currentPricing = this.Select(x => x.Name == productName && orderDate >= x.Effective.From && orderDate <= x.Effective.To).First();
            //var pricingItem = this.Select(x => x.Name == productName && orderDate >= x.Effective.From && x.Effective.To == null || orderDate <= x.Effective.To)).First();

            foreach (CatalogItem pricingItem in this)
                if(productName == pricingItem.Name 
                    && orderDate >= pricingItem.Effective.From
                    && pricingItem.Effective.To == null || orderDate <= pricingItem.Effective.To)
                {
                    currentPrice = pricingItem;
                    break;
                }

            if (currentPrice == null || currentPrice.Price == null)
                throw new KeyNotFoundException(string.Format("Product \"{0}\" is missing pricing information for {1}", productName, orderDate.ToShortDateString()));

            currentPrice.PriceItem(item, quantity);
            /*
            item = new OrderLineItem()
            {
                Product = currentPrice.Name
                , Quantity = quantity
                , ListPrice = (decimal)currentPrice.Price
                , OrderPrice = Convert.ToDecimal(quantity) * (decimal)currentPrice.Price
            };
            */


            return item;
        }
    }
}
