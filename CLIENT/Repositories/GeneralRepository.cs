using CLIENT.Base;
using CLIENT.Repositories.Interface;
using CLIENT.ViewModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CLIENT.Repositories
{
    public class GeneralRepository<Entity,Primary> : IGeneralRepository<Entity,Primary>
        where Entity : class
    {
        private readonly string request;
        private readonly string address;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly HttpClient httpClient;

        public GeneralRepository(string request)
        {
            this.address = "https://localhost:44371/api/"; ;
            this.request = request;
            _contextAccessor = new HttpContextAccessor();
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };

        }
        public HttpStatusCode Delete(Primary id)
        {
            var result = httpClient.DeleteAsync(request + id).Result;
            return result.StatusCode;
        }

        public async Task<List<Entity>> GetAll()
        {
            Json<Entity> entities = new Json<Entity>();

            using (var response = await httpClient.GetAsync(request))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entities = JsonConvert.DeserializeObject<Json<Entity>>(apiResponse);
            }
            return entities.data;
        }

        public async Task<Entity> Get(Primary id)
        {
            //Entity entity = null;
            Results<Entity> entity = new Results<Entity>();

            using (var response = await httpClient.GetAsync(request + id))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                entity = JsonConvert.DeserializeObject<Results<Entity>>(apiResponse);
            }
            return entity.data;
        }

        public HttpStatusCode Post(Entity entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync(address + request, content).Result;
            return result.StatusCode;
        }

        public HttpStatusCode Put(Primary id, Entity entity)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");
            var result = httpClient.PutAsync(request + id, content).Result;
            return result.StatusCode;
        }
    }
}
