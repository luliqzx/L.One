using L.One.Domain.Common;
using L.One.Domain.Entity;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.One.Cons.Controller
{
    public interface ITestController
    {
        void CreateRole();
        void CreateMenu();
        void CreatePrivilege();
        void CreateRoleMenuPrivilege();
    }

    public class TestController : ITestController
    {
        IUnitOfWork uow;
        public TestController(IUnitOfWork _unitOfWork)
        {
            this.uow = _unitOfWork;
        }

        public void CreateRole()
        {
            using (ISession sess = this.uow.CreateSession())
            {
                Role role = sess.Get<Role>("Vendor1");
                if (role == null)
                {
                    role = new Role();
                    role.Id = "Vendor1";
                    role.Description = "Vendor1";
                    role.CreateDate = DateTime.Now;
                    role.UpdateDate = DateTime.Now;
                    this.uow.BeginTransaction();
                    sess.Save(role);
                    this.uow.Commit();
                }
            }
        }

        public void CreateMenu()
        {
            using (ISession sess = this.uow.CreateSession())
            {
                Menu o = sess.Get<Menu>("Menu1");
                if (o == null)
                {
                    o = new Menu();
                    o.Id = "Menu1";
                    o.Description = "Menu1";
                    o.CreateDate = DateTime.Now;
                    o.UpdateDate = DateTime.Now;
                    this.uow.BeginTransaction();
                    sess.Save(o);
                    this.uow.Commit();
                }
            }
        }

        public void CreatePrivilege()
        {
            using (ISession sess = this.uow.CreateSession())
            {
                Privilege o = sess.Get<Privilege>("Privilege1");
                if (o == null)
                {
                    o = new Privilege();
                    o.Id = "Privilege1";
                    o.Description = "Privilege1";
                    o.CreateDate = DateTime.Now;
                    o.UpdateDate = DateTime.Now;
                    this.uow.BeginTransaction();
                    sess.Save(o);
                    this.uow.Commit();
                }
            }
        }

        public void CreateRoleMenuPrivilege()
        {
            using (ISession sess = this.uow.CreateSession())
            {
                this.uow.BeginTransaction();
                Role role = sess.Get<Role>("Vendor1");
                if (role != null)
                {
                    if (role.RoleMenus == null)
                    {
                        role.RoleMenus = new List<RoleMenu>();
                    }
                    role.RoleMenus.Clear();

                    RoleMenu rm = new RoleMenu();
                    rm.Role = role;
                    rm.Menu = sess.Get<Menu>("Menu1");

                    Privilege pr = sess.Get<Privilege>("Privilege1");
                    rm.AddPrivilege(pr);
                    role.AddRoleMenu(rm);

                    sess.SaveOrUpdate(role);
                }
                this.uow.Commit();
            }
        }
    }
}
