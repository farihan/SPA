using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Hans.SinglePageApp.Core.Commons;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Hans.SinglePageApp.Core.Utils
{
    public class Infrastructure
    {
        public NHibernate.ISessionFactory Initialize()
        {
            var sf = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(c => c.FromConnectionStringWithKey(KeyType.Connection))
                    .Raw("prepare_sql", "true")
                    .Raw("cache.use_second_level_cache", "true")
                    .Raw("cache.use_query_cache", "true")
                    .DoNot
                    .ShowSql()
                )
                .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "web"))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load(AssemblyType.Core)))
                .BuildSessionFactory();

            return sf;
        }

        public void BuildSchema()
        {
            var sf = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(c => c.FromConnectionStringWithKey(KeyType.Connection))
                    .ShowSql()
                )
                .Mappings(m => m
                    .FluentMappings
                    .AddFromAssembly(Assembly.Load(AssemblyType.Core)))
                .ExposeConfiguration(CreateSchema)
                .BuildSessionFactory();
        }

        public void RebuildSchema()
        {
            var sf = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    .ConnectionString(c => c.FromConnectionStringWithKey(KeyType.Connection))
                    .ShowSql()
                )
                .Mappings(m => m
                    .FluentMappings
                    .AddFromAssembly(Assembly.Load(AssemblyType.Core)))
                .ExposeConfiguration(UpdateSchema)
                .BuildSessionFactory();
        }

        private void CreateSchema(Configuration config)
        {
            new SchemaExport(config).Create(false, true);
        }

        private void UpdateSchema(Configuration config)
        {
            new SchemaUpdate(config).Execute(true, true);
        }
    }
}
