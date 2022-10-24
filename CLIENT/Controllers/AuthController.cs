﻿
using CLIENT.Repositories.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace CLIENT.Controllers
{
    public class AuthController : Controller
    {
        AuthRepository authRepository;
        public AuthController(AuthRepository authRepository)
        {
            this.authRepository = authRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Auth(Login login)
        {
            var jwttoken = await authRepository.Auth(login);
            var token = new JwtSecurityTokenHandler().ReadJwtToken(jwttoken.Token);
            var email = token.Claims.First(c => c.Type == "email").Value;
            var id = token.Claims.First(c => c.Type == "nameid").Value;
            var name = token.Claims.First(c => c.Type == "unique_name").Value;
            var role = token.Claims.First(c => c.Type == "role").Value;
            if (jwttoken.Token == null)
            {
                return Json(Url.Action("Index", "Home"));
            }
            HttpContext.Session.SetString("JWToken", jwttoken.Token);
            HttpContext.Session.SetString("Email", email);
            HttpContext.Session.SetString("EmployeeId", id);
            HttpContext.Session.SetString("name", name);
            HttpContext.Session.SetString("role", role);

            if (role == "Finance")
            {
                return Json(Url.Action("GetFinance", "Submission"));
            }
            else if(role == "Admin")
            {
                return Json(Url.Action("GetAdminAll", "Submission"));
            }
            else
            {
                return Json(Url.Action("GetEmployee", "Submission"));
            }
            

        }



        /*[Route("register")]
        [HttpPost]
        public JsonResult Register(Register register)
        {
            var result = authRepository.Register(register);
            return Json(result);
        }*/
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Token");
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Home");
        }
    }
}
