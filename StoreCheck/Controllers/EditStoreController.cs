using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreCheck.Controllers
{
    public class EditStoreController : Controller
    {
        //
        // GET: /EditStore/

        public ActionResult EditStore()
        {
            if (!Request.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");
            return View();
        }

    }
}
