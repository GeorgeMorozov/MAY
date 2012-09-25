using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcPaging;
using StoreCheck.Models;

namespace StoreCheck.Controllers
{
    public class StoreController : Controller
    {
        private readonly DataManager _db = new DataManager();
        private const int defaultPageSize = 10;

        public ActionResult EditStore(string RegNm, string OblNm, string DistNm, string Release, string Category, string Client, string Adress, int? page)
        {
            if (!Request.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");

            int currentPageIndex = page.HasValue ? page.Value : 1;
            IList<Spr_Outlets> Fltlst =  _db.GetStores();

            string[] RegLst = null;
            RegNm = RegNm ?? string.Empty;

            string[] OblLst = null;
            OblNm = OblNm ?? string.Empty;

            string[] DistLst = null;
            DistNm = DistNm ?? string.Empty;

            string[] ReleaseLst = null;
            Release = Release ?? string.Empty;

            string[] CategoryLst = null;
            Category = Category ?? string.Empty;

            string[] ClientLst = null;
            Client = Client ?? string.Empty;

            string[] AdressLst = null;
            Adress = Adress ?? string.Empty;

          
            RegLst =      new string[Fltlst.Count + 1]; RegLst[0] = "";
            OblLst =      new string[Fltlst.Count + 1]; OblLst[0] = "";
            DistLst =     new string[Fltlst.Count + 1]; DistLst[0] = "";
            ReleaseLst =  new string[Fltlst.Count + 1]; ReleaseLst[0] = "";
            CategoryLst = new string[Fltlst.Count + 1]; CategoryLst[0] = "";
            ClientLst =   new string[Fltlst.Count + 1]; ClientLst[0] = "";
            AdressLst =   new string[Fltlst.Count + 1]; AdressLst[0] = "";

            
            int i = 1;
            foreach (var item in Fltlst)
            {
                RegLst[i] = item.Регион;
                OblLst[i] = item.Область;
                DistLst[i] = item.Дистрибутор;
                ReleaseLst[i] = item.Каналреализации;
                CategoryLst[i] = item.КатегорияТРТ;
                ClientLst[i] = item.Клиент;
                AdressLst[i] = item.Адресдоставки;
                i++;
            }

            if (!string.IsNullOrEmpty(RegNm)) Fltlst = Fltlst.Where(p => p.Регион.Equals(RegNm)).ToList();

            if (!string.IsNullOrEmpty(OblNm)) Fltlst = Fltlst.Where(p => p.Область.Equals(OblNm)).ToList();

            if (!string.IsNullOrEmpty(DistNm)) Fltlst = Fltlst.Where(p => p.Дистрибутор.Equals(DistNm)).ToList();

            if (!string.IsNullOrEmpty(Release)) Fltlst = Fltlst.Where(p => p.Каналреализации.Equals(Release)).ToList();

            if (!string.IsNullOrEmpty(Category)) Fltlst = Fltlst.Where(p => p.КатегорияТРТ.Equals(Category)).ToList();

            if (!string.IsNullOrEmpty(Client)) Fltlst = Fltlst.Where(p => p.Клиент.Equals(Client)).ToList();

            if (!string.IsNullOrEmpty(Adress)) Fltlst = Fltlst.Where(p => p.Адресдоставки.Equals(Adress)).ToList();

            ViewData["RegNm"] = new SelectList(RegLst.AsEnumerable().Distinct<string>(), RegNm);
            ViewData["OblNm"] = new SelectList(OblLst.AsEnumerable().Distinct<string>(), OblNm);
            ViewData["DistNm"] = new SelectList(DistLst.AsEnumerable().Distinct<string>(), DistNm);
            ViewData["Release"] = new SelectList(ReleaseLst.AsEnumerable().Distinct<string>(), Release);
            ViewData["Category"] = new SelectList(CategoryLst.AsEnumerable().Distinct<string>(), Category);
            ViewData["Client"] = new SelectList(ClientLst.AsEnumerable().Distinct<string>(), Client);
            ViewData["Adress"] = new SelectList(AdressLst.AsEnumerable().Distinct<string>(), Adress);

            return View(Fltlst.ToPagedList(currentPageIndex, defaultPageSize));

        }

        public ActionResult Spr_OutletsDetails(Guid id)
        {

            Spr_Outlets Outlet = _db.GetSpr_Outlet(id);

            IList<Spr_CAP> Caplst = _db.GetSpr_CAPs().Where(p => p.КатегорияТРТ.Equals(Outlet.КатегорияТРТ)).ToList();

            ViewBag.ChkBoxLstNm = Caplst;
            
            return View(_db.GetStore(id));

        }

        public ActionResult SaveStore(Guid OutletID) 
        {
          //IEnumerator n =  Request.Form.GetEnumerator();
          string []values;
          string id = "f8a9d108-d2c0-4cd0-8ab1-b5df373906fc";
          CheckOutlet Outlet = new CheckOutlet();
          Outlet.ID = Guid.NewGuid();
          Outlet.OutletID = OutletID;
          Outlet.UserID = Guid.Parse(id);
          Outlet.CkeckDate = DateTime.Now;
          _db.AddCheckOutlet(Outlet);

          
          for (int i = 0; i < Request.Form.Count; i++)
          {
              values = Request.Form.GetValues(i);
              if (values != null && values[0] == "true")
              {
                  CheckOutletData OutletData = new CheckOutletData();
                  OutletData.ID = Guid.NewGuid();
                  OutletData.CheckOutletID = Outlet.ID;
                  OutletData.SKUID = Guid.Parse(Request.Form.Keys[i]);
                  _db.AddCheckOutletData(OutletData);
              }       

          }
            
            return RedirectToAction("EditStore");
        }

        /*
         [HttpPost]
        public ActionResult Spr_RoleCreate(Spr_Roles obj)
        {
            obj.ID = Guid.NewGuid();
            _db.AddSpr_Role(obj);
            return RedirectToAction("Spr_RolesList");
        }
         
         */


        //--------------------------------------------------------------------------------------------------
        public ActionResult ViewStores()
        {
            if (!Request.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");
            return View();
        }

    }
}
