using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NhibernateApp
{
    public class NhibernateConfigurationHelper
    {
        public static ISessionFactory BuildSessionFactory(string connectionString)
        {
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("NhibernateApp.Entities")))
                .BuildSessionFactory();
        }
    }
}
