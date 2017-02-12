using FluentNHibernate.Mapping;
using L.One.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Domain.Map
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            this.Id(x => x.Id).Column("RoleId").GeneratedBy.Assigned();
            this.References(x => x.MainRole).Column("MainRoleId").Cascade.SaveUpdate();
            this.HasManyToMany(x => x.Actors).Table("ActorRole").ParentKeyColumn("RoleId").ChildKeyColumn("ActorId");
            this.Map(x => x.Description);

            this.HasMany(x => x.RoleMenus).KeyColumn("RoleId").Inverse();

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
