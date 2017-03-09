using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using kiosk.Entity;

namespace kiosk.Model
{
    public class EffectiveDate : IEffectiveDate
    {
        private DateTime _from;
        private DateTime? _to = null;
        public EffectiveDate()
        {
            From = DateTime.MinValue;
            To = null;
        }

        public EffectiveDate(DateTime effectiveFrom, DateTime? effectiveTo) : this()
        {
            From = effectiveFrom;
            To = effectiveTo;
        }
        public DateTime From
        {
            get { return _from; }
            set
            {
                //TODO: use entlib or something else to handl the simple validation.
                if (To != null && value > ((DateTime)To))
                    throw new InvalidOperationException("\"From\" cannot be greater than \"To\"");

                _from = value;
            }
        }
        public DateTime? To
        {
            get { return _to; }

            set
            {
                //TODO: use entlib or something else to handl the simple validation.
                if (value != null && ((DateTime)value) <= From)
                    throw new InvalidOperationException("\"To\" date must be greater than the \"From\" date");

                _to = value;
            }
        }
    }
}
