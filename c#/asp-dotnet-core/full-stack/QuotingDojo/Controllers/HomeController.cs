using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuotingDojo.Models;
using DbConnection;


namespace QuotingDojo.Controllers
{
    public class HomeController : Controller {
        
        [HttpGet]
        [Route("")]
        public IActionResult Index() {
            if(TempData["Error"] != null){
                ViewBag.Error = TempData["Error"];
            }
            
            return View();
        }

        [HttpPost]
        [Route("quotes")]
        public IActionResult Create(string name, string quote){
            if(name == null || quote == null){
                TempData["Error"] = "Must provide name and quote!";
                return RedirectToAction("Index");
            }

            string query = $"INSERT INTO quotes (quote, name, create_time, update_time) VALUES ('{quote}', '{name}', NOW(), NOW());";
            DbConnector.Execute(query);

            return RedirectToAction("Quotes");    
        }

        [HttpGet]
        [Route("quotes")]
        public IActionResult Quotes(){

            string query = "SELECT * FROM quotes";
            var quotes = DbConnector.Query(query);

            quotes = quotes.OrderByDescending((quote) => quote["create_time"]).ToList();

            ViewBag.Quotes = quotes;

            return View("Quotes");
        }
    }
}
