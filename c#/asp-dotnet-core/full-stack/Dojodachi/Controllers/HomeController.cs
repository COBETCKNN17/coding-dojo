using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dojodachi.Models;
using Microsoft.AspNetCore.Http;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        Random random = new Random();

        [HttpGet("")]
        public IActionResult Index(int Fullness = 20, int Happiness = 20, int Meals = 3, int Energy = 50, string Message = "")
        {

            // Lose Condition
            if (Fullness <= 0 || Happiness <= 0)
            {
                // Passing dead stats to the Viewbag
                ViewBag.Fullness = Fullness;
                ViewBag.Happiness = Happiness;
                ViewBag.Meals = Meals;
                ViewBag.Energy = Energy;
                ViewBag.Won = false;
                ViewBag.Dead = true;
                ViewBag.Message = "Bill Cipher has returned to the mindscape.";
            }

            // Win Condition
            else if (Fullness >= 100 && Happiness >= 100 && Energy >= 100)
            {
                // Passing winning stats to the Viewbag
                ViewBag.Fullness = Fullness;
                ViewBag.Happiness = Happiness;
                ViewBag.Meals = Meals;
                ViewBag.Energy = Energy;
                ViewBag.Won = true;
                ViewBag.Dead = false;
                ViewBag.Message = "Nice work! You've helped Bill conquer this dimension!";
            }

            // Normal Gameplay
            else
            {
                // Setting up all stats in Session
                HttpContext.Session.SetInt32("Fullness", Fullness);
                HttpContext.Session.SetInt32("Happiness", Happiness);
                HttpContext.Session.SetInt32("Meals", Meals);
                HttpContext.Session.SetInt32("Energy", Energy);
                HttpContext.Session.SetString("Message", Message);

                // Passing normal stats to the Viewbag
                ViewBag.Fullness = Fullness;
                ViewBag.Happiness = Happiness;
                ViewBag.Meals = Meals;
                ViewBag.Energy = Energy;
                ViewBag.Won = false;
                ViewBag.Dead = false;
                ViewBag.Message = Message;
            }
            return View();
        }

        [HttpGet("feed")]
        public IActionResult Feed()
        {
            // Setting all attributes to what they are in Session
            int? happiness = HttpContext.Session.GetInt32("Happiness");
            int? energy = HttpContext.Session.GetInt32("Energy");
            int? fullness = HttpContext.Session.GetInt32("Fullness");
            int? meals = HttpContext.Session.GetInt32("Meals");
            string message = HttpContext.Session.GetString("Message");

            // Out of Food
            if (meals == 0)
            {
                message = "No food available! Try working for more.";
                return RedirectToAction("Index", new { Message = message, Meals = 0, Fullness = fullness, Happiness = happiness, Energy = energy });
            }

            // Feeding with random benefits
            else
            {
                meals--;

                // 25% Chance of Refusal

                // Success!
                if (random.Next(1, 5) > 1)
                {
                    fullness += random.Next(5, 11);
                    message = "Bill is eating.";
                }

                // Failure...
                else
                {
                    message = "Bill rejects this food.";
                }

                // Redirect with new Values.

                return RedirectToAction("Index", new { Fullness = fullness, Meals = meals, Happiness = happiness, Energy = energy, Message = message});
            }


        }

        [HttpGet("play")]
        public IActionResult Play()
        {
            // Setting all attributes to what they are in Session
            int? happiness = HttpContext.Session.GetInt32("Happiness");
            int? energy = HttpContext.Session.GetInt32("Energy");
            int? fullness = HttpContext.Session.GetInt32("Fullness");
            int? meals = HttpContext.Session.GetInt32("Meals");
            string message = HttpContext.Session.GetString("Message");

            // Out of Energy
            if (energy == 0)
            {
                message = "Bill is too tired to play.";
                return RedirectToAction("Index", new { Happiness = happiness, Energy = energy, Fullness = fullness, Meals = meals, Message = message });
            }

            else
            {
                energy -= 5;

                // 25% Chance of Refusal

                // Success!
                if (random.Next(1, 5) > 1)
                {

                    happiness += random.Next(5, 11);
                    message = "Bill is playing (with fire).";

                }

                // Failure...
                else
                {
                    message = "Bill refuses to play with you.";
                }
                return RedirectToAction("Index", new { Happiness = happiness, Energy = energy, Fullness = fullness, Meals = meals, Message = message });
            }


        }

        [HttpGet("work")]
        public IActionResult Work()
        {
            // Setting all attributes to what they are in Session
            int? happiness = HttpContext.Session.GetInt32("Happiness");
            int? energy = HttpContext.Session.GetInt32("Energy");
            int? fullness = HttpContext.Session.GetInt32("Fullness");
            int? meals = HttpContext.Session.GetInt32("Meals");
            string message = HttpContext.Session.GetString("Message");

            // Out of Energy
            if (energy == 0)
            {
                message = "Bill is too tired to work.";
                return RedirectToAction("Index", new { Happiness = happiness, Energy = energy, Fullness = fullness, Meals = meals, Message = message });
            }

            // Working! Obtain a random number of meals between 1 and 3.
            else
            {
                energy -= 5;
                meals += random.Next(1, 4);
                message = "Bill is making deals.";
                return RedirectToAction("Index", new { Happiness = happiness, Energy = energy, Fullness = fullness, Meals = meals, Message = message });
            }

        }
        [HttpGet("sleep")]
        public IActionResult Sleep()
        {
            // Setting all attributes to what they are in Session
            int? happiness = HttpContext.Session.GetInt32("Happiness");
            int? energy = HttpContext.Session.GetInt32("Energy");
            int? fullness = HttpContext.Session.GetInt32("Fullness");
            int? meals = HttpContext.Session.GetInt32("Meals");
            string message = HttpContext.Session.GetString("Message");

            // If he's dead...
            if (fullness <= 0 || happiness <= 0)
            {
                message = "Bill Cipher has returned to the mindscape.";
                return RedirectToAction("Index", new { Message = message });
            }

            // Otherwise, he sleeps and regains 15 energy at the cost of 5 fullness and happiness.
            else
            {
                energy += 15;
                fullness -= 5;
                happiness -= 5;
                message = "Bill is taking a quick nap.";
                return RedirectToAction("Index", new { Happiness = happiness, Energy = energy, Fullness = fullness, Meals = meals, Message = message });
            }

        }

        [HttpGet("restart")]
        public IActionResult Restart()
        {
            // Reset the game!
            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
