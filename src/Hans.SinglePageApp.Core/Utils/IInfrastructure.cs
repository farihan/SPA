using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace Hans.SinglePageApp.Core.Utils
{
    public interface IInfrastructure
    {
        ISessionFactory Initialize();
        void BuildSchema();
        void RebuildSchema();
    }
}
