using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LostInTheWoods.Models;
using LostInTheWoods.Factory;

namespace LostInTheWoods.Controllers
{
    public class HomeController : Controller
    {
    private readonly TrailFactory _trailFactory;
 
        public HomeController(TrailFactory connect)
        {
            _trailFactory = connect;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.trails = _trailFactory.GetTrails();
            return View("Index");
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        [Route("CreateTrail")]
        public IActionResult CreateTrail(Trail trail)
        {
            if (ModelState.IsValid)
            {
                _trailFactory.AddTrail(trail);   
                return RedirectToAction("Index");
            }
            return View("Add");
        }

        [HttpGet]
        [Route("trails/{idtrails}")]
        public IActionResult Trails(int idtrails)
        {
            ViewBag.trail = _trailFactory.GetTrails().Single(a => a.idtrails == idtrails);
            return View();
        }
    }
}