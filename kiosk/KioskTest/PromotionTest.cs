using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using kiosk.Model.Offer;

namespace KioskTest
{
    [TestClass]
    public class PromotionTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            PromotionCollection promotions = new PromotionCollection();

            SimplePricePromotion spp = new SimplePricePromotion();
            spp.Product = "Apple";
            spp.Price = 0.5M;
            spp.Period = new kiosk.Model.EffectiveDate(new DateTime(2017, 03, 01), new DateTime(2017, 04, 01));

            GroupFixedPricePromotion gfpp = new GroupFixedPricePromotion();
            gfpp.Period = new kiosk.Model.EffectiveDate(new DateTime(2011, 03, 01), new DateTime(2021, 04, 01));
            gfpp.Product = "Pen";
            gfpp.Quantity = 10;
            gfpp.Price = 9.99M;

            GroupFixedPricePromotion gfppspat = new GroupFixedPricePromotion();
            gfpp.Period = new kiosk.Model.EffectiveDate(new DateTime(2011, 03, 01), new DateTime(2021, 04, 01));
            gfpp.Product = "Spatula";
            gfpp.Quantity = 10;
            gfpp.Price = 7.77M;

            promotions.Add(spp);
            promotions.Add(gfpp);
            promotions.Add(gfppspat);

            kiosk.Data.XmlSource.Save(promotions, "promotions.xml");
        }
    }
}
