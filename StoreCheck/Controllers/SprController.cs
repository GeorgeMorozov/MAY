using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreCheck.Models;

namespace StoreCheck.Controllers
{
    public class SprController : Controller
    {

        public ActionResult Spr()
        {
            if (!Request.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");
            else
                return View();
        }

        public ActionResult Spr_Roles()
        {
            DataManager db = new DataManager();
            ViewBag.Spr_RolesItems = db.GetSpr_Roles();
            return View();
        }
        [HttpGet]
        public ActionResult Spr_RolesEdit(Guid id)
        {
            DataManager db = new DataManager();
            return View(db.GetSpr_Role(id));
        }
        [HttpPost]
        public ActionResult Spr_RolesEdit(Spr_Roles obj)
        {
           if(ModelState.IsValid)
           {
               DataManager db = new DataManager();
               db.SaveSpr_Role(obj);
               return RedirectToAction("Spr_Roles");
           }
           else
           {
               return View();
           }
            
        }


        public ActionResult Spr_Rights()
        {
            return View();
        }

        public ActionResult Spr_CAP()
        {
            return View();
        }

        public ActionResult Spr_SR()
        {
            return View();
        }

    }
}
