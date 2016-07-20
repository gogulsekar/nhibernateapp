using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NhibernateApp.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NhibernateApp
{
    class Program
    {
        private static ISessionFactory factory;

        static void Main(string[] args)
        {
            //Configuration cfg = new Configuration();
            //cfg.Configure();
            //cfg.AddAssembly("NhibernateApp");
            //ISessionFactory factory = cfg.BuildSessionFactory();
            factory = NhibernateConfigurationHelper.BuildSessionFactory(ConfigurationManager.ConnectionStrings[1].ConnectionString);

            for (int i = 1; i < 3; i++)
            {
                var t = new Thread(new ParameterizedThreadStart(Execute));
                t.Start(i);
                t.Join();
            }

            Console.ReadLine();
        }

        private static void Execute(object i)
        {
            var manager = new SessionManager(factory, new SqlConnection(ConfigurationManager.ConnectionStrings[Convert.ToInt16(i)].ConnectionString));            
            var emp = new Employee { Name = "Gokul" + i };
            manager.Save(emp);
            manager.Load();
            Console.WriteLine("---------------");
        }
    }
}
