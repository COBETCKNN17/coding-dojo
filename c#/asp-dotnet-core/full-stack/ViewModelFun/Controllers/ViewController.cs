    using Microsoft.AspNetCore.Mvc;
    using ViewModelFun.Models;

    namespace ViewModelFun.Controllers
    {
        public class ViewController : Controller
        {
            [HttpGet]
            [Route("")]
            public IActionResult Index()
            {
                string greeting = "Hello there! This is a string!";
                return View("Index", greeting);
            }

            [Route("numbers")]
            public IActionResult numbers()
            {
                int[] arr = {1,2,3,10,43,5};
                return View("Numbers", arr);
            }

            [Route("users")]
            public IActionResult users()
            {
                string[] names = new string[]
                {
                "Sally", "Billy", "Joey", "Moose"
                };

                return View("Users", names);
            }

            [Route("user")]
            public IActionResult user()
            {
                return View("User");
            }
        }
    }