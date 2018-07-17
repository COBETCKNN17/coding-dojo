using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DefaultProject.Models;
using Microsoft.AspNetCore.Identity;

namespace DefaultProject.Controllers
{
    public class HomeController : Controller
    {
        private ProjectContext _projectContext;
        public HomeController (ProjectContext context)
        {
            _projectContext = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
           int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId != null)
            {
                return RedirectToAction("Dashboard");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(User user)
        {
                if(ModelState.IsValid){
                    PasswordHasher<User> Hasher = new PasswordHasher<User>();
                    user.password = Hasher.HashPassword(user,user.password);
                    user.confirm_password = Hasher.HashPassword(user,user.confirm_password);
                    
                        _projectContext.Add(user);
                        _projectContext.SaveChanges();
                        
                    return RedirectToAction("Success");
                }
                else{

                    return View("Index");

                }
            }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string CheckEmail, string CheckPassword)
        {
            Console.WriteLine("Email is: " + CheckEmail);
            Console.WriteLine("Password is: " + CheckPassword);

            User checkUser = _projectContext.users.SingleOrDefault(user => user.email == CheckEmail);
            if (checkUser != null && CheckPassword != null){
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(checkUser, checkUser.password, CheckPassword))
                {
                    Console.WriteLine("GOOD!");
                    HttpContext.Session.SetInt32("UserId", checkUser.UserId);
                    return View("Dashboard");
                }
                else{
                    Console.WriteLine("BAD!");
                    return View("Index");
                }
            }
            else{
                Console.WriteLine("MISSING INFO!");
                return View("Index");
            }
            
        }

        [HttpGet]
        [Route("LogOut")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

    }
}
