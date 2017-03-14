using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Domain.Entity
{
    public class Menu : BaseEntity<string>
    {
        public virtual string Description { get; set; }
        public virtual int Position { get; set; }
        public virtual Menu MainMenu { get; set; }
        public virtual string Link { get; set; }
        public virtual bool Active { get; set; }

        public virtual IList<RoleMenu> RoleMenus { get; set; }

    }
}
