using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Exament2.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Exament2.Controllers
{
    public class AuthController : BaseController
    {
        private PokemonContext context;
        private readonly IConfiguration configuration;
        public AuthController(PokemonContext context, IConfiguration configuration) : base(context)
        {
            this.context = context;
            this.configuration = configuration;
        }
        [Authorize]
        //public string logeruserView()
        //{

        //    return ("el usuario logeado es : " + logeruser().Username);
        //}
        [HttpGet]
        public string Index(string input)
        {
            return createHash(input);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = context.Usuarios.Where(o => o.Username == username && o.Password == createHash(password))
              .FirstOrDefault();
            if (user != null)
            {
                //atenticamos
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };
                var claimsIdentity = new ClaimsIdentity(claims, "Login");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToAction("Index1", "Pokemon");

            }
            ModelState.AddModelError("Login", "usuario o contraseña incorrecots");
            return View();
        }
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        private string createHash(string input)
        {
            var sha = SHA256.Create();
            input = input + configuration.GetValue<string>("Token");
            var inputbaytes = Encoding.Default.GetBytes(input);
            var hash = sha.ComputeHash(inputbaytes);
            return Convert.ToBase64String(hash);
        }
    }
}
