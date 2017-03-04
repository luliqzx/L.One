using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Domain.Entity
{
    public class Privilege : BaseEntity<string>
    {
        public virtual string Description { get; set; }
        public virtual ICollection<RoleMenu> RoleMenus { get; set; }
        public virtual bool Active { get; set; }
    }
}
