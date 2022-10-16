
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
            var role = token.Claims.First(c => c.Type == "unique_name").Value;
            if (jwttoken.Token == null)
            {
                return Json(Url.Action("Index", "Home"));
            }
            HttpContext.Session.SetString("JWToken", jwttoken.Token);
            HttpContext.Session.SetString("Email", email);
            HttpContext.Session.SetString("EmployeeId", id);
            HttpContext.Session.SetString("Role", role);

            return Json(Url.Action("Succes", "Home"));
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
            return RedirectToAction("Login", "Auth");
        }
    }
}
