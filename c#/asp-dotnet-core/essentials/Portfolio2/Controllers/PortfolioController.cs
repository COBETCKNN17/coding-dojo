    using Microsoft.AspNetCore.Mvc;
    namespace Portfolio2.Controllers
    {
        public class PortfolioController : Controller
        {
            [HttpGet]       //type of request
            [Route("")]     //associated route string (exclude the leading /)
            public IActionResult Index()
            {
                return View("Index");
            }

            [HttpGet]       //type of request
            [Route("projects")]     //associated route string (exclude the leading /)
            public IActionResult Projects()
            {
                return View("Projects");
            }

            [HttpGet]       //type of request
            [Route("contact")]     //associated route string (exclude the leading /)
            public IActionResult Contact()
            {
                return View("Contact");
            }

        }
    }