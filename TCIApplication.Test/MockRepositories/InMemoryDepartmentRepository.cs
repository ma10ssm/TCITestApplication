using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCIApplication.Models;

namespace TCIApplication.Test.MockRepositories
{
    public class InMemoryDepartmentRepository : IDepartmentRepository
    {
        List<Department> _departmentList = new List<Department>
            {
                new Department{ Name = "Finance" },
                new Department{ Name = "HR" },
                new Department{ Name = "Computing" },
                new Department{ Name = "Sales" }
            };

        public IEnumerable<Department> GetOrderedList()
        {
            var departmentsQuery = from d in _departmentList
                                   orderby d.Name
                                   select d;
            return departmentsQuery;
        }
    }
}
