using CLIENT.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLIENT.Controllers
{
    public class SubmissionController : Controller
    {
        private readonly AssetSubmissionRepository submissionRepository;
        public SubmissionController(AssetSubmissionRepository submissionRepository)
        {
            this.submissionRepository = submissionRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetSubmissionAdmin()
        {
            var result = await submissionRepository.GetSubmissionAdmin();
            return Json(result);
        }

        /*[HttpGet]
        public async Task<JsonResult> GetSubmissionAdminAll()
        {
            var result = await submissionRepository.GetSubmissionAdminAll();
            return Json(result);
        }*/
    }
}
