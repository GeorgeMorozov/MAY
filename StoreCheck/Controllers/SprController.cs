﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StoreCheck.Models;

namespace StoreCheck.Controllers
{
    public class SprController : Controller
    {
     
        private DataManager _db = new DataManager();

        public ActionResult Spr()
        {
            if (!Request.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");
            else
                return View();
        }

//---------------------------Spr_Roles----------------------------------------
        public ActionResult Spr_RolesList()
        {        
            ViewBag.Spr_RolesItems = _db.GetSpr_Roles();
            return View();
        }

        [HttpGet]
        public ActionResult Spr_RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Spr_RoleCreate(Spr_Roles obj)
        {
            obj.ID = Guid.NewGuid(); 
            _db.AddSpr_Role(obj);
            return RedirectToAction("Spr_RolesList");

        } 
     
        public ActionResult Spr_RoleDetails(Guid id)
        {
            return View(_db.GetSpr_Role(id));
        }

        public ActionResult Spr_RoleDelete( Guid id)
        {
            _db.DeleteSpr_Role(id);
            return RedirectToAction("Spr_RolesList"); ;
        }
 
        [HttpGet]
        public ActionResult Spr_RoleEdit(Guid id)
        {
            return View(_db.GetSpr_Role(id));
        }

        [HttpPost]
        public ActionResult Spr_RoleEdit(Spr_Roles obj)
        {
           if(ModelState.IsValid)
           {
               _db.SaveSpr_Role(obj);
               return RedirectToAction("Spr_RolesList");
           }
           else
           {
               return View();
           }      
        }

//-------------------Spr_Rights------------------------------------
        public ActionResult Spr_RightsList()
        {
            ViewBag.Spr_RightsItems = _db.GetSpr_Rights();
            return View();
        }

        [HttpGet]
        public ActionResult Spr_RightCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Spr_RightCreate(Spr_Rights obj)
        {
            obj.ID = Guid.NewGuid();
            _db.AddSpr_Right(obj);
            return RedirectToAction("Spr_RightsList");

        }

        public ActionResult Spr_RightDetails(Guid id)
        {
            return View(_db.GetSpr_Right(id));
        }

        public ActionResult Spr_RightDelete(Guid id)
        {
            _db.DeleteSpr_Right(id);
            return RedirectToAction("Spr_RightsList"); ;
        }

        [HttpGet]
        public ActionResult Spr_RightEdit(Guid id)
        {
            return View(_db.GetSpr_Right(id));
        }

        [HttpPost]
        public ActionResult Spr_RightEdit(Spr_Roles obj)
        {
            if (ModelState.IsValid)
            {
                _db.SaveSpr_Right(obj);
                return RedirectToAction("Spr_RightsList");
            }
            else
            {
                return View();
            }
        }

//-------------------Spr_CAP------------------------------------
        public ActionResult Spr_CAPsList()
        {
            ViewBag.Spr_CAPsItems = _db.GetSpr_CAPs();
            return View();
        }

        [HttpGet]
        public ActionResult Spr_CAPCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Spr_CAPCreate(Spr_CAP obj)
        {
            obj.ID = Guid.NewGuid();
            _db.AddSpr_CAP(obj);
            return RedirectToAction("Spr_CAPsList");

        }

        public ActionResult Spr_CAPDetails(Guid id)
        {
            return View(_db.GetSpr_CAP(id));
        }

        public ActionResult Spr_CAPDelete(Guid id)
        {
            _db.DeleteSpr_CAP(id);
            return RedirectToAction("Spr_CAPsList"); ;
        }

        [HttpGet]
        public ActionResult Spr_CAPEdit(Guid id)
        {
            return View(_db.GetSpr_CAP(id));
        }

        [HttpPost]
        public ActionResult Spr_CAPEdit(Spr_CAP obj)
        {
            if (ModelState.IsValid)
            {
                _db.SaveSpr_CAP(obj);
                return RedirectToAction("Spr_CAPsList");
            }
            else
            {
                return View();
            }
        }

//-------------------Spr_SP------------------------------------

        public ActionResult Spr_SRsList()
        {
            ViewBag.Spr_SRsItems = _db.GetSpr_SRs();
            return View();
        }

        [HttpGet]
        public ActionResult Spr_SRCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Spr_SRCreate(Spr_SR obj)
        {
            obj.ID = Guid.NewGuid();
            _db.AddSpr_SR(obj);
            return RedirectToAction("Spr_SRsList");

        }

        public ActionResult Spr_SRDetails(Guid id)
        {
            return View(_db.GetSpr_SR(id));
        }

        public ActionResult Spr_SRDelete(Guid id)
        {
            _db.DeleteSpr_SR(id);
            return RedirectToAction("Spr_SRsList"); ;
        }

        [HttpGet]
        public ActionResult Spr_SREdit(Guid id)
        {
            return View(_db.GetSpr_SR(id));
        }

        [HttpPost]
        public ActionResult Spr_SREdit(Spr_SR obj)
        {
            if (ModelState.IsValid)
            {
                _db.SaveSpr_SR(obj);
                return RedirectToAction("Spr_SRsList");
            }
            else
            {
                return View();
            }
        }

    }
}