using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Domain.Entity
{
    public class UoMConversion
    {
        public virtual UoM BaseUoM { get; set; }
        public virtual decimal BaseQty { get; set; }

        public virtual UoM ConvUoM { get; set; }
        public virtual decimal ConvQty { get; set; }

        public override bool Equals(object obj)
        {
            bool ret = false;
            if (obj == null)
            {
                return ret;
            }

            UoMConversion o = obj as UoMConversion;
            if (o.BaseUoM.Id == BaseUoM.Id && o.ConvUoM.Id == ConvUoM.Id)
            {
                ret = true;
            }

            return ret;
        }

        public override int GetHashCode()
        {
            int i = 0;
            i = (BaseUoM.Id + "|" + ConvUoM.Id).GetHashCode();
            return i;
        }
    }
}
