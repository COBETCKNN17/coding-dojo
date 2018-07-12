using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DefaultProject.Models;

namespace DefaultProject.Controllers
{
    public class HomeController : Controller
    {
        private ProjectContext _projectContext;
        public HomeController (ProjectContext context)
        {
            _projectContext = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Route("create")]
        public IActionResult Create(Review model)
        {
            if (ModelState.IsValid)
            {
                // Review newReview = new Review
                // {
                //     reviewer_name = model.reviewer_name,
                //     restaurant_name = model.restaurant_name,
                //     review_comments = model.review_comments,
                //     rating = model.rating,
                //     visited = model.visited,
                //     created_at = DateTime.Now,
                //     updated_at = DateTime.Now
                // };
                _projectContext.Add(model);
                _projectContext.SaveChanges();
                return RedirectToAction("Reviews");
            }
            return View("Index");
        }

        [HttpGet]
        [Route("reviews")]
        public IActionResult Reviews()
        {
            //return View(_projectContext.reviews.OrderByDescending(q => q.created_at).ToList());
            List<Review> allReviews = _projectContext.reviews.OrderByDescending(review => review.created_at).ToList();
            ViewBag.allReviews = allReviews;

            return View("Reviews");
        }
    }
}