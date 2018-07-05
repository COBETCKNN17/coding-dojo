    using Microsoft.AspNetCore.Mvc;
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

            [HttpGet]
            [Route("result")]
            public IActionResult Result(string name, string location, string favLanguage, string comment)
            {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.favLanguage = favLanguage;
            ViewBag.comment = comment;
            return View("Result");
            }
        }
    }