using NGO_Zerohunger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NGO_Zerohunger.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: Restaurant
        ZeroHungerNGOEntities db = new ZeroHungerNGOEntities();
        public ActionResult Dashboard()
        {
            return View();
        }
        
      

        [HttpGet]
        public ActionResult Donate()
        {
            ZeroHungerNGOEntities db = new ZeroHungerNGOEntities();
            return View(db.restaurant_foods.ToList());
            }
        [HttpGet]

        public ActionResult AddFood()
        {
			return View();

        }
        [HttpPost]
        public ActionResult AddFood(restaurant_food add)
        {
            var db = new ZeroHungerNGOEntities();
            db.restaurant_foods.Add(add);
            db.SaveChanges();
           
            return RedirectToAction("Dashboard");
        }

        

			public ActionResult Logout()
			{
				Session.Clear();
				return RedirectToAction("Login", "Home");
			}

		
    }
}