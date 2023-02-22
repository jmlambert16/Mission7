using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission7.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext movieContext { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieContext context)
        {
            _logger = logger;
            movieContext = context;
        }
        //Index
        public IActionResult Index()
        {
            return View();
        }

        //Form
        [HttpGet]
        public IActionResult Form()
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Form(MovieSubmission model)
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(model);
                movieContext.SaveChanges();
                return View("MovieAdded", model);
            }
            else
            {
                ViewBag.Categories = movieContext.Categories.ToList();

                return View();
            }

        }

        //Podcasts
        public IActionResult Podcasts()
        {
            return View();
        }

        //Move List
        [HttpGet]
        public IActionResult List ()
        {
            var submissions = movieContext.Submissions
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(submissions);
        }

        //Edit
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            var movie = movieContext.Submissions.Single(x => x.MovieId == movieid);

            return View("Form", movie);
        }
        [HttpPost]
        public IActionResult Edit(MovieSubmission update)
        {
            movieContext.Update(update);
            movieContext.SaveChanges();

            return RedirectToAction("List");
        }

        //Delete
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = movieContext.Submissions.Single(x => x.MovieId == movieid);

            return View(movie);
        }
        [HttpPost]
        public IActionResult Delete(MovieSubmission ar)
        {
            movieContext.Submissions.Remove(ar);
            movieContext.SaveChanges();

            return RedirectToAction("List");
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
