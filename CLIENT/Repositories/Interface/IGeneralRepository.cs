using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CLIENT.Repositories.Interface
{
    public interface IGeneralRepository<Entity,Primary>
        where Entity : class
    {
        Task<List<Entity>> GetAll();
        Task<Entity> Get(Primary id);
        HttpStatusCode Post(Entity entity);
        HttpStatusCode Put(Primary id, Entity entity);
        HttpStatusCode Delete(Primary id);
    }
}
