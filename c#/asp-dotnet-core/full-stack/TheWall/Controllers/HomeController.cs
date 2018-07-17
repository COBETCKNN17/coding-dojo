using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DefaultProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DefaultProject.Controllers
{
    public class HomeController : Controller
    {
        private ProjectContext _context;
        public HomeController (ProjectContext context)
        {
            _context = context;
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
                    
                        _context.Add(user);
                        _context.SaveChanges();
                        
                    return View("Success");
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

            User checkUser = _context.users.SingleOrDefault(user => user.email == CheckEmail);
            if (checkUser != null && CheckPassword != null){
                var Hasher = new PasswordHasher<User>();
                if(0 != Hasher.VerifyHashedPassword(checkUser, checkUser.password, CheckPassword))
                {
                    Console.WriteLine("GOOD!");
                    HttpContext.Session.SetInt32("UserId", checkUser.id);
                    return RedirectToAction("Dashboard");
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
        [Route("logout")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        // Dashboard Stuff

        
        [HttpGet]
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId != null)
            {
                List<User> users = _context.users.Include(u => u.messages).ToList();
                List<User> allUsers = _context.users.ToList(); 
                User currentUser = _context.users.SingleOrDefault(u => u.id == UserId);

                List<Message> messages = _context.messages.Include(m => m.comments).ToList();

                ViewBag.allUsers = allUsers;
                ViewBag.currentUser = currentUser;


                return View("Dashboard");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost("dashboard/addmessage")]
        public IActionResult addMessage(string newMessage)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId != null)
            {
                User currentUser = _context.users.SingleOrDefault(u => u.id == UserId);

                Message message = new Message();
                message.text = newMessage;
                message.created_at = DateTime.Now;
                message.updated_at = DateTime.Now;
                message.user = currentUser;

                currentUser.messages.Add(message);

                message.user = currentUser;

                _context.SaveChanges();
            }

            else
            {
                return View("Index");
            }

            return RedirectToAction("Dashboard");
        }
        
        [HttpPost("dashboard/addcomment")]
        public IActionResult addComment(string newComment, int messageID){

            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId != null)
            {
                User currentUser = _context.users.SingleOrDefault(u => u.id == UserId);
                Message message = _context.messages.SingleOrDefault(m => m.id == messageID);

                Comment comment = new Comment();
                comment.message = message;
                comment.text = newComment;
                comment.user = currentUser;
                comment.created_at = DateTime.Now;
                comment.updated_at = DateTime.Now;
                
                message.comments.Add(comment);
                _context.SaveChanges();

                return RedirectToAction("Dashboard");
            }

            else
            {
                return View("Index");
            }
        }
    }
}
