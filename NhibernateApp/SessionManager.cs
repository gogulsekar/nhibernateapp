using NHibernate;
using NhibernateApp.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernateApp
{
    public class SessionManager : IDisposable
    {
        private ISession _session;

        public SessionManager(ISessionFactory factory, IDbConnection connection)
        {
            connection.Open();
            _session = factory.OpenSession(connection);
        }
        public bool Save(Employee emp)
        {
            using (_session.BeginTransaction())
            {
                // Insert two employees in Database
                _session.Save(emp);
                _session.Transaction.Commit();
            }
            return true;
        }

        public void Load()
        {
            using (_session.BeginTransaction())
            {
                // Create the criteria and load data
                ICriteria criteria = _session.CreateCriteria<Employee>();
                IList<Employee> list = criteria.List<Employee>();
                foreach (var emp in list)
                {
                    Console.WriteLine("ID: " + emp.ID + "Name: " + emp.Name);
                }
                _session.Transaction.Commit();
            }
        }

        public void Dispose()
        {
            _session.Connection.Close();
            _session.Clear();
        }
    }
}
