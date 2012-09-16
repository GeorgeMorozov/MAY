using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreCheck.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Добро пожаловать";
            if (!Request.IsAuthenticated) 
                return RedirectToAction("LogOn", "Account");
            else
                return View();
        }     
    }
}
