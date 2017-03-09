using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using kiosk.Model;

namespace KioskTest
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void ProductCreateTest()
        {
            string name = "Apple";

            Product p = new Product(name);

            Assert.IsTrue(p.Name == name);
        }
    }
}
