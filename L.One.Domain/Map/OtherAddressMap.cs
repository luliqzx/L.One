using FluentNHibernate.Mapping;
using L.One.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Domain.Map
{
    public class OtherAddressMap : ClassMap<OtherAddress>
    {
        public OtherAddressMap()
        {
            this.CompositeId()
                .KeyProperty(x => x.Id, "OtherAddressId")
                .KeyReference(x => x.Actor, "ActorId");
            this.Map(x => x.Address);
            this.Map(x => x.Country);
            this.Map(x => x.PostalCode);
            this.Map(x => x.Region);

            #region Audit Trail

            this.Map(x => x.CreateBy);
            this.Map(x => x.CreateDate);
            this.Map(x => x.CreateTerminal);
            this.Map(x => x.UpdateBy);
            this.Map(x => x.UpdateDate);
            this.Map(x => x.UpdateTerminal);
            this.Version(x => x.Version).CustomType<int>();

            #endregion
        }
    }
}
