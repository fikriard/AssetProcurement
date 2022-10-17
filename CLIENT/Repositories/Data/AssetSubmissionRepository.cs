using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CLIENT.Repositories.Data
{
    public class AssetSubmissionRepository
    {
        private readonly string request;
        private readonly string address;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;
        public AssetSubmissionRepository()
        {
            this.address = "https://localhost:44371/api/";
            this.request = "Submission/";
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };
            
        }
        public async Task<List<SubmissionAF>> GetSubmissionAdmin()
        {
            List<SubmissionAF> entitiesNew = new List<SubmissionAF>();

            using (var response = await httpClient.GetAsync(request + "GetAdmin/"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entitiesNew = JsonConvert.DeserializeObject<List<SubmissionAF>>(apiResponse);
            }
            return entitiesNew;
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
