    using Microsoft.AspNetCore.Mvc;
    namespace RazorFun.Controllers
    {
        public class RazorController : Controller
        {
            [HttpGet]       //type of request
            [Route("")]     //associated route string (exclude the leading /)
            public IActionResult Index()
            {
                return View("Index");
            }

        }
    }