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
    private readonly TrailFactory _userFactory;
 
        public HomeController(TrailFactory connect)
        {
            _userFactory = connect;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.trails = _userFactory.GetAllTrails();
            return View("Index");
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        [Route("createTrail")]
        public IActionResult createTrail(Trail t)
        {
            if (ModelState.IsValid)
            {
                _userFactory.AddTrail(t);   
                return RedirectToAction("Index");
            }
            return View("Add");
        }

        [HttpGet]
        [Route("trails/{idtrails}")]
        public IActionResult Trails(int idtrails)
        {
            ViewBag.trail = _userFactory.GetAllTrails().Single(a => a.idtrails == idtrails);
            return View();
        }
    }
}