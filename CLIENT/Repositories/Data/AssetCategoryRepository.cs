using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLIENT.Repositories.Data
{
    public class AssetCategoryRepository : GeneralRepository<AssetCategory, int>
    {
        public AssetCategoryRepository(string request = "AssetCategory/") : base(request)
        {

        }
    }
}
