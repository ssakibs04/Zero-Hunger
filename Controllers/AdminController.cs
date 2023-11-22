using NGO_Zerohunger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NGO_Zerohunger.Controllers
{

    public class AdminController : Controller
    {

		ZeroHungerNGOEntities db =new ZeroHungerNGOEntities();
		// GET: Admin
		
        public ActionResult Dashboard()
        
			{
			 var ZeroHungerNGOEntities  = new ZeroHungerNGOEntities();
			var collection_Requests = db.collection_requests;
			ViewBag.Message = "Welcome to the Admin Dashboard!";
			return View(Request);
			}
			[HttpGet]
			public ActionResult Employees()
			{
				var db = new ZeroHungerNGOEntities();
				return View(db.employees.ToList());

			}
			[HttpGet]
			public ActionResult AddEmployees()
			{
				return View();
			}

			[HttpPost]
			public ActionResult AddEmployees(employee moedl)
			{
				var db = new ZeroHungerNGOEntities();
				db.employees.Add(moedl);
				db.SaveChanges();
				return RedirectToAction("Employees");

			}
			[HttpGet]
			public ActionResult EditEmployees(int id)
			{
				var db = new ZeroHungerNGOEntities();
				employee update = db.employees.SingleOrDefault(x => x.employee_id == id);
				return View(update);
			}
			[HttpPost]
			public ActionResult EditEmployees(int id, employee up)
			{
				if (ModelState.IsValid)
				{
					var db = new ZeroHungerNGOEntities();

					employee update = db.employees.SingleOrDefault(x => x.employee_id == id);

					if (update != null)
					{
						update.employee_name = up.employee_name;
						update.contact_number = up.contact_number;

						db.SaveChanges();
						return RedirectToAction("Employees");
					}
					else
					{
						return HttpNotFound();
					}
				}
				else
				{

					return View();
				}
			}

			[HttpGet]
			public ActionResult DeleteEmployees(int id)
			{
				var db = new ZeroHungerNGOEntities();
				employee delete = db.employees.SingleOrDefault(x => x.employee_id == id);
				return View(delete);
			}
			[HttpPost]
			public ActionResult DeleteEmployees(int id, employee delete)
			{
				var db = new ZeroHungerNGOEntities();
				employee del = db.employees.SingleOrDefault(x => x.employee_id == id);
				db.employees.Remove(del);
				db.SaveChanges();
				return RedirectToAction("Employees");
			}

			[HttpGet]
			public ActionResult EmpPss(int id  )
			{
				var db = new ZeroHungerNGOEntities();
				employee read = db.employees.SingleOrDefault(x => x.employee_id ==id);


				return View(read);
			}


			//restaurant 

			[HttpGet]

			public ActionResult Restaurants()
			{
				var db = new ZeroHungerNGOEntities();

				return View(db.restaurants.ToList());
			}
			[HttpGet]
			public ActionResult AddRestaurants()
			{
				return View();
			}
			[HttpPost]
			public ActionResult AddRestaurants(restaurant res)
			{
			if (ModelState.IsValid)
			{
var db = new ZeroHungerNGOEntities();
				db.restaurants.Add(res);
				db.SaveChanges();
				return RedirectToAction("Restaurants");
			}
				
			else { return View(); }
			}
			[HttpGet]
			public ActionResult DeleteRestaurant(int id)
			{
				var db = new ZeroHungerNGOEntities();
				restaurant delete = db.restaurants.SingleOrDefault(x => x.restaurant_id == id);
				return View(delete);
			}
			[HttpPost]
			public ActionResult DeleteRestaurant(int id, restaurant delete)
			{
				var db = new ZeroHungerNGOEntities();
				restaurant del = db.restaurants.SingleOrDefault(x => x.restaurant_id == id);
				db.restaurants.Remove(del);
				db.SaveChanges();
				return RedirectToAction("Restaurants", "Admin");
			}
			[HttpGet]
			public ActionResult EditRestaurant(int id)
			{
				var db = new ZeroHungerNGOEntities();
				restaurant update = db.restaurants.SingleOrDefault(x => x.restaurant_id == id);
				return View(update);
			}
			[HttpPost]
			public ActionResult EditRestaurant(int id, restaurant up)
			{
				if (ModelState.IsValid)
				{
					var db = new ZeroHungerNGOEntities();

					restaurant update = db.restaurants.SingleOrDefault(x => x.restaurant_id == id);

					if (update != null)
					{
						update.restaurant_name = up.restaurant_name;
						update.address = up.address;
						update.contact_number = up.contact_number;
						db.SaveChanges();
						db.SaveChanges();
						return RedirectToAction("Restaurants");
					}
					else
					{
						return HttpNotFound();
					}
				}
				else
				{
					return View();
				}
			}


			[HttpGet]

			public ActionResult Respass(int id)
			{
				var db = new ZeroHungerNGOEntities();
				restaurant read = db.restaurants.SingleOrDefault(x => x.restaurant_id == id);


				return View(read);
			}


		}
	}
    