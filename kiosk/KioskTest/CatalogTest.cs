using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using kiosk.Model;
using kiosk.Data;

namespace KioskTest
{
    [TestClass]
    public class CatalogTest
    {
        [TestMethod]
        public void Catalog_InitializeTest()
        {
            Catalog c = new Catalog();
            string outputFile = "catalog.xml";

            c.AddNew("Apple", 0.75M, DateTime.MinValue, new DateTime(2001,12,31, 23, 59, 59));
            c.AddNew("Apple", 0.75M, new DateTime(2002, 01, 01), null);
            c.AddNew("Banana", 1.0M, DateTime.MinValue, null);
            c.AddNew("Orange Juice", 1.1M, DateTime.MinValue, new DateTime(1983, 06, 09, 23, 59, 59));
            c.AddNew("Orange Juice", 2.0M, new DateTime(1983, 06, 10), null);
            c.AddNew("Pineapple", 5.0M, DateTime.MinValue, null);
            c.AddNew("Pen", 0.99M, DateTime.MinValue, null);

            XmlSource.Save(c, outputFile);

            Catalog c2 = XmlSource.Load(typeof(Catalog), outputFile) as Catalog;

            Assert.IsTrue(c2 != null,"Catalog was not rehydrated successfully");

            Assert.IsTrue(c2.Count == c.Count, "Catalog items serialized and rehydrated are not the same count");

            Assert.IsTrue(c2.Count > 0, "No objects were rehydrated");

//            if (System.IO.File.Exists(outputFile))
//                System.IO.File.Delete(outputFile);
        }
    }
}
