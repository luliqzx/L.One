using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Domain.Entity
{
    public class UoM : BaseEntity<string>
    {
        public virtual string Description { get; set; }
        public virtual bool Active { get; set; }

        public virtual IList<UoMConversion> UoMConversion { get; set; }

        public virtual void AddConversion(UoMConversion _UoMConversion)
        {
            if (UoMConversion == null)
            {
                UoMConversion = new List<UoMConversion>();
            }
            UoMConversion.Add(_UoMConversion);
        }
    }
}
