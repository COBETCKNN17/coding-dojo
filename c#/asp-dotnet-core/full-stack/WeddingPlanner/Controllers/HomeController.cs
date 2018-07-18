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
                List<Wedding> rsvps = _context.weddings.Include(u => u.rsvps).ToList();
                List<Wedding> allWeddings = _context.weddings.Include(w => w.creator).ToList(); 
                User currentUser = _context.users.SingleOrDefault(u => u.id == UserId);
                List<RSVP> rsvps_cool = _context.rsvps.Include(r => r.wedding).Include(r => r.user).ToList();

                ViewBag.allWeddings = allWeddings;
                ViewBag.currentUser = currentUser;
                ViewBag.rsvps = rsvps;
                ViewBag.rsvps_cool = rsvps_cool;

                return View("Dashboard");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpGet]
        [Route("create")]
        public IActionResult Create()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId != null)
            {
                DateTime today = DateTime.Today;
                string todayFormat = today.ToString("yyyy-MM-dd");

                ViewBag.today = todayFormat;

                return View("Create");
            }
            else
            {
                return View("Index");
            }
        }

        [HttpPost]
        [Route("createWedding")]
        public IActionResult createWedding(string wedder1, string wedder2, string address, DateTime date)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
                if (UserId != null)
                {
                    User currentUser = _context.users.SingleOrDefault(u => u.id == UserId);

                    Wedding newWedding = new Wedding();
                    newWedding.creator = currentUser;
                    newWedding.wedder1 = wedder1;
                    newWedding.wedder2 = wedder2;
                    newWedding.address = address;
                    newWedding.date = date;
                    _context.Add(newWedding);
                    _context.SaveChanges();

                    currentUser.weddings.Add(newWedding);
                    _context.SaveChanges();

                    return RedirectToAction("Dashboard");
                }

                else
                {
                    return View("Index");
                }
        }

        [HttpPost]
        [Route("rsvp/{weddingId}")]
        public IActionResult rsvpWedding(int weddingId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
                if (UserId != null)
                {

                    User currentUser = _context.users.SingleOrDefault(u => u.id == UserId);
                    Wedding currentWedding = _context.weddings.SingleOrDefault(w => w.id == weddingId);

                    RSVP checkDuplicate = _context.rsvps.SingleOrDefault(r => r.user.id == currentUser.id && r.wedding.id == currentWedding.id);

                    if (checkDuplicate != null){
                        _context.rsvps.Remove(checkDuplicate);
                        _context.SaveChanges();

                        return RedirectToAction("Dashboard");
                    }

                    else{

                        RSVP newRSVP = new RSVP();

                        newRSVP.user = currentUser;
                        newRSVP.wedding = currentWedding;
                        _context.Add(newRSVP);
                        _context.SaveChanges();

                        currentUser.rsvps.Add(newRSVP);
                        currentWedding.rsvps.Add(newRSVP);
                        _context.SaveChanges();

                        return RedirectToAction("Dashboard");
                    }
                }

                else
                {
                    return View("Index");
                }
        }

        [HttpPost]
        [Route("delete/{weddingId}")]
        public IActionResult deleteWedding(int weddingId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
                if (UserId != null)
                {

                    Wedding wedding = _context.weddings.Where(w => w.id == weddingId).SingleOrDefault();
                    _context.weddings.Remove(wedding);
                    _context.SaveChanges();

                    return RedirectToAction("Dashboard");

                }

                else
                {
                    return View("Index");
                }
        }

        [HttpGet]
        [Route("wedding/{weddingId}")]
        public IActionResult viewWedding(int weddingId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId != null)
            {
                User currentUser = _context.users.SingleOrDefault(u => u.id == UserId);
                Wedding currentWedding = _context.weddings.SingleOrDefault(w => w.id == weddingId);
                List<RSVP> rsvps = _context.rsvps.Where(r => r.wedding.id == weddingId).Include(r => r.user).ToList();

                ViewBag.currentWedding = currentWedding;
                ViewBag.currentUser = currentUser;
                ViewBag.rsvps = rsvps;

                return View("Wedding");
            }
            else
            {
                return View("Index");
            }
        }
    }
}
