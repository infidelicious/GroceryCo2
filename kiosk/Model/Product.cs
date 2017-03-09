using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk.Model
{
    public class Product : Entity.IProduct
    {
        public Product() { }
        public Product(string name)
        {
            _name = name;
        }
        private string _name = string.Empty;
        public string Name
        {
            get { return _name; }

            set { _name = value; }
        }

        //TODO: Implement if time
        //public Vendor Vendor { get; set; }
    }
}
