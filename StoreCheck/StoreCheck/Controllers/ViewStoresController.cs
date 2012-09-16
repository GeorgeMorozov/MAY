using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreCheck.Controllers
{
    public class ViewStoresController : Controller
    {
        //
        // GET: /ViewStores/

        public ActionResult ViewStores()
        {
            if (!Request.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");
            return View();
        }

    }
}
