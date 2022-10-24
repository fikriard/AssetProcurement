using API.Models;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CLIENT.Repositories.Data
{
    public class AssetSubmissionRepository : GeneralRepository<AssetSubmission,string>
    {
        private readonly string request;
        private readonly string address;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;
        public AssetSubmissionRepository(string request = "Submission/") : base(request)
        {
            this.address = "https://localhost:44371/api/";
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };
            
        }
        public async Task<List<AssetSubmission>> GetSubmissionAdmin()
        {
            List<AssetSubmission> entitiesNew = new List<AssetSubmission>();

            using (var response = await httpClient.GetAsync(request + "GetAdmin/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entitiesNew = JsonConvert.DeserializeObject<List<AssetSubmission>>(apiResponse);
            }
            return entitiesNew;
        }
        public async Task<List<AssetSubmission>> GetSubmissionFinance()
        {
            List<AssetSubmission> entitiesNew = new List<AssetSubmission>();

            using (var response = await httpClient.GetAsync(request + "GetFinance/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entitiesNew = JsonConvert.DeserializeObject<List<AssetSubmission>>(apiResponse);
            }
            return entitiesNew;
        }
        public async Task<List<AssetSubmission>> GetSubmissionAdminAll()
        {
            List<AssetSubmission> entitiesNew = new List<AssetSubmission>();

            using (var response = await httpClient.GetAsync(request + "GetAdminALL/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entitiesNew = JsonConvert.DeserializeObject<List<AssetSubmission>>(apiResponse);
            }
            return entitiesNew;
        }
        public async Task<List<AssetSubmission>> GetSubmission(string NIK)
        {
            List<AssetSubmission> entitiesNew = new List<AssetSubmission>();

            using (var response = await httpClient.GetAsync(request + "GetSubmissionEmployee/" + NIK))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entitiesNew = JsonConvert.DeserializeObject<List<AssetSubmission>>(apiResponse);
            }
            return entitiesNew;
        }

        public HttpStatusCode SubmissionInsert(Submission submission, string employeeid)
        {
            submission.Employee_Id = employeeid;
            StringContent content = new StringContent(JsonConvert.SerializeObject(submission), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address + request + "SubmissionForm", content).Result;

            return result.StatusCode;
        }

        public HttpStatusCode ApproveFinance(SubmissionFinance submissionFinance , string assetcode, int yearsid)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(submissionFinance), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync(address + request + "ApproveFinance?assetcode=" + assetcode + " &yearsid= " + yearsid, content).Result;

            return result.StatusCode;
        }
        /*public async Task<List<Submission>> GetSubmissionAdminAll()
        {
            List<Submission> entitiesNew = new List<Submission>();

            using (var response = await httpClient.GetAsync(request + "GetAdminALL/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entitiesNew = JsonConvert.DeserializeObject<List<Submission>>(apiResponse);
            }
            return entitiesNew;
        }*/

    }
}
