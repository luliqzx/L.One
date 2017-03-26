using FluentNHibernate.Mapping;
using L.One.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Domain.Map
{
    public class MenuMap : ClassMap<Menu>
    {
        public MenuMap()
        {
            this.Id(x => x.Id).Column("MenuId").GeneratedBy.Assigned();
            this.Map(x => x.Description);
            this.HasMany(x => x.RoleMenus).KeyColumn("MenuId").Inverse();

            this.Map(x => x.Active);
        }
    }
}
