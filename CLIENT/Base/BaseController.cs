using CLIENT.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLIENT.Base
{
    public class BaseController<TEntity, TRepository,Primary> : Controller
           where TEntity : class
           where TRepository : IGeneralRepository<TEntity,Primary>
    {
        private readonly TRepository repository;
        public BaseController(TRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            var result = await repository.GetAll();
            return Json(result);
        }

        //GET BY ID
        [HttpGet]
        public async Task<JsonResult> Get(Primary id)
        {
            var result = await repository.Get(id);
            return Json(result);
        }

        //POST
        [HttpPost]
        public JsonResult Post(TEntity entity)
        {
            var result = repository.Post(entity);
            return Json(result);
        }

        //PUT
        [HttpPut]
        public JsonResult Put(Primary id, TEntity entity)
        {
            var result = repository.Put(id, entity);
            return Json(result);
        }

        //DELETE
        [HttpDelete]
        public JsonResult DeleteEntity(Primary Id)
        {
            var result = repository.Delete(Id);
            return Json(result);
        }
    }
}
