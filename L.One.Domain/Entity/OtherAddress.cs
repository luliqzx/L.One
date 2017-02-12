using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Domain.Entity
{
    public class OtherAddress : BaseEntity<string>
    {
        public virtual string Address { get; set; }
        public virtual string Country { get; set; }
        public virtual string Region { get; set; }
        public virtual string PostalCode { get; set; }

        public virtual Actor Actor { get; set; }
        //public virtual string ActorId { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            OtherAddress o = (OtherAddress)obj;
            if (o.Id == this.Id && (o.Actor.Id == this.Actor.Id))
            {
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = GetType().GetHashCode();
            hash = (hash * 397) ^ Id.GetHashCode();
            hash = (hash * 397) ^ Actor.Id.GetHashCode();
            return hash;
        }

    }
}
