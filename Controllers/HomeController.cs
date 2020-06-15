using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsAndDishes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace ChefsAndDishes.Controllers
{
    public class HomeController : Controller
    {
        private ChefDishContext dbContext;
        public HomeController(ChefDishContext context)
        {
            dbContext = context;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            List<Chef> chefs = dbContext.Chefs
                .Include(c => c.CreatedDishes).ToList();
            ViewBag.AllTheChefs = chefs;
            // IEnumerable<DateTime> chefDOB = dbContext.Chefs
            //     .Select(c => c.DOB).ToList();
            // DateTime Today = new DateTime();
            // ViewBag.Today = Today;
            // ViewBag.ChefDOB = chefDOB;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [Route("Dishes")]
        [HttpGet]
        public IActionResult Dishes()
        {
            List<Dish> dishes = dbContext.Dishes
                .Include(d => d.Creator).ToList();
            ViewBag.AllTheDishes = dishes;
            return View("Dishes");
        }

        [Route("New")]
        [HttpGet]
        public IActionResult New()
        {
            return View("New");
        }

        [Route("CreateChef")]
        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(chef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("New");
            }
        }

        [Route("Dishes/New")]
        [HttpGet]
        public IActionResult NewDish()
        {
            List<Chef> chefs = dbContext.Chefs
                .ToList();
            ViewBag.ListOfChefs = chefs; 
            return View("NewDish");
        }

        [Route("CreateDish")]
        [HttpPost]
        public IActionResult CreateDish(Dish dish)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(dish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                return View("NewDish");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
