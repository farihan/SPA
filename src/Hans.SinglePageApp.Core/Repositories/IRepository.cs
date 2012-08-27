using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Hans.SinglePageApp.Core.Repositories
{
    public interface IRepository<TDomain>
    {
        void Delete(TDomain instance);

        void Create(TDomain instance);

        void Update(TDomain instance);

        TDomain FindOneBy(Expression<Func<TDomain, bool>> where);

        IList<TDomain> FindAll();
        IList<TDomain> FindAllBy(Expression<Func<TDomain, bool>> where);
    }
}
