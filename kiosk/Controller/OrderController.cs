using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel; //BindingList<T>

using kiosk.Model;
using kiosk.Model.Offer;
using kiosk.View;

namespace kiosk.Controller
{
    public class OrderController
    {
        private string _shoppingList = string.Empty;
        private string _orderDate = string.Empty;

        private System.ComponentModel.BindingList<Exception> _exceptions = null;

        public OrderController(string shoppingList): this(shoppingList, DateTime.Now.ToString()) { }
        public OrderController(string shoppingList, string orderDate)
        {
            _shoppingList = shoppingList;
            _orderDate = orderDate;

            Process();
        }

        // A collection of exceptions which the view will show.
        private System.ComponentModel.BindingList<Exception> Exceptions
        {
            get
            {
                if(_exceptions == null)
                    _exceptions = new System.ComponentModel.BindingList<Exception>();

                return _exceptions;
            }
        }

        private void Process()
        {
            DateTime orderProcessDate; // Datetime the order is placed.  Will determine pricing and promotions
            ViewEntity.IGroceryView view = null;    //Our "view" - the console in this case but could be windows/web
                                                    // Ordinarily the controller would work with a specific ViewEntity Interface
                                                    // and bind controls to a concrete implementation of that interface.
                                                    // For simplicity sake, there are no console "UI controls" but there could be.
            ProductCollection products = null;      // List of products in the user's shopping list
            GroceryOrder groceryOrder = null;       // The Order containing line items and pricing
            Catalog catalog = null;
            PromotionCollection promotions = null;

            try
            {
                view = new CommandlineView();

                view.Bind(Exceptions); // bind our view to an errors collection so that it can notify the user of any errors

                //Load our source data
                // Customer's shopping list
                products = Data.XmlSource.Load(typeof(ProductCollection), _shoppingList.ToString()) as ProductCollection;

                //Promotions database
                promotions = Data.XmlSource.Load(typeof(PromotionCollection), "promotions.xml") as Model.Offer.PromotionCollection;

                //Declare and load the Pricebook
                catalog = Data.XmlSource.Load(typeof(Catalog), "catalog.xml") as Catalog;

                if (DateTime.TryParse(_orderDate, out orderProcessDate))
                {
                    groceryOrder = new GroceryOrder(products, orderProcessDate, catalog, promotions);
                    view.Bind(groceryOrder); //Ideally we would bind to something implementing IGroceryOrder
                                            // but due to the xml serializer, I had to resort to using concrete classes.

                    groceryOrder.Process(); //Process the user's shopping list and generate the output
                }
                else
                    throw new Model.Exceptions.Validation.InvalidDateTimeCastException(string.Format("Unable to convert \"{0}\" to a valid datetime.  Please correct this and resubmit.", _orderDate));
            }
            catch (Exception ex)
            {
                if (Exceptions != null)
                    Exceptions.Add(ex);
            }
            finally
            {

            }
        }
    }
}
