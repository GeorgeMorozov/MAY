using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StoreCheck.Models;

namespace StoreCheck.Controllers
{
    public class HomeController : Controller
    {
        public AccountMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (MembershipService == null) { MembershipService = new AccountMembershipService(requestContext.HttpContext.User.Identity.Name); }

            base.Initialize(requestContext);
        }
        
        public ActionResult Index()
        {
            ViewBag.Message = "Добро пожаловать";
            if (!Request.IsAuthenticated) 
                return RedirectToAction("LogOn", "Account");
            else
            {
                Users usr = (Users)Session["CurrUsr"];
                if ( usr == null )
                {
                    usr = MembershipService.CurrUser;
                    Session["CurrUsr"] = usr;
                }
                return View(); 
            }
               
        }     
    }
}
