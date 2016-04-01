using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCIApplication.Models
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetOrderedList();
    }
}
