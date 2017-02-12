using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using L.Core.Repositories;
using L.One.Domain.Entity;
using L.One.Domain.Common;
using NHibernate;

namespace L.One.Domain.Repository
{
    public interface IActorRepository : IBaseRepositoryFactories<Actor>
    {
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


    }
}
