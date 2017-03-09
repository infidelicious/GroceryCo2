using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using kiosk.Entity;

namespace kiosk.Entity
{
    public interface ICatalog
    {
        ICatalogItem AddNew(string name, decimal price, DateTime effectiveFrom);

        ICatalogItem AddNew(string name, decimal price, DateTime effectiveFrom, DateTime? effectiveTo);

        ICatalogItem AddNew(IProduct product, decimal price, IEffectiveDate effectiveDate);
    }
}
