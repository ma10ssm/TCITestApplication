using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCIApplication.Models;

namespace TCIApplication.Test.MockRepositories
{
    public class InMemoryEmployeeRepository : IEmployeeRepository
    {
        List<Employee> _employeeList = new List<Employee>();
        public void Add(Employee employee)
        {
            _employeeList.Add(employee);
        }

        public Employee Get(int employeeId)
        {
            return _employeeList.Where(e => e.EmployeeId == employeeId).FirstOrDefault();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeList;
        }

        public void Remove(int employeeId)
        {
            var employee = _employeeList.Where(e => e.EmployeeId == employeeId).FirstOrDefault();
            _employeeList.Remove(employee);
        }

        public void Update(Employee oldEmployee, Employee newEmployee)
        {
            _employeeList.Remove(oldEmployee);
            _employeeList.Add(newEmployee);
        }
    }
}
