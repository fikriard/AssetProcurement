using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class YearsProcurementRepository : GeneralRepository<YearsProcurement, int>
    {
        public YearsProcurementRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
