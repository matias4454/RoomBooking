using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using RoomBooking.Data;
using RoomBooking.Models;
using System.Security.Cryptography;
using System.Text;

namespace RoomBooking.Controllers
{
    public class LoginController : BaseController// Controller
    {     

        public LoginController(RoomBookingsContext context) : base(context) 
        {
        }

        [HttpGet]
        public IActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginModel loginData) 
        {

            byte[] hashBytes = SHA1.Create().ComputeHash(Encoding.UTF8.GetBytes(loginData.Password));
            StringBuilder sb = new StringBuilder();
            foreach (byte item in hashBytes)
            {
                sb.Append(item.ToString("x2"));
                
            }
            string passwdHash = sb.ToString().ToUpper();
            ;
            UserCred cred = _context.UserCred
                .Where(p => p.User.Email.Equals(loginData.Login))
                .FirstOrDefault();

            if (cred != null && passwdHash.Equals(cred.CredHash))
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginData.Login),
                    new Claim("E-mail", loginData.Login)
                                    
                };
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties props = new AuthenticationProperties() 
                {
                    AllowRefresh = true
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity), props);
                
                return RedirectToAction("Index", "Home");
            }
            else return Unauthorized();

            
        }
        
        public async Task<IActionResult> LogOut() 
        {            
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return View();
        }
    
    }

    public class LoginModel 
    {        
        public string Login { get; set; }
        
        public string Password { get; set; }
    }
}