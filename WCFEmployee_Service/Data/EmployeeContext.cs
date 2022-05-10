using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WCFEmployee_Service.Model;

namespace WCFEmployee_Service.Data
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext() : base("EmployeeContext")
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}