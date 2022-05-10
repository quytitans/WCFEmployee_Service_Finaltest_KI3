using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WCFEmployee_Service.Data;
using WCFEmployee_Service.Model;

namespace WCFEmployee_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private EmployeeContext db;
        public Service1()
        {
            db = new EmployeeContext();
        }
        public Employee AddEmployee(Employee employee)
        {
            db.Employees.Add(employee);
            var result = db.SaveChanges();
            if (result == 1)
            {
                return employee;
            }
            else
            {
                return null;
            }
        }

        public List<Employee> GetAll()
        { 
            var list = db.Employees.ToList() as List<Employee>;
           return list;
        }

        public List<Employee> SearchByDepartment(string department)
        {
            var employee = db.Employees.Where(s => s.Department.Contains(department)).ToList();
            return employee;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        
    }
}
