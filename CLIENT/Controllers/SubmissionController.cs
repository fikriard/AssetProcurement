using API.Models;
using API.ViewModels;
using CLIENT.Base;
using CLIENT.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLIENT.Controllers
{
    public class SubmissionController : BaseController<AssetSubmission, AssetSubmissionRepository,string>
    {
        private readonly AssetSubmissionRepository submissionRepository;
        public SubmissionController(AssetSubmissionRepository submissionRepository) : base(submissionRepository)
        {
            this.submissionRepository = submissionRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAdmin()
        {
            return View();
        }
        public IActionResult GetFinance()
        {
            return View();
        }
        public IActionResult GetAdminAll()
        {
            return View();
        }
        public IActionResult GetEmployee()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetSubmissionAdmin()
        {
            var result = await submissionRepository.GetSubmissionAdmin();
            return Json(result);
        }
        [HttpGet]
        public async Task<JsonResult> GetSubmissionFinance()
        {
            var result = await submissionRepository.GetSubmissionFinance();
            return Json(result);
        }

        [HttpGet]
        public async Task<JsonResult> GetSubmissionAdminAll()
        {
            var result = await submissionRepository.GetSubmissionAdminAll();
            return Json(result);
        }
        [HttpGet]
        public async Task<JsonResult> GetSubmission()
        {
            var sessionid = HttpContext.Session.GetString("EmployeeId");
            var result = await submissionRepository.GetSubmission(sessionid);
            return Json(result);
        }
        [HttpPost]
        public JsonResult SubmissionInsert(Submission submission)
        {
            var sessionId = HttpContext.Session.GetString("EmployeeId");
            var result = submissionRepository.SubmissionInsert(submission, sessionId);

           
            return Json(result);
        }
        [HttpPut]
        public JsonResult ApproveFinance(SubmissionFinance submissionFinance , string assetcode, int yearsid)
        {
            var result = submissionRepository.ApproveFinance(submissionFinance , assetcode,yearsid);
            return Json(result);
        }
    }
}
