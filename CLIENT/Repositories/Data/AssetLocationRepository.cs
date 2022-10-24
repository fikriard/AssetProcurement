using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLIENT.Repositories.Data
{
    public class AssetLocationRepository : GeneralRepository<AssetLocation,int>
    {
        public AssetLocationRepository(string request = "AssetLocation/") : base(request)
        {

        }
    }
}
