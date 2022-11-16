using API.Context;
using API.Models;
using API.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class AssetSubmissionRepository : GeneralRepository<AssetSubmission, string>
    {
        MyContext myContext;
        public IConfiguration _configuration;
        public AssetSubmissionRepository(MyContext myContext, IConfiguration configuration) : base(myContext)
        {
            this.myContext = myContext;
            this._configuration = configuration;
        }

        public int SubmissionForm(Submission submission)
        {
            AssetSubmission submissions = new AssetSubmission();
            {
                submissions.AssetCode = submission.AssetCode;
                submissions.AssetCategory_Id = submission.AssetCategory_Id;
                submissions.AssetLocation_Id = submission.AssetLocation_Id;
                submissions.AssetName = submission.AssetName;
                submissions.Volume = submission.Volume;
                submissions.prize = submission.prize;
                switch(submission.Status)
                {
                    case 0:
                        submissions.Status = Status.Draft;
                        break;
                    case 1:
                        submissions.Status = Status.Posted;
                        break;
                    case 2:
                        submissions.Status = Status.Approved;
                        break;
                    case 3:
                        submissions.Status = Status.Rejected;
                        break;
                    case 4:
                        submissions.Status = Status.Canceled;
                        break;
                    case 5:
                        submissions.Status = Status.ApprovedByAdmin;
                        break;
                    case 6:
                        submissions.Status = Status.ApprovedByFinance;
                        break;
                    case 7:
                        submissions.Status = Status.RejectedByAdmin;
                        break;
                    case 8:
                        submissions.Status = Status.RejectedByFinance;
                        break;
                }
                submissions.AssetValue = submission.Volume * submission.prize;
                submissions.GoodAsset = submission.Volume;
                submissions.BrokenAsset = 0;
                submissions.Employee_Id = submission.Employee_Id;
                submissions.YearsOfSubmission = submission.YearsOfSubmission;
            }
            myContext.AssetSubmission.Add(submissions);
            var registeringsubmission = myContext.SaveChanges();
            return registeringsubmission;
        }

        public int SubmissionUpdateFinance(SubmissionFinance submission , string assetcode, int yearsid)
        {
             var submissions = myContext.AssetSubmission.Find(assetcode);

                 submissions.AssetCode = submission.AssetCode;
                submissions.AssetCategory_Id = submission.AssetCategory_Id;
                submissions.AssetLocation_Id = submission.AssetLocation_Id;
                submissions.AssetName = submission.AssetName;
                submissions.Volume = submission.Volume;
                submissions.prize = submission.prize;
                switch (submission.Status)
                {
                    case 0:
                        submissions.Status = Status.Draft;
                        break;
                    case 1:
                        submissions.Status = Status.Posted;
                        break;
                    case 2:
                        submissions.Status = Status.Approved;
                        break;
                    case 3:
                        submissions.Status = Status.Rejected;
                        break;
                    case 4:
                        submissions.Status = Status.Canceled;
                        break;
                    case 5:
                        submissions.Status = Status.ApprovedByAdmin;
                        break;
                    case 6:
                        submissions.Status = Status.ApprovedByFinance;
                        break;
                    case 7:
                        submissions.Status = Status.RejectedByAdmin;
                        break;
                    case 8:
                        submissions.Status = Status.RejectedByFinance;
                        break;
                }
                submissions.AssetValue = submission.AssetValue;
                submissions.GoodAsset = submission.GoodAsset;
                submissions.BrokenAsset = submission.BrokenAsset;
                submissions.Employee_Id = submission.Employee_Id;
                submissions.YearsOfSubmission = submission.YearsOfSubmission;
            
            
            var assetsubmissions = myContext.SaveChanges();
            if (assetsubmissions > 0)
            {
                var years = myContext.YearsProcurement.Find(yearsid);
                if (years == null)
                {
                    return -1;
                }
                 years.Total += submission.AssetValue;
                var assubmission = myContext.SaveChanges();
                return assubmission;
            }
            
            return 0;
        }
        public int submissionEdit(string assetcode, SubmisionEdit submisionEdit)
        {
            var data = myContext.AssetSubmission.Find(assetcode);
            if (data == null)
            {
                return -1;
            }

            data.AssetName = submisionEdit.AssetName;
            data.GoodAsset = submisionEdit.GoodAsset;
            data.BrokenAsset = submisionEdit.BrokenAsset;

            var result = myContext.SaveChanges();
            return result;
        }
        public IEnumerable<Submissionid> GetSubmissionId(string id)
        {
            //var assetSubmission = myContext.AssetSubmission.FirstOrDefault(c => c.AssetCode.Equals(id));
            var assetSubmission = from a in myContext.AssetSubmission
                                 where a.AssetCode == id
                                 select new Submissionid()
                                   {
                                     AssetCode = a.AssetCode,
                                     AssetName = a.AssetName,
                                     Volume = a.Volume,
                                     prize = a.prize,
                                     GoodAsset = a.GoodAsset,
                                     BrokenAsset = a.BrokenAsset,
                                     AssetCategory_Id = a.AssetCategory_Id,
                                     Status = (int)a.Status,
                                     AssetLocation_Id = a.AssetLocation_Id,
                                     AssetValue = a.AssetValue,
                                     YearsOfSubmission = a.YearsOfSubmission,
                                 };
            var data = assetSubmission.ToList();
            return data;
        }
        public IEnumerable<SubmissionM> GetSubmission(string employeeid)
        {
            var register = from a in myContext.Employees
                           where a.NIK == employeeid
                           join b in myContext.AssetSubmission on a.NIK equals b.Employee_Id
                           where b.Status != Status.Canceled
                           select new SubmissionM()
                           {
                               AssetCode = b.AssetCode,
                               Employees = b.Employees,
                               AssetName = b.AssetName,
                               Volume = b.Volume,
                               Status = (int)b.Status,
                               AssetLocation = b.AssetLocation,
                               AssetValue = b.AssetValue,
                               YearsProcurement = b.YearsProcurement,
                           };
            var data = register.ToList().OrderBy(iss => (iss.Status, true));
            return data;
        }

        public IEnumerable<SubmissionAF> GetSubmissionAdmin()
        {
            var register = from a in myContext.Employees
                           join b in myContext.AssetSubmission on a.NIK equals b.Employee_Id
                           where b.Status == Status.Posted
                           select new SubmissionAF()
                           {
                               Employees = b.Employees,
                               AssetCategory = b.AssetCategory,
                               AssetLocation = b.AssetLocation,
                               YearsProcurement = b.YearsProcurement,
                               AssetLocation_Id = b.AssetLocation_Id,
                               AssetCode = b.AssetCode,
                               Status = (int)b.Status,
                               AssetName = b.AssetName,
                               Volume = b.Volume,
                               AssetValue = b.AssetValue,
                               YearsOfSubmission = b.YearsOfSubmission,
                           };
            var data = register.ToList();
            return data;
        }
        public IEnumerable<Submission> GetSubmissionAdminAll()
        {
            var register = from a in myContext.Employees
                           join b in myContext.AssetSubmission on a.NIK equals b.Employee_Id
                           where b.Status == Status.Approved
                           select new Submission()
                           {
                               Employees = b.Employees,
                               AssetCategory = b.AssetCategory,
                               AssetLocation = b.AssetLocation,
                               YearsProcurement = b.YearsProcurement,
                               AssetLocation_Id = b.AssetLocation_Id,
                               AssetCode = b.AssetCode,
                               AssetName = b.AssetName,
                               Volume = b.Volume,
                               AssetValue = b.AssetValue,
                               YearsOfSubmission = b.YearsOfSubmission,
                               GoodAsset = b.GoodAsset,
                               BrokenAsset = b.BrokenAsset
                           };
            var data = register.ToList();
            return data;
        }
        public IEnumerable<SubmissionAF> GetSubmissionFinance()
        {
            var register = from a in myContext.Employees
                           join b in myContext.AssetSubmission on a.NIK equals b.Employee_Id
                           where b.Status == Status.ApprovedByAdmin
                           select new SubmissionAF()
                           {
                               Employees = b.Employees,
                               AssetCategory = b.AssetCategory,
                               AssetLocation = b.AssetLocation,
                               YearsProcurement = b.YearsProcurement,
                               AssetLocation_Id = b.AssetLocation_Id,
                               AssetCode = b.AssetCode,
                               Status = (int)b.Status,
                               AssetName = b.AssetName,
                               Volume = b.Volume,
                               AssetValue = b.AssetValue,
                               YearsOfSubmission = b.YearsOfSubmission,
                           };
            var data = register.ToList();
            return data;
        }
        //sementara Tampilan Finance
        public IEnumerable<Submission> GetSubmissionYears(int Yearsid)
        {
            var register = from a in myContext.YearsProcurement
                           where a.Id == Yearsid
                           join b in myContext.AssetSubmission on a.Id equals b.YearsOfSubmission
                           where b.Status == Status.Approved
                           select new Submission()
                           {
                               Employees = b.Employees,
                               AssetCategory = b.AssetCategory,
                               AssetLocation = b.AssetLocation,
                               YearsProcurement = b.YearsProcurement,
                               AssetLocation_Id = b.AssetLocation_Id,
                               AssetCode = b.AssetCode,
                               AssetName = b.AssetName,
                               Volume = b.Volume,
                               AssetValue = b.AssetValue,
                               YearsOfSubmission = b.YearsOfSubmission,
                               GoodAsset = b.GoodAsset,
                               BrokenAsset = b.BrokenAsset
                           };
            var data = register.ToList();
            return data;
        }
    }
}
