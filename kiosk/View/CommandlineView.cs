using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kiosk.Entity;

namespace kiosk.View
{
    public class CommandlineView : ViewEntity.IGroceryView
    {
        private static string _roundingFormat = "0.##";
        private System.ComponentModel.BindingList<System.Exception> _exceptions = null;
        private IGroceryOrder _groceryOrder = null;

        public void Bind(BindingList<Exception> exceptions)
        {
            _exceptions = exceptions;

            SubscribeErrors();
        }

        private void Exceptions_ListChanged(object sender, ListChangedEventArgs e)
        {
            //TODO: Implement log4net
            Console.WriteLine("Processing errors occurred:");
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                System.Exception ex = _exceptions[e.NewIndex];
                Console.WriteLine(ex.Message);
            }
        }

        public void Bind(IGroceryOrder groceryOrder)
        {
            _groceryOrder = groceryOrder;

            Subscribe();
        }

        private void SubscribeErrors()
        {
            _exceptions.ListChanged += Exceptions_ListChanged;
        }

        private void Subscribe()
        {
            _groceryOrder.OrderProcessStartEvent += _groceryOrder_OrderProcessStartEvent;
            _groceryOrder.OrderProcessCompleteEvent += _groceryOrder_OrderProcessCompleteEvent;
        }

        private void _groceryOrder_OrderProcessStartEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Order processing has started " + DateTime.Now.ToString());
        }

        private void _groceryOrder_OrderProcessCompleteEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Order processing has completed " + DateTime.Now.ToString());
            Display();
        }

        private void Display()
        {
            DisplayHeader();

            foreach (IOrderLineItem item in _groceryOrder.LineItems)
            {
                Display(item);
            }
            DisplayTotal();
        }

        private void DisplayHeader()
        {
            Console.WriteLine(string.Format("{0}\t\t{1}\t{2}\t{3}\t{4}\t{5}", "Product", "Quantity", "List Price", "Order Price", "Net Price", "Promotion"));
        }
        private void Display(IOrderLineItem lineItem)
        {
            if (lineItem != null)
                Console.WriteLine(string.Format("{0}\t\t{1}\t\t{2}\t\t{3}\t\t{4}\t\t{5}", lineItem.Product, lineItem.Quantity.ToString(), lineItem.ListPrice.ToString(_roundingFormat), lineItem.OrderPrice.ToString(_roundingFormat), lineItem.NetPrice.ToString(_roundingFormat), (lineItem.Promotion == null) ? string.Empty : "*"));
        }

        private void DisplayTotal()
        {
            Console.WriteLine(new String('=', 90));
            Console.WriteLine(string.Format("Order Total\t\t\t\t\t\t\t{0}", _groceryOrder.Total.ToString(_roundingFormat)));
        }
    }
}
