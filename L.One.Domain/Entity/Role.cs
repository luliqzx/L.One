using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Domain.Entity
{
    public class Role : BaseEntity<string>
    {
        public virtual string Description { get; set; }
        public virtual IList<Actor> Actors { get; set; }
        public virtual Role MainRole { get; set; }
        public virtual IList<RoleMenu> RoleMenus { get; set; }

        public virtual void AddActor(Actor newActor)
        {
            if (Actors == null)
            {
                Actors = new List<Actor>();
            }

            if (Actors.FirstOrDefault(x => x.Id == newActor.Id) == null)
            {
                Actors.Add(newActor);
            }
        }

        public virtual void RemoveActor(Actor Actor)
        {
            if (Actors == null)
            {
                Actors = new List<Actor>();
            }

            if (Actors.FirstOrDefault(x => x.Id == Actor.Id) != null)
            {
                Actors.Remove(Actor);
            }
        }

        public virtual void AddRoleMenu(RoleMenu RoleMenu)
        {
            if (RoleMenus == null)
            {
                RoleMenus = new List<RoleMenu>();
            }

            if (RoleMenus.FirstOrDefault(x => x.Role.Id == RoleMenu.Role.Id && x.Menu.Id == RoleMenu.Menu.Id) == null)
            {
                RoleMenus.Add(RoleMenu);
            }
        }

        public virtual void RemoveRoleMenu(RoleMenu RoleMenu)
        {
            if (RoleMenus == null)
            {
                RoleMenus = new List<RoleMenu>();
            }

            if (RoleMenus.FirstOrDefault(x => x.Role.Id == RoleMenu.Role.Id && x.Menu.Id == RoleMenu.Menu.Id) != null)
            {
                RoleMenus.Remove(RoleMenu);
            }
        }
    }
}
