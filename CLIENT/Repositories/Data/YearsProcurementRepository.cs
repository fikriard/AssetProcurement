using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLIENT.Repositories.Data
{
    public class YearsProcurementRepository : GeneralRepository<YearsProcurement, int>
    {
        public YearsProcurementRepository(string request = "YearsProcurement/") : base(request)
        {

        }
    }
}
