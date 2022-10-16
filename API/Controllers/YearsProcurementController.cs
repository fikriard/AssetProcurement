using API.Base;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YearsProcurementController : BaseController<YearsProcurementRepository, YearsProcurement, int>
    {
        public YearsProcurementController(YearsProcurementRepository yearsProcurementRepository) : base(yearsProcurementRepository)
        {

        }
    }
}
