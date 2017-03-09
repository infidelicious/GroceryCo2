using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

using kiosk.Model;
using kiosk.Data;

namespace KioskTest
{
    [TestClass]
    public class ProductCollectionTest
    {
        [TestMethod]
        public void ProductCollection_AddProductsTest()
        {
            ProductCollection products = new ProductCollection();
            products.AddNew("Apple");
            products.AddNew("Banana");
            products.AddNew("Apple");
            products.AddNew("Apple");

            Assert.IsTrue(products.Count == 4);

            System.Collections.Generic.List<Product> prods = new System.Collections.Generic.List<Product>();
            prods.GroupBy(x => x.Name);

            var results = products.GroupBy(x => x.Name)
                .Select(x => new { Name = x.Key, Count = x.Count() });

            /* Debugger results:
             * Apple: 3
             * Banana: 1
             */

            //TODO: figure out the syntax to access the count groupings.
            // debugger shows it properly but adding to the watch window results in an error.

        }

        [TestMethod]
        public void ProductCollection_AddProductsPPAPTest()
        {
            ProductCollection products = new ProductCollection();
            products.AddNew("Pen");
            products.AddNew("Pineapple");
            products.AddNew("Apple");
            products.AddNew("Pen");

            Assert.IsTrue(products.Count == 4);

            System.Collections.Generic.List<Product> prods = new System.Collections.Generic.List<Product>();
            prods.GroupBy(x => x.Name);

            var results = products.GroupBy(x => x.Name)
                .Select(x => new { Name = x.Key, Count = x.Count() });

            XmlSource.Save(products, "OrderPPAP.xml");
            /* Debugger results:
             * Apple: 3
             * Banana: 1
             */

            //TODO: figure out the syntax to access the count groupings.
            // debugger shows it properly but adding to the watch window results in an error.

        }
    }
}
