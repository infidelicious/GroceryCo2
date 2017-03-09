using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace KioskTest
{
    [TestClass]
    public class OrderControllerTest
    {
        [TestMethod]
        public void OrderController_SimpleTest()
        {
            kiosk.Controller.OrderController oc = new kiosk.Controller.OrderController("Order001.xml");
        }

        [TestMethod]
        public void OrderController_SimpleHistoricTest()
        {
            kiosk.Controller.OrderController oc = new kiosk.Controller.OrderController("Order001.xml", "2016-01-01");
        }

        [TestMethod]
        public void OrderController_BadListTest()
        {
            try
            {
                kiosk.Controller.OrderController oc = new kiosk.Controller.OrderController("DOESNOTEXIST.xml", "2016-01-01");
            }
            catch(kiosk.Data.Exceptions.FileNotFoundException dfnfex)
            {
                //success
            }
            catch(Exception ex)
            {
                Assert.Fail("An exception was thrown but not handled properly\r\n" + ex.Message);
            }
        }

        [TestMethod]
        public void OrderController_BadOrderDateTest()
        {
            try
            {
                kiosk.Controller.OrderController oc = new kiosk.Controller.OrderController("Order001.xml", "2016F01-01");
            }
            catch(kiosk.Model.Exceptions.Validation.InvalidDateTimeCastException icex)
            {
                //success
            }
            catch(Exception ex)
            {
                Assert.Fail("An exception was thrown but not handled properly\r\n" + ex.Message);
            }
        }
        [TestMethod]
        public void OrderController_MangledFileTest()
        {
            kiosk.Controller.OrderController oc = new kiosk.Controller.OrderController("Order001.mangled.xml");
        }
    }
}
