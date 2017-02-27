using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Domain.Entity
{
    public class RoleMenu
    {
        public virtual Role Role { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual IList<Privilege> Privileges { get; set; }

        public virtual void AddPrivilege(Privilege o)
        {
            if (Privileges == null)
            {
                Privileges = new List<Privilege>();
            }
            Privileges.Add(o);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            RoleMenu o = obj as RoleMenu;
            if (o.Role.Id == this.Role.Id && o.Menu.Id == this.Menu.Id)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 0;
            hash = (this.Role.Id + "|" + this.Menu.Id).GetHashCode();
            return hash;
        }
    }
}
