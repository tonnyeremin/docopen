using System;
using System.Linq;
using System.Security.Claims;
using DocOpen.Core;
using DocOpen.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace DocOpen.Controllers
{
    public class AccountController :Controller
    {
        private readonly IUsersRepository _userRepository;
        public AccountController(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
           if(!string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))  
           {  
                return RedirectToAction("Login");  
           }

           User user  =  _userRepository.Find(u=>u.Email == userName && u.Password == password).FirstOrDefault();
           if(user != null)
           {
                var identity = new ClaimsIdentity(new[] {  
                    new Claim(ClaimTypes.Name, string.IsNullOrEmpty(user.FirstName)? user.Email : user.FirstName ), 
                    new Claim(ClaimTypes.Role, user.Role.ToString()) 
                }, CookieAuthenticationDefaults.AuthenticationScheme);  
                var principal = new ClaimsPrincipal(identity); 

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);  
  
                return RedirectToAction("Index", "Home");   
           }

            return View();  
        }

        public IActionResult SignUp()
        {
            return View();
        }
         [HttpPost]
        public IActionResult SignUp([FromForm] User user)
        {
              
           UserCreator creator = new UserCreator(_userRepository);
           string error;
           if(creator.ValidateCreation(user, out error))
           {
               creator.CreateUser(user);
               creator.SendActivationEmailAsync(user);

               return RedirectToAction("Login"); 
           }
           return View();
        }


    }
}