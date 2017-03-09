using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using kiosk.Data;
using kiosk.Entity;
using kiosk.Model;

namespace KioskTest
{
    [TestClass]
    public class XmlDataSourceTest
    {
        [TestMethod]
        public void XmlDataSource_SerializeCollectionTest1()
        {
            string outputFile = @".\products.xml";

            IProductCollection products = new kiosk.Model.ProductCollection();
            products.AddNew("Apple");
            products.AddNew("Banana");
            products.AddNew("Apple");
            products.AddNew("Apple");

            XmlSource.Save(products, outputFile);

            Assert.IsTrue(System.IO.File.Exists(outputFile));

            //Cleanup
            System.IO.File.Delete(outputFile);
        }

        [TestMethod]
        public void XmlDataSource_SerializeCollectionCompareTest()
        {
            string outputFile = @".\products.xml";

            IProductCollection products = new ProductCollection();
            products.AddNew("Apple");
            products.AddNew("Banana");
            products.AddNew("Apple");
            products.AddNew("Apple");

            XmlSource.Save(products, outputFile);


            IProductCollection products2 = XmlSource.Load(typeof(ProductCollection), outputFile) as IProductCollection;

            Assert.IsNotNull(products2, "ProductCollection could not be rehydrated");
            Assert.AreEqual(products.Count, products2.Count, "ProductCollection was not rehydrated with an incorrect count");

            //Cleanup
            System.IO.File.Delete(outputFile);
        }
    }
}
