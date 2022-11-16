using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLIENT.Repositories.Data
{
    public class JobsRepository : GeneralRepository<Jobs, int>
    {
        public JobsRepository(string request = "Jobs/") : base(request)
        {

        }
    }
}
