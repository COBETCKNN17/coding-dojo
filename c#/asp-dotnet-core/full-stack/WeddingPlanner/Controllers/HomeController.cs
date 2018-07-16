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

        // DASHBOARD STUFF

        [HttpGet]
        [Route("dashboard")]
        public IActionResult Dashboard()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if (UserId != null)
            {
                List<Wedding> AllWeddings = _context.Weddings
                  .Include(wedding => wedding.Creator)
                  .Include(wedding => wedding.RSVPs)
                  .ThenInclude(rsvp => rsvp.User).ToList();
                List<Dictionary<string, object>> WeddingList = new List<Dictionary<string, object>>();
                foreach (Wedding wedding in AllWeddings)
                {
                  bool owned = false;
                  bool RSVPed = false;
                  int RSVPs = 0;
                  if (HttpContext.Session.GetInt32("UserId") == wedding.UserId)
                  {
                    owned = true;
                  }
                  foreach (var rsvp in wedding.RSVPs)
                  {
                    if (rsvp.UserId == HttpContext.Session.GetInt32("UserId"))
                    {
                      RSVPed = true;
                    }
                    ++RSVPs;
                  }
                  Dictionary<string, object> newWeddingThing = new Dictionary<string, object>();
                  newWeddingThing.Add("WeddingId", wedding.WeddingId);
                  newWeddingThing.Add("Proposer", wedding.Proposer);
                  newWeddingThing.Add("Proposee", wedding.Proposee);
                  newWeddingThing.Add("WeddingDate", wedding.WeddingDate);
                  newWeddingThing.Add("Owned", owned);
                  newWeddingThing.Add("RSVPs", RSVPs);
                  newWeddingThing.Add("RSVPed", RSVPed);
                  WeddingList.Add(newWeddingThing);
                }
                ViewBag.Weddings = WeddingList;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        [Route("delete/{WeddingId}")]
        public IActionResult Delete(int WeddingId)
        {
          Wedding deleteTarget = _context.Weddings.SingleOrDefault(
            w => w.UserId == (int)HttpContext.Session.GetInt32("UserId") &&
            w.WeddingId == WeddingId);
          if (deleteTarget != null)
          {
            _context.Weddings.Remove(deleteTarget);
            _context.SaveChanges();
          }
          return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("UnRSVP/{WeddingId}")]
        public IActionResult UnRSVP(int WeddingId)
        {
          RSVP bailTarget = _context.RSVPs.SingleOrDefault(
            r => r.UserId == (int)HttpContext.Session.GetInt32("UserId") &&
            r.WeddingId == WeddingId);
          if (bailTarget != null)
          {
            _context.RSVPs.Remove(bailTarget);
            _context.SaveChanges();
          }
          return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("Respond/{WeddingId}")]
        public IActionResult Respond(int WeddingId)
        {
          RSVP newRSVP = new RSVP{
            UserId = (int)HttpContext.Session.GetInt32("UserId"),
            WeddingId = WeddingId
          };
          RSVP existingRSVP = _context.RSVPs.SingleOrDefault(
            r => r.UserId == (int)HttpContext.Session.GetInt32("UserId") &&
            r.WeddingId == WeddingId);
          if (existingRSVP == null)
          {
            _context.RSVPs.Add(newRSVP);
            _context.SaveChanges();
          }
          return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("addwedding")]
        public IActionResult WeddingForm()
        {
          return View();
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(Wedding wedding)
        {
          if (ModelState.IsValid)
          {
            Wedding newWedding = new Wedding{
              Proposer = wedding.Proposer,
              Proposee = wedding.Proposee,
              WeddingDate = wedding.WeddingDate,
              Address = wedding.Address,
              CreatedAt = DateTime.UtcNow,
              UpdatedAt = DateTime.UtcNow,
              UserId = (int)HttpContext.Session.GetInt32("UserId")
            };
            _context.Weddings.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction("Index");
          }
          else
          {
            return View("WeddingForm", wedding);
          }
        }

        [HttpGet]
        [Route("wedding/{WeddingId}")]
        public IActionResult Wedding(int WeddingId)
        {
          Wedding thisWedding = _context.Weddings
            .Include(w => w.RSVPs)
            .ThenInclude(r => r.User)
            .SingleOrDefault(w => w.WeddingId == WeddingId);
          ViewBag.ThisWedding = thisWedding;
          return View();
        }

    }
}
