using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPaging;
using StoreCheck.Models;
using System.Web.Routing;

namespace StoreCheck.Controllers
{
    public class AdminController : Controller
    {

        public AccountMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (MembershipService == null) { MembershipService = new AccountMembershipService(requestContext.HttpContext.User.Identity.Name); }

            base.Initialize(requestContext);
        }
        
        
        private readonly DataManager _db = new DataManager();
        private const int defaultPageSize = 10;

        public ActionResult Admin()
        {
            if (!Request.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");
            else
               return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult UsersList(int? page)
        {
            return View(_db.GetVWUsers().ToPagedList(page.HasValue ? page.Value : 1, defaultPageSize));
        }

        [HttpGet]
        public ActionResult EditUser(Guid id)
        {
            Users obj = _db.GetUser(id);
            ViewBag.Login = obj.Login;
            ViewData["Roles"] = new SelectList(_db.GetRolesListDist(), _db.GetVWUser(id).RoleName);
            return View(obj);
        }

        [HttpPost]
        public ActionResult EditUser(Users obj, String Roles)
        {
            obj.RoleID = _db.GetRoleID(Roles);
            _db.SaveUser(obj);
            return RedirectToAction("UsersList", "Admin");
        }

        [HttpGet]
        public ActionResult UserPage()
        {
            Users usr = MembershipService.CurrUser;
            ViewBag.Login = usr.Login;
            ViewBag.SortType = usr.SortType; 
            return View(usr);
        }
        [HttpPost]
        public ActionResult UserPage(int? SortType)
        {
            string[] srtTp = Request.Form.GetValues(0);
            Users usr = MembershipService.CurrUser;
            if (srtTp[0] == "enSrtAssort")
                usr.SortType = enSortType.enSrtAssort;
            else
                usr.SortType = enSortType.enSrtTM;
            _db.SaveUser(usr);
            return RedirectToAction("Index", "Home");
        } 
        //---------------------------------------------------------------------------------------------

        public ActionResult RolesList(int? page)
        {
            return View(_db.GetVWRoles().ToPagedList(page.HasValue ? page.Value : 1, defaultPageSize));
        }

        public ActionResult RoleDelete(Guid id)
        {
            _db.DeleteRole(id);
            return RedirectToAction("RolesList", "Admin");
        }

        [HttpGet]
        public ActionResult AddRole()
        {
            ViewData["Roles"] = new SelectList(_db.GetRolesList());
            ViewData["Rights"] = new SelectList(_db.GetRightsList());
            return View();
        }

        [HttpPost]
        public ActionResult AddRole(Roles obj, String Roles, String Rights)
        {
            obj.ID = Guid.NewGuid();
            obj.Roles1 = _db.GetRoleID(Roles);
            obj.Rights = _db.GetRightID(Rights);
            _db.AddRole(obj);
           return RedirectToAction("RolesList", "Admin");
        }
    }
}
