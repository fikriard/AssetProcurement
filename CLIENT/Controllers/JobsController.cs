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
    public class JobsController : BaseController<Jobs, JobsRepository, int>
    {
        public JobsController(JobsRepository jobs) : base(jobs)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
