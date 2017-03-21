using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Domain.Entity
{
    public class Actor : BaseEntity<string>
    {
        public virtual string Description { get; set; }
        public virtual bool Active { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual ActorType ActorType { get; set; }

        public virtual Actor MainActor { get; set; }
        //public virtual string MainActorId { get; set; }

        public virtual IList<OtherAddress> OtherAddress { get; set; }
        public virtual IList<Role> Roles { get; set; }

        public virtual void SetProfile(Profile Profile)
        {
            this.Profile = Profile;
            this.Profile.Actor = this;
        }

        public virtual void SetMain(Actor MainActor)
        {
            this.MainActor = MainActor;
            //this.MainActorId = MainActor.Id;
        }

        public virtual void AddNewAddress(OtherAddress NewAddress)
        {
            if (OtherAddress == null)
            {
                OtherAddress = new List<OtherAddress>();
            }

            if (OtherAddress.FirstOrDefault(x => x.Id == NewAddress.Id) == null)
            {
                OtherAddress.Add(NewAddress);
            }
        }

        public virtual void RemoveAddress(OtherAddress RemoveAddress)
        {
            if (OtherAddress == null)
            {
                OtherAddress = new List<OtherAddress>();
            }

            if (OtherAddress.FirstOrDefault(x => x.Id == RemoveAddress.Id) != null)
            {
                OtherAddress.Remove(RemoveAddress);
            }
        }

        public virtual void AddRole(Role newRole)
        {
            if (Roles == null)
            {
                Roles = new List<Role>();
            }

            if (Roles.FirstOrDefault(x => x.Id == newRole.Id) == null)
            {
                Roles.Add(newRole);
            }
        }

        public virtual void RemoveRole(Role role)
        {
            if (Roles == null)
            {
                Roles = new List<Role>();
            }

            if (Roles.FirstOrDefault(x => x.Id == role.Id) != null)
            {
                Roles.Remove(role);
            }
        }
    }
}
