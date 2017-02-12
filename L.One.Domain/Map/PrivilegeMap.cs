using FluentNHibernate.Mapping;
using L.One.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Domain.Map
{
    public class PrivilegeMap : ClassMap<Privilege>
    {
        public PrivilegeMap()
        {
            this.Id(x => x.Id).Column("PrivilegeId").GeneratedBy.Assigned();
            this.Map(x => x.Description);

            this.HasManyToMany(x => x.RoleMenus).Table("RoleMenuPrivilege").ChildKeyColumns.Add("RoleId", "MenuId").ParentKeyColumn("PrivilegeId");
        }
    }
}
