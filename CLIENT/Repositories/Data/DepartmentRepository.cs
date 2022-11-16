using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLIENT.Repositories.Data
{
    public class DepartmentRepository : GeneralRepository<Department, int>
    {
        public DepartmentRepository(string request = "Department/") : base(request)
        {

        }
    }
}
