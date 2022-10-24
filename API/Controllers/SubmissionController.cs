using API.Base;
using API.Models;
using API.Repositories.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubmissionController : BaseController<AssetSubmissionRepository, AssetSubmission, string>
    {
        private readonly AssetSubmissionRepository submissionRepository;
        private IConfiguration iconfiguration;
        public SubmissionController(AssetSubmissionRepository submissionRepository, IConfiguration iconfiguration) : base(submissionRepository)
        {
            this.submissionRepository = submissionRepository;
            this.iconfiguration = iconfiguration;
        }
        [HttpPost("SubmissionForm")]
        public IActionResult SubmissionForm(Submission submission)
        {
            var result = submissionRepository.SubmissionForm(submission);
            if (result > 0)
                return Ok(new { result = 200, message = "Succesfuly Created" });
            return BadRequest();
        }
         [HttpPut("submisisonEdit/{id}")]
        public IActionResult submissionEdit(string assetcode, SubmisionEdit submisionEdit)
        {
        
            var result = submissionRepository.submissionEdit(assetcode, submisionEdit);

            // updating the data
            if (result > 0)
                return Ok(new { result = 200, message = "Succesfuly Update" });
            else if (result == -1)
                return NotFound();
            return BadRequest();
        }
        [HttpPut("ApproveFinance")]
        public IActionResult ApproveFinance(SubmissionFinance submissionFinance, string assetcode, int yearsid)
        {

            var result = submissionRepository.SubmissionUpdateFinance(submissionFinance, assetcode, yearsid);

            // updating the data
            if (result > 0)
                return Ok(new { result = 200, message = "Succesfuly Update" });
            else if (result == -1)
                return NotFound();
            return BadRequest();
        }
        [HttpGet("GetSubmissionId/{id}")]
        public IActionResult GetSubmissionId(string id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }
            var data = submissionRepository.GetSubmissionId(id);
            if (data != null)
            {
                return Ok(new { status = 200, data = data });
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet("GetSubmissionEmployee/{employeeid}")]
        public ActionResult GetSubmission(string employeeid)
        {
            var result = submissionRepository.GetSubmission(employeeid);

            if (result.Count() != 0)
            {
                return Ok(result);
            }
            return NotFound(result);
        }
        [HttpGet("GetAdmin")]
        public ActionResult GetSubmissionAdmin()
        {
            var result = submissionRepository.GetSubmissionAdmin();

            if (result.Count() != 0)
            {
                return Ok(result);
            }
            return NotFound(result);

        }
        [HttpGet("GetFinance")]
        public ActionResult GetSubmissionFinance()
        {
            var result = submissionRepository.GetSubmissionFinance();

            if (result.Count() != 0)
            {
                return Ok(result);
            }
            return NotFound(result);

        }
        [HttpGet("GetAdminALL")]
        public ActionResult GetSubmissionAdmiAll()
        {
            var result = submissionRepository.GetSubmissionAdminAll();

            if (result.Count() != 0)
            {
                return Ok(result);
            }
            return NotFound(result);

        }
        [HttpGet("GetYears")]
        public ActionResult GetSubmissionYears(int yearsid)
        {
            var result = submissionRepository.GetSubmissionYears(yearsid);

            if (result.Count() != 0)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

    }
}
