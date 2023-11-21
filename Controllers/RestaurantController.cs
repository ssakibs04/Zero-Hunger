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
        public ActionResult GiveReq() {
        
        return View();
        
        }
        [HttpPost]

        public ActionResult GiveReq(food_items item)
        {
            if (ModelState.IsValid)
            {
                var db = new ZeroHungerNGOEntities();
                db.food_items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Dashboard", "Restaurant");
            }

            return View(item);
        }
			public ActionResult Logout()
			{
				Session.Clear();
				return RedirectToAction("Login", "Home");
			}

		
    }
}