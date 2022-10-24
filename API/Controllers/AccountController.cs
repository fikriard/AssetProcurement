using API.Repositories.Data;
using API.Service;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountRepository accountRepository;
        private IConfiguration iconfiguration;
        public AccountController(AccountRepository accountRepository, IConfiguration iconfiguration)
        {
            this.accountRepository = accountRepository;
            this.iconfiguration = iconfiguration;
        }
        
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(Login login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Password))
            {
                return BadRequest();
            }
            var check = accountRepository.GetEmployee(login.Email);
            if (check == null)
            {
                return NotFound();
            }
            var result = accountRepository.login(login.Email, login.Password);
            if (result != null)
            {
                var jwt = new JwtService(iconfiguration);

                string FullName = result.Employees.FirstName + " " + result.Employees.LastName;
                string role = accountRepository.GetRolesByUserId(result.Id);
                var token = jwt.GenerateSecurityToken(result.Id, result.Employees.Email, FullName, role);
                return Ok(new { status = 200, message = "login successful!", token = token });
            }
            return BadRequest();
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(Register register)
        {
            if (!string.IsNullOrWhiteSpace(register.Email) && !string.IsNullOrWhiteSpace(register.Password))
            {
                if (ModelState.IsValid)
                {
                    var result = accountRepository.Register(register);
                    if (result > 0)
                        return Ok(new { result = 200, message = "Successfully Registered" });
                    else if (result == -1)
                        return BadRequest(new { result = 400, message = "Email is already registered" });
                }
            }
            return BadRequest();
        }
        [HttpPut("Change-Password/{id}")]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (string.IsNullOrWhiteSpace(changePassword.Email) ||
                string.IsNullOrWhiteSpace(changePassword.OldPassword) ||
                string.IsNullOrWhiteSpace(changePassword.NewPassword))
            {
                return BadRequest();
            }
            var check = accountRepository.GetUserByEmail(changePassword.Email);
            if (check == null)
            {
                return NotFound();
            }
            int result = accountRepository.ChangePassword(changePassword.Email, changePassword.OldPassword, changePassword.NewPassword);
            if (result > 0)
                return Ok(new { status = 200, message = "password-change successful!" });
            return BadRequest();
        }
        [HttpPut("Forgot-Password/{username}")]
        public IActionResult ForgotPassword(ForgetPassword forgetPassword)
        {
            if (string.IsNullOrWhiteSpace(forgetPassword.Email) && string.IsNullOrWhiteSpace(forgetPassword.NewPassword))
            {
                return BadRequest();
            }
            var check = accountRepository.GetUserByEmail(forgetPassword.Email);
            if (check == null)
            {
                return NotFound();
            }
            int result = accountRepository.ForgetPassword(forgetPassword.Email, forgetPassword.NewPassword);
            if (result > 0)
                return Ok(new { status = 200, message = "password-change successful!" });
            return BadRequest();
        }
    }
}
