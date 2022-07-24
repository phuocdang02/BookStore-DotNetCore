using ClassLibrary_RepositoryDLL.Authentication;
using ClassLibrary_RepositoryDLL.Entities;
using ClassLibrary_RepositoryDLL.Repository.Interface;
using Microsoft.AspNetCore.Authorization;
using ClassLibrary_RepositoryDLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using Newtonsoft.Json;

namespace BookEcommerce_ASP.NETCore_MVC.Controllers
{
    public class UserController : Controller
    {

        private readonly BookEcommerceContext _context;
        private readonly IAccountRepository _acct;
        public UserController(BookEcommerceContext context, IAccountRepository acct)
        {

            _context = context;
            _acct = acct;
        }

        public IActionResult Register()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Account account)
        {

            if (ModelState.IsValid)
            {
                account.Password = HashPassword.CreateMD5Hash(account.Password);
                _context.Accounts.Add(account);
                _context.SaveChanges();
                return RedirectToAction("RegisterSuccess", "User");
            }
            return BadRequest();
        }


        public IActionResult Login()
        {
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var User = from m in _context.Accounts select m;
                User = User.Where(s => s.Username.Contains(model.Username));
                if (User.Any())
                {
                    if (User.First().Password == HashPassword.CreateMD5Hash(model.Password))
                    {     
                        HttpContext.Session.SetString("username", model.Username);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            return RedirectToAction("LoginFail", "User");
        }
        public IActionResult RegisterSuccess()
        {
            return View();
        }

        public IActionResult LoginFail()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }


    }
}