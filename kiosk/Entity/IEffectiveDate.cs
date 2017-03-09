using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kiosk.Entity
{
    public interface IEffectiveDate
    {
        DateTime From { get; set; }
        DateTime? To { get; set; }
    }
}
