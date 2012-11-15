using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MvcPaging;
using StoreCheck.Models;

namespace StoreCheck.Controllers
{
    public class SprController : Controller
    {

        private readonly DataManager _db = new DataManager();
        private const int defaultPageSize = 10;
        private const string ALL = "Все";

        public ActionResult Spr()
        {
            if (!Request.IsAuthenticated)
                return RedirectToAction("LogOn", "Account");        
           return View();
        }

        //---------------------------Spr_Roles----------------------------------------
        public ActionResult Spr_RolesList(int? page)
        {
            return View(_db.GetSpr_Roles().ToPagedList(page.HasValue ? page.Value : 1, defaultPageSize));
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

        public ActionResult Spr_RoleDelete(Guid id)
        {
            _db.DeleteSpr_Role(id);
            return RedirectToAction("Spr_RolesList");
        }

        [HttpGet]
        public ActionResult Spr_RoleEdit(Guid id)
        {
            return View(_db.GetSpr_Role(id));
        }

        [HttpPost]
        public ActionResult Spr_RoleEdit(Spr_Roles obj)
        {
            if (ModelState.IsValid)
            {
                _db.SaveSpr_Role(obj);
                return RedirectToAction("Spr_RolesList");
            }
            return View();
        }

        //-------------------Spr_Right------------------------------------
        public ActionResult Spr_RightsList(int? page)
        {
            return View(_db.GetSpr_Rights().ToPagedList(page.HasValue ? page.Value : 1, defaultPageSize));
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
            return RedirectToAction("Spr_RightsList");
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
            return View();
        }

        //-------------------Spr_CAP------------------------------------
        public ActionResult Spr_CAPList(int? page)
        {
            return View(_db.GetSpr_CAPs().ToPagedList(page.HasValue ? page.Value : 1, defaultPageSize));
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
            return RedirectToAction("Spr_CAPList");
        }

        public ActionResult Spr_CAPDetails(Guid id)
        {
            return View(_db.GetSpr_CAP(id));
        }

        public ActionResult Spr_CAPDelete(Guid id)
        {
            _db.DeleteSpr_CAP(id);
            return RedirectToAction("Spr_CAPList");
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
                return RedirectToAction("Spr_CAPList");
            }
            return View();

        }

        //-------------------Spr_Outlets-------------------------------

        [HttpGet]
        public ActionResult Spr_OutletsEdit(Guid id)
        {
            Spr_Outlets obj = _db.GetSpr_Outlet(id);
            ViewData["CatigoryTRT"] = new SelectList(_db.GetCatigoryTRTListDist(), obj.КатегорияТРТ);
            ViewData["ChannelRetail"] = new SelectList(_db.GetChannelRetailListDist(), obj.Каналреализации);
            return View(_db.GetSpr_Outlets(id));
        }

        [HttpPost]
        public ActionResult Spr_OutletsEdit(Spr_Outlets obj, String CatigoryTRT, String ChannelRetail)
        {
            if (ModelState.IsValid)
            {
                obj.КатегорияТРТ = CatigoryTRT;
                obj.Каналреализации = ChannelRetail;
                _db.SaveSpr_Outlets(obj);
                return RedirectToAction("EditStore", "Store", new { id = obj.ID });
            }
            return RedirectToAction("EditStore", "Store");
        }
    
        //-------------------Spr_SR------------------------------------

        public ActionResult Spr_SRList(string SBU, string RegNm, string OblNm, string DistNm, string CodeTA, string TypeTA, string TA, string RouteTA, int? page)
        {
            
            //Регион	 Область	 Дистрибутор	 КодТА	 ТА	 ТипТА	 МаршрутТА
            int currentPageIndex = page.HasValue ? page.Value : 1;
            IList<Spr_SR> Fltlst = _db.GetSpr_SRs();

            List<string> SBULst = new List<string>(from itm in Fltlst orderby itm.SBU select itm.SBU );
            List<string> RegLst = new List<string>(from itm in Fltlst orderby itm.Регион select itm.Регион);
            List<string> OblLst = new List<string>(from itm in Fltlst orderby itm.Область select itm.Область);
            List<string> DistLst = new List<string>(from itm in Fltlst orderby itm.Дистрибутор select itm.Дистрибутор);
            List<string> CodeTALst = new List<string>(from itm in Fltlst orderby itm.КодТА select itm.КодТА);
            List<string> TALst = new List<string>(from itm in Fltlst orderby itm.ТА select itm.ТА);
            List<string> TypeTALst = new List<string>(from itm in Fltlst orderby itm.ТипТА select itm.ТипТА);
            List<string> RouteTALst = new List<string>(from itm in Fltlst orderby itm.МаршрутТА select itm.МаршрутТА);

            SBU = SBU ?? ALL;
            RegNm = RegNm ?? ALL;
            OblNm = OblNm ?? ALL;
            DistNm = DistNm ?? ALL;
            CodeTA = CodeTA ?? ALL;
            TA = TA ?? ALL;
            TypeTA = TypeTA ?? ALL;
            RouteTA = RouteTA ?? ALL;

            SBULst.Insert(0, ALL);
            RegLst.Insert(0, ALL);
            OblLst.Insert(0, ALL);
            DistLst.Insert(0, ALL);
            CodeTALst.Insert(0, ALL);
            TALst.Insert(0, ALL);
            TypeTALst.Insert(0, ALL);
            RouteTALst.Insert(0, ALL);

            if (SBU     != ALL) Fltlst = Fltlst.Where(p => p.SBU.Equals(SBU)).ToList();
            if (RegNm   != ALL) Fltlst = Fltlst.Where(p => p.Регион.Equals(RegNm)).ToList();
            if (OblNm   != ALL) Fltlst = Fltlst.Where(p => p.Область.Equals(OblNm)).ToList();
            if (DistNm  != ALL) Fltlst = Fltlst.Where(p => p.Дистрибутор.Equals(DistNm)).ToList();
            if (CodeTA  != ALL) Fltlst = Fltlst.Where(p => p.КодТА.Equals(CodeTA)).ToList();
            if (TA      != ALL) Fltlst = Fltlst.Where(p => p.ТА.Equals(TA)).ToList();
            if (TypeTA  != ALL) Fltlst = Fltlst.Where(p => p.ТипТА.Equals(TypeTA)).ToList();
            if (RouteTA != ALL) Fltlst = Fltlst.Where(p => p.МаршрутТА == RouteTA).ToList();

            ViewData["SBU"]    = new SelectList(SBULst.AsEnumerable().Distinct<string>(), SBU);
            ViewData["RegNm"]  = new SelectList(RegLst.AsEnumerable().Distinct<string>(), RegNm);
            ViewData["OblNm"]  = new SelectList(OblLst.AsEnumerable().Distinct<string>(), OblNm);
            ViewData["DistNm"] = new SelectList(DistLst.AsEnumerable().Distinct<string>(), DistNm);
            ViewData["CodeTA"] = new SelectList(CodeTALst.AsEnumerable().Distinct<string>(), CodeTA);
            ViewData["TA"]     = new SelectList(TALst.AsEnumerable().Distinct<string>(), TA);
            ViewData["TypeTA"] = new SelectList(TypeTALst.AsEnumerable().Distinct<string>(), TypeTA);
            ViewData["RouteTA"] = new SelectList(RouteTALst.AsEnumerable().Distinct<string>(), RouteTA);

            return View(Fltlst.ToPagedList(page.HasValue ? page.Value : 1, defaultPageSize));
        }

        [HttpGet]
        public ActionResult Spr_SRCreate()
        {
            ViewData["TypeTA"] = new SelectList(_db.GetSpr_TypeTADist());
            return View();
        }

        [HttpPost]
        public ActionResult Spr_SRCreate(Spr_SR obj, String TypeTA)
        {
            obj.ID = Guid.NewGuid();
            obj.ТипТА = TypeTA;
            _db.AddSpr_SR(obj);
            return RedirectToAction("Spr_SRList");
        }

        public ActionResult Spr_SRDetails(Guid id)
        {
            return View(_db.GetSpr_SR(id));
        }

        public ActionResult Spr_SRDelete(Guid id)
        {
            _db.DeleteSpr_SR(id);
            return RedirectToAction("Spr_SRList");
        }

        [HttpGet]
        public ActionResult Spr_SREdit(Guid id)
        {
            Spr_SR obj = _db.GetSpr_SR(id);
            ViewData["TypeTA"] = new SelectList(_db.GetSpr_TypeTADist(), obj.ТипТА);
            //ViewData["SBU"] = new SelectList(_db.GetGetSBUListDist(),  obj.SBU);
            return View(_db.GetSpr_SR(id));
        }

        [HttpPost]
        public ActionResult Spr_SREdit(Spr_SR obj, String TypeTA)
        {
            if (ModelState.IsValid)
            {
                obj.ТипТА = TypeTA;
                _db.SaveSpr_SR(obj);
                return RedirectToAction("Spr_SRList");
            }
            return View();

        }

        //---------------------------Spr_TypeTA----------------------------------------

        public ActionResult Spr_TypeTAList(int? page)
        {
            return View(_db.GetSpr_TypeTA().ToPagedList(page.HasValue ? page.Value : 1, defaultPageSize));
        }

        [HttpGet]
        public ActionResult Spr_TypeTACreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Spr_TypeTACreate(Spr_TypeTA obj)
        {
            obj.ID = Guid.NewGuid();
            _db.AddSpr_TypeTA(obj);
            return RedirectToAction("Spr_TypeTAList");
        }

        public ActionResult Spr_TypeTADetails(Guid id)
        {
            return View(_db.GetSpr_TypeTA(id));
        }

        public ActionResult Spr_TypeTADelete(Guid id)
        {
            _db.DeleteSpr_TypeTA(id);
            return RedirectToAction("Spr_TypeTAList");
        }

        [HttpGet]
        public ActionResult Spr_TypeTAEdit(Guid id)
        {
            return View(_db.GetSpr_TypeTA(id));
        }

        [HttpPost]
        public ActionResult Spr_TypeTAEdit(Spr_TypeTA obj)
        {
            if (ModelState.IsValid)
            {
                _db.SaveSpr_TypeTA(obj);
                return RedirectToAction("Spr_TypeTAList");
            }
            return View();
        }

        //---------------------------Spr_ChannelRetail----------------------------------------

        public ActionResult Spr_ChannelRetailList(int? page)
        {
            return View(_db.GetSpr_ChannelRetails().ToPagedList(page.HasValue ? page.Value : 1, defaultPageSize));
        }

        [HttpGet]
        public ActionResult Spr_ChannelRetailCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Spr_ChannelRetailCreate(Spr_ChannelRetail obj)
        {
            obj.ID = Guid.NewGuid();
            _db.AddSpr_ChannelRetail(obj);
            return RedirectToAction("Spr_ChannelRetailList");
        }

        public ActionResult Spr_ChannelRetailDetails(Guid id)
        {
            return View(_db.GetSpr_ChannelRetail(id));
        }

        public ActionResult Spr_ChannelRetailDelete(Guid id)
        {
            _db.DeleteSpr_ChannelRetail(id);
            return RedirectToAction("Spr_ChannelRetailList");
        }

        [HttpGet]
        public ActionResult Spr_ChannelRetailEdit(Guid id)
        {
            return View(_db.GetSpr_ChannelRetail(id));
        }

        [HttpPost]
        public ActionResult Spr_ChannelRetailEdit(Spr_ChannelRetail obj)
        {
            if (ModelState.IsValid)
            {
                _db.SaveSpr_ChannelRetail(obj);
                return RedirectToAction("Spr_ChannelRetailList");
            }
            return View();
        }
    }
}
