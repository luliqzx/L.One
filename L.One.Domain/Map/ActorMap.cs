using FluentNHibernate.Mapping;
using L.One.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Domain.Map
{
    public class ActorMap : ClassMap<Actor>
    {
        public ActorMap()
        {
            this.Id(x => x.Id).Column("ActorId").GeneratedBy.Assigned();
            this.Map(x => x.Active);
            this.Map(x => x.Description);
            this.References(x => x.MainActor).Column("MainActorId");
            this.HasOne(x => x.Profile).PropertyRef(x => x.Actor).Cascade.All();

            this.HasMany(x => x.OtherAddress).KeyColumn("ActorId").Inverse().Cascade.AllDeleteOrphan();

            //this.HasManyToMany(x => x.Roles).ParentKeyColumns.Add(.Table("ActorRole");

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
