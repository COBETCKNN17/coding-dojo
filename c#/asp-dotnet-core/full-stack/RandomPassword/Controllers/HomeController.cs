using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RandomPassword.Models;

namespace RandomPassword.Controllers
{
    public class HomeController : Controller
    {
        public static Random random = new Random();
        
        public static string randString()
        {
            string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(characters, 14).Select(newString => newString[random.Next(newString.Length)]).ToArray());
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index(int counter, string pass)
        {
            HttpContext.Session.SetInt32("timesClicked", counter);
            int? timesClicked = HttpContext.Session.GetInt32("timesClicked");
            
            ViewBag.clickedCount = timesClicked;
            ViewBag.newString = pass;

            return View();
        }

        [HttpGet("generate")]
        public IActionResult redirect()
        {
           int? counter = HttpContext.Session.GetInt32("timesClicked");
           counter++;
           string newString = randString();

           return RedirectToAction("Index",new {counter, pass = newString});
       }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
