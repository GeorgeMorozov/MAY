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
    public class AdminController : ApplicationController
    {
        #region declaration
        //public AccountMembershipService MembershipService { get; set; }
        private readonly DataManager _db = new DataManager();
        private const int defaultPageSize = 10;
        #endregion

        protected override void Initialize(RequestContext requestContext)
        {
            //if (MembershipService == null) { MembershipService = new AccountMembershipService(requestContext.HttpContext.User.Identity.Name); }

            base.Initialize(requestContext);
        }
         
        public ActionResult Admin()
        {
            if (!Request.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");
            else
               return View();
        }

        #region Users

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
            Users usr = base.MembershipService.CurrUser;
            if (usr == null )
                return RedirectToAction("LogOn", "Account");
            IQueryable<TRights> Rights = usr.UserRights;
           int a = Rights.Where(itm => itm.SubjectID == 1).Count(); 
            ViewBag.Login = usr.Login;
            ViewBag.SortType = usr.SortType;
            ViewData["Rights"] = usr.UserRights;
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
            return Content("");//RedirectToAction("Index", "Home");
        }

        #endregion

        #region Roles

        public ActionResult RolesList(int? page)
        {
            return View(_db.GetVWRoles().ToPagedList(page.HasValue ? page.Value : 1, defaultPageSize));
        }

        public ActionResult RoleDelete(Guid id)
        {
            System.Web.HttpContext.Current.Session["Users"] = null;
            System.Web.HttpContext.Current.Session["membershipService"] = null;
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
            System.Web.HttpContext.Current.Session["Users"] = null;
            System.Web.HttpContext.Current.Session["membershipService"] = null;
            obj.ID = Guid.NewGuid();
            obj.Roles1 = _db.GetRoleID(Roles);
            obj.Rights = _db.GetRightID(Rights);
            if (!_db.IsDuplicateRight(obj.Roles1, obj.Rights))
                _db.AddRole(obj);
            else
                return RedirectToAction("AddRole", "Admin");

           return RedirectToAction("RolesList", "Admin");
        }

        #endregion

       #region log

        public ActionResult ViewLog(string dbegin, string dend, int? page, int SortBy = 1, bool isAsc = true)
        {
           var Fltlst = _db.GetVWLog();
           if (!String.IsNullOrEmpty(dbegin)) Fltlst = Fltlst.Where(p => ((p.Date != null) ? p.Date : DateTime.MinValue) >= Convert.ToDateTime(dbegin)).ToList();
           if (!String.IsNullOrEmpty(dend)) Fltlst = Fltlst.Where(p => ((p.Date != null) ? p.Date : DateTime.MinValue) <= Convert.ToDateTime(dend) + new TimeSpan(24,0,0) ).ToList();

 

            #region Sorting
            switch (SortBy)
            {
                case 1:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.Date).ToList() : Fltlst.OrderByDescending(p => p.Date).ToList();
                    break;
                case 2:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.UserName).ToList() : Fltlst.OrderByDescending(p => p.UserName).ToList();
                    break;
                case 3:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.Field).ToList() : Fltlst.OrderByDescending(p => p.Field).ToList();
                    break;
                case 4:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.New).ToList() : Fltlst.OrderByDescending(p => p.New).ToList();
                    break;
                case 5:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.Old).ToList() : Fltlst.OrderByDescending(p => p.Old).ToList();
                    break;
                default:
                    Fltlst = isAsc ? Fltlst.OrderBy(p => p.Date).ToList() : Fltlst.OrderByDescending(p => p.Date).ToList();
                    break;
            }
            #endregion
            ViewBag.SortBy = SortBy;
            ViewBag.IsAsc = isAsc;
            ViewBag.dbegin = dbegin;
            ViewBag.dend = dend;
            return View(Fltlst.ToPagedList(page.HasValue ? page.Value : 1, defaultPageSize));
        }

       #endregion
    }
}
