using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DojoSurvey.Models;

    namespace DojoSurvey.Controllers
    {
        public class SurveyController : Controller
        {
            [HttpGet]
            [Route("")]
            public IActionResult Index()
            {
                return View("Index");
            }

            [HttpPost("process")]
            public IActionResult Process(string name, string location, string favLanguage, string comment)
            {

                User newUser = new User
                {
                    name = name,
                    location = location,
                    favLanguage = favLanguage,
                    comment = comment,
                };

                if(ModelState.IsValid)
                {
                   Console.WriteLine("This is good!");
                   return View("Result", newUser);
                }
                else
                {
                    Console.WriteLine("NO!");
                    return View("Index");
                }
            }
        }
    }