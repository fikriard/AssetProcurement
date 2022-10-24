using API.Models;
using CLIENT.Base;
using CLIENT.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLIENT.Controllers
{
    public class YearsProcurementController : BaseController<YearsProcurement, YearsProcurementRepository, int>
    {
        public YearsProcurementController(YearsProcurementRepository yearsProcurement) : base(yearsProcurement)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
