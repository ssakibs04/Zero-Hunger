using NGO_Zerohunger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NGO_Zerohunger.Controllers
{
	public class HomeController : Controller
	{
		ZeroHungerNGOEntities db = new ZeroHungerNGOEntities();	
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		[HttpGet]
		public ActionResult Login()
		{
			ViewBag.Message = "Your Login page.";

			return View();
		}
		[HttpPost]


		public ActionResult Login(Loginmodel login) {
			{
				if (ModelState.IsValid)
				{
					ZeroHungerNGOEntities db = new ZeroHungerNGOEntities();
					var res = (from r in db.restaurants
							   where r.restaurant_name.Equals(login.Name)
							   && r.password.Equals(login.Password)
							   select r).SingleOrDefault();

					var emp = (from em in db.employees
							   where em.employee_name.Equals(login.Name)
							   && em.password.Equals(login.Password)
							   select em).SingleOrDefault();

					admin admin = (from a in db.admins
								 where a.username.Equals(login.Name)
								 && a.password.Equals(login.Password)
								 select a).SingleOrDefault();

					if (res != null)
					{
						Session["restaurant"] = res;
						Session["restaurantName"] = res.restaurant_name;
					
						
						return RedirectToAction("Dashboard", "Restaurant");
					}

					else if (emp != null)
					{
						Session["employee"] = emp;
						Session["employeeName"] = emp.employee_name;
						Session["employeeID"] = emp.employee_id;
						
						return RedirectToAction("Dashboard", "Employee");
					}

					else if (admin != null)
					{
						Session["admin"] = admin.admin_id;
						
						return RedirectToAction("Dashboard", "Admin");
					}
					TempData["Msg"] = "Username Password Invalid";
				}
				return View(login);
			}



		}
	}
}