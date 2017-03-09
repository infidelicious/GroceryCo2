using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk.ViewEntity
{
    public interface IGroceryView
    {
        void Bind(Entity.IGroceryOrder groceryOrder); //Idelaly we would be specifying Entity.IGroceryOrder
        void Bind(System.ComponentModel.BindingList<Exception> exceptions);
    }
}
