using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCIApplication.DAL;

namespace TCIApplication.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        TCIApplicationContext _dbContext = null;

        public DepartmentRepository(TCIApplicationContext context)
        {
            _dbContext = context;
        }

        public IEnumerable<Department> GetOrderedList()
        {
            var departmentsQuery = from d in _dbContext.Departments
                                   orderby d.Name
                                   select d;
            return departmentsQuery;
        }
    }
}