using CLIENT.Base;
using API.Models;
using CLIENT.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLIENT.Controllers
{
    public class DepartmentController : BaseController<Department, DepartmentRepository, int>
    {
        public DepartmentController(DepartmentRepository departmentRepository) : base(departmentRepository)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
