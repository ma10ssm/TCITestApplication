using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCIApplication.DAL;

namespace TCIApplication.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        TCIApplicationContext _dbContext = null;

        public EmployeeRepository(TCIApplicationContext context)
        {
            _dbContext = context;
        }
        public void Add(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
        }
        
        public Employee Get(int employeeId)
        {
            return _dbContext.Employees.Where(e => e.EmployeeId == employeeId).FirstOrDefault();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _dbContext.Employees.ToList();
        }

        public void Update(Employee oldEmployee, Employee newEmployee)
        {            
            _dbContext.Entry(oldEmployee).CurrentValues.SetValues(newEmployee);
            _dbContext.SaveChanges();
        }

        public void Remove(int employeeId)
        {
            var employee = _dbContext.Employees.Find(employeeId);
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
        }
    }
}