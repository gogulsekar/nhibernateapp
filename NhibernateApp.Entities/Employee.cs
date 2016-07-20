using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernateApp.Entities
{
    public class Employee
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }

    }
}
