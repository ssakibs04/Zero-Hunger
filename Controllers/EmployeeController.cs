using NGO_Zerohunger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NGO_Zerohunger.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
      ZeroHungerNGOEntities db = new ZeroHungerNGOEntities();
        public ActionResult EmpDashboard()
        {
            return View();
        }

        public ActionResult Assignment()
        {
            ZeroHungerNGOEntities db = new ZeroHungerNGOEntities();

            return View(db.collection_requests.ToList());

        }
   
		public ActionResult Logout()
		{
			Session.Clear();
			return RedirectToAction("Login", "Home");
		}



	}
}