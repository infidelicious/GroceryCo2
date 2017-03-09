using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk.Entity
{
    public interface ICatalogItem
    {
        string Name { get; set; }
        //EffectiveDate Effective { get; set; }
        decimal? Price { get; set; }
    }
}
