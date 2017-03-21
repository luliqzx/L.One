using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Domain.Entity
{
    public class Profile : BaseEntity<Guid>
    {
        public virtual Actor Actor { get; set; }

        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string Address { get; set; }
        public virtual string Email { get; set; }
        //public virtual string ActorId { get; set; }


        public virtual void SetActor(Actor Actor)
        {
            this.Actor = Actor;
            //this.ActorId = Actor.Id;
        }

        //public override bool Equals(object obj)
        //{
        //    Profile Profile = (Profile)obj;
        //    if (Profile != null)
        //    {
        //        if (Profile.Username == this.Username && Profile.Actor == this.Actor)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //public override int GetHashCode()
        //{
        //    int i = 0;
        //    i = this.Actor.Id.GetHashCode() + this.Username.GetHashCode();
        //    return i;
        //}
    }
}
