using CLIENT.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CLIENT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
            
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Succes()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Register()
        {
            return View();
        }
        [Authorize(Roles = "Employee")]
        public IActionResult ChangePass()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult ChangePassAdmin()
        {
            return View();
        }
        [Authorize(Roles = "Finance")]
        public IActionResult ChangePassFinance()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult NotFound404()
        {
            return View("NotFound");
        }

        public IActionResult Forbidden()
        {
            return View("Forbidden");
        }
        public IActionResult Unauth()
        {
            return View("Unauthorized");
        }

    }
}
