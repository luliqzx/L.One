using FluentNHibernate.Mapping;
using L.One.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Domain.Map
{
    public class ProfileMap : ClassMap<Profile>
    {
        public ProfileMap()
        {
            this.Id(x => x.Id).Column("ProfileId").GeneratedBy.GuidComb();
            this.Map(x => x.Username).Unique();
            this.References(x => x.Actor).Column("ActorId").Unique();
            this.Map(x => x.Password);
            this.Map(x => x.Email);
            this.Map(x => x.Address);


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
