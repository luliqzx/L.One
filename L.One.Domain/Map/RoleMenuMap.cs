using FluentNHibernate.Mapping;
using L.One.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Domain.Map
{
    public class RoleMenuMap : ClassMap<RoleMenu>
    {
        public RoleMenuMap()
        {
            this.CompositeId()
                .KeyReference(x => x.Role, "RoleId")
                .KeyReference(x => x.Menu, "MenuId");

            this.HasManyToMany(x => x.Privileges).Table("RoleMenuPrivilege").ParentKeyColumns.Add("RoleId", "MenuId").ChildKeyColumn("PrivilegeId");

        }

    }
}
