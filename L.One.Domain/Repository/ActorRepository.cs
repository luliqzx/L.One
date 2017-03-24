using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L.Core.Repositories;
using L.One.Domain.Entity;
using L.One.Domain.Common;
using NHibernate;
using NHibernate.Linq;
using System.Collections;
using NHibernate.Criterion;

namespace L.One.Domain.Repository
{
    public interface IActorRepository : IBaseRepositoryFactories<Actor>
    {
        IList<Actor> GetDisplayGrid(string SIDU, string Name);
    }
    public class ActorRepository : BaseRepositoryFactories<Actor>, IActorRepository
    {
        protected IUnitOfWork _unitOfWork { get; set; }
        public ActorRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        public override ISession Session
        {
            get
            {
                if (!_unitOfWork.Session.IsOpen)
                {
                    _unitOfWork.Session = _unitOfWork.CreateSession();
                }
                return _unitOfWork.Session;
            }
        }

        public IList<Actor> GetDisplayGrid(string SIDU, string Name)
        {
            //var lstActor = this.Session.QueryOver<Actor>()
            //    .Select(c => c.Id, c => c.Description, c => c.CreateBy, c => c.CreateDate, c => c.UpdateBy, c => c.UpdateDate)
            //    .List<object[]>();
            //ICriteria crt = this.Session.CreateCriteria<Actor>("act");
            //crt.Add(Expression.Like("act.Id", "%" + SIDU + "%"));
            //crt.CreateCriteria("Profile");
            //crt.Add(Expression.And(Expression.IsNotNull("act.Profile"), Expression.Like("act.Profile.Username", "%" + SIDU + "%")));
            //var x = crt.List<Actor>();
            //return x;

            IQueryable<Actor> qry = this.Session.Query<Actor>();
            var rest = qry.ToList();
            //var rest = from x in qry
            //           //where x.Id == SIDU || x.Description.Like(Name)
            //           select new
            //            {
            //                x.Id,
            //                x.Description,
            //                x.Profile
            //            };

            return rest as IList<Actor>;

            //IQueryOver<Actor, Profile> qryOver = this.Session.QueryOver<Actor>().Left.JoinQueryOver(act => act.Profile);
            //if (!string.IsNullOrWhiteSpace(SIDU))
            //{
            //    qryOver = qryOver.Where(Restrictions.On<Actor>(x => x.Id).IsLike(SIDU) || Restrictions.On<Actor>(x => x.Description).IsLike(Name));
            //    qryOver = qryOver.Where(Restrictions.On<Profile>(x => x.Username).IsLike(SIDU));
            //}

            //IList<Actor> lstActor = qryOver.List();
            //return lstActor;
        }
    }
}
