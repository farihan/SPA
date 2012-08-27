using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace Hans.SinglePageApp.Core.Repositories
{
    public class Repository<TDomain> : IRepository<TDomain> where TDomain : class
    {
        public ISession Session { get; set; }

        public Repository(ISession session)
        {
            Session = session;
        }

        public void Delete(TDomain instance)
        {
            using (var tx = Session.BeginTransaction())
            {
                Session.Delete(instance);

                try
                {
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public void Create(TDomain instance)
        {
            using (var tx = Session.BeginTransaction())
            {
                Session.Save(instance);

                try
                {
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public void Update(TDomain instance)
        {
            using (var tx = Session.BeginTransaction())
            {
                Session.SaveOrUpdate(instance);

                try
                {
                    tx.Commit();
                }
                catch (Exception)
                {
                    tx.Rollback();
                    throw;
                }
            }
        }

        public TDomain FindOneBy(System.Linq.Expressions.Expression<Func<TDomain, bool>> where)
        {
            return Session.QueryOver<TDomain>().Where(where).Take(1).SingleOrDefault();
        }

        public IList<TDomain> FindAll()
        {
            return Session.QueryOver<TDomain>().List();
        }

        public IList<TDomain> FindAllBy(System.Linq.Expressions.Expression<Func<TDomain, bool>> where)
        {
            return Session.QueryOver<TDomain>().Where(where).List();
        }
    }
}
