    using Microsoft.AspNetCore.Mvc;
    namespace Portfolio1.Controllers
    {
        public class PortfolioController : Controller
        {
            [HttpGet]       //type of request
            [Route("")]     //associated route string (exclude the leading /)
            public string Index()
            {
                return "This is my index!";
            }

            [HttpGet]       //type of request
            [Route("projects")]     //associated route string (exclude the leading /)
            public string Projects()
            {
                return "These are my projects!";
            }

            [HttpGet]       //type of request
            [Route("contact")]     //associated route string (exclude the leading /)
            public string Contact()
            {
                return "This is my contact!";
            }

        }
    }