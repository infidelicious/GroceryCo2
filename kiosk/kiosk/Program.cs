using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk
{
    class Program
    {
        private static string usage = "<program> <grocery file> <date>\r\nkiosk.exe GroceryList.xml YYYY-MM-DD\r\nkiosk.exe Order001.xml 2017-03-05";
        static void Main(string[] args)
        {

            try
            {
                if (args.Length < 1 || args.Length > 2)
                    Console.WriteLine(usage);
                else
                {
                    Controller.OrderController oc = null;
                    if (args.Length == 1)
                        oc = new Controller.OrderController(args[0]);
                    else
                        oc = new Controller.OrderController(args[0], args[1]);
                }
            }
            catch(Exception ex)
            {
                //TODO: use Log4net
                Console.WriteLine(string.Format("The kiosk application failed due to an unhandled error.\r\nPlease notify a developer and provide the files and parameters you used to get this as well as the output below.\r\n{0}\r\n{1}",ex.Message, ex.StackTrace));
            }
            finally
            {
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        }
    }
}
