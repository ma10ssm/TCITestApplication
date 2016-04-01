using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCIApplication.Models
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee Get(int employeeId);
        void Add(Employee employee);
        void Update(Employee oldEmployee, Employee newEmployee);
        void Remove(int employeeId);
        
    }
}
