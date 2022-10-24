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
    public class AssetCategoryController : BaseController<AssetCategory,AssetCategoryRepository,int>
    {
        public AssetCategoryController(AssetCategoryRepository assetCategory) : base(assetCategory)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
