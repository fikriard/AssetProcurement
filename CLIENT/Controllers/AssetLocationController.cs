using API.Models;
using CLIENT.Base;
using CLIENT.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CLIENT.Controllers
{
    public class AssetLocationController : BaseController<AssetLocation, AssetLocationRepository, int>
    {
        public AssetLocationController(AssetLocationRepository assetLocation) : base(assetLocation)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
